-- KREIRANJE GLAVNIH TABELA

CREATE TABLE Zaposlen (
    JMBG CHAR(13) PRIMARY KEY,
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Datum_Rodjenja DATE,
    Pol CHAR(1) CHECK (Pol IN ('M','Z')),
    Kontakt_Telefon VARCHAR2(20),
    Email VARCHAR2(100),
    Adresa_Stanovanja VARCHAR2(200),
    Datum_Zaposlenja DATE
);

CREATE TABLE Vanredna_Situacija (
    Id NUMBER PRIMARY KEY,
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    Broj_Ugrozenih_Osoba NUMBER,
    Nivo_Opasnosti NUMBER,
    Opstina VARCHAR2(50),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500)
);

CREATE TABLE Interventna_Jedinica (
    Jedinstveni_Broj NUMBER PRIMARY KEY,
    Naziv VARCHAR2(100),
    Broj_Clanova NUMBER,
    JMBG_Komandira CHAR(13) REFERENCES Zaposlen(JMBG),
    Baza VARCHAR2(100)
);

CREATE TABLE Intervencija (
    Id NUMBER PRIMARY KEY,
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Id_Interventne_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Datum_I_Vreme DATE NOT NULL,
    Lokacija VARCHAR2(100),
    Status VARCHAR2(50),
    Broj_Spasenih NUMBER,
    Broj_Povredjenih NUMBER,
    Uspesnost NUMBER
);

CREATE TABLE Prijava (
    Id NUMBER PRIMARY KEY,
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Datum_I_Vreme DATE NOT NULL,
    Tip VARCHAR2(50),
    Ime_Prijavioca VARCHAR2(50),
    Kontakt_Prijavioca VARCHAR2(50),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500),
    JMBG_Dispecera CHAR(13) REFERENCES Zaposlen(JMBG),
    Prioritet NUMBER
);

CREATE TABLE Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY,
    Proizvodjac VARCHAR2(50),
    Tip VARCHAR2(50) CHECK (Tip IN ('Terensko', 'Specijalno', 'Sanitetsko')),
    Status VARCHAR2(50) CHECK (Status IN ('operativno', 'u kvaru')),
    Lokacija VARCHAR2(100)
);

CREATE TABLE Oprema (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY,
    Naziv VARCHAR2(100),
    Tip VARCHAR2(50) CHECK (Tip IN ('Licna zastita', 'Tehnicka oprema', 'Zalihe', 'Medicinska oprema')),
    DatumNabavke DATE,
    Status VARCHAR2(50),
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
);

CREATE TABLE Spoljna_Sluzba (
    Id NUMBER PRIMARY KEY,
    Naziv VARCHAR2(50)
);


---
-- TABELE ZA HIJERARHIJU I VEZNE TABELE
---

-- Uloge Zaposlenih (Nasleđivanje sa 'Zaposlen')
CREATE TABLE Analiticar (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Softver VARCHAR2(100)
);

CREATE TABLE Koordinator (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Timova NUMBER,
    Specijalizacija VARCHAR2(50)
);

CREATE TABLE Operativni_Radnik (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Fizicka_Spremnost VARCHAR2(50),
    Broj_Operativnih_Sati NUMBER
);

-- Tabela za istoriju uloga
CREATE TABLE Istorija_Uloga_Zaposlenih (
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Uloga VARCHAR2(50),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    PRIMARY KEY (JMBG, Uloga, Datum_Od)
);

CREATE TABLE Ekspertiza_Analiticara (
    JMBG CHAR(13) REFERENCES Analiticar(JMBG),
    Oblast VARCHAR2(50),
    PRIMARY KEY (JMBG, Oblast)
);

CREATE TABLE Sertifikat (
    JMBG CHAR(13) REFERENCES Operativni_Radnik(JMBG),
    Naziv VARCHAR2(50),
    Institucija VARCHAR2(100),
    Datum_Izdavanja DATE NOT NULL,
    Datum_Vazenja DATE,
    PRIMARY KEY (JMBG, Naziv, Institucija)
);


CREATE TABLE Terensko_Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Podtip VARCHAR2(50) CHECK (Podtip IN ('Džip', 'Kamion'))
);

CREATE TABLE Specijalno_Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Namena VARCHAR2(50) CHECK (Namena IN ('Za vodu', 'Za hemiju', 'Za sator', 'Mobilna laboratorija'))
);

CREATE TABLE Sanitetsko_Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

-- Dodeljivanje vozila
CREATE TABLE Dodeljuje_Vozilo_Pojedincu (
    Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    JMBG_Pojedinca CHAR(13) REFERENCES Zaposlen(JMBG),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    PRIMARY KEY (Registarska_Oznaka, JMBG_Pojedinca, Datum_Od)
);

CREATE TABLE Dodeljuje_Vozilo_Jedinici (
    Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    PRIMARY KEY (Registarska_Oznaka, Id_Jedinice, Datum_Od)
);

CREATE TABLE Oprema_Licna_Zastita (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj)
);

CREATE TABLE Oprema_Tehnicka (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj)
);

CREATE TABLE Oprema_Zalihe (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Kolicina NUMBER
);

CREATE TABLE Oprema_Medicinska (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj)
);

CREATE TABLE Predstavnik_Sluzbe (
    Id NUMBER PRIMARY KEY,
    Id_Sluzbe NUMBER REFERENCES Spoljna_Sluzba(Id),
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Pozicija VARCHAR2(50),
    Telefon VARCHAR2(20),
    Email VARCHAR2(100)
);

CREATE TABLE Angazovanje_Saradnje (
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Id_Predstavnika NUMBER REFERENCES Predstavnik_Sluzbe(Id),
    Uloga VARCHAR2(50),
    PRIMARY KEY (Id_Vanredne_Situacije, Id_Predstavnika)
);
