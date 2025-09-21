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
    Tip VARCHAR2(50),
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
    JMBG_Komandira CHAR(13) REFERENCES Operativni_Radnik(JMBG),
    Baza VARCHAR2(100)
);

CREATE TABLE OpstaIntervetnaJedinica
(
    Jedinstveni_Broj PRIMARY KEY REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
)

CREATE TABLE OpstaIntervetnaJedinica
(
    Jedinstveni_Broj PRIMARY KEY REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Tip VARCHAR2(50),
)

CREATE TABLE Intervencija (
    Id NUMBER PRIMARY KEY,
    Datum_I_Vreme DATE NOT NULL,
    Lokacija VARCHAR2(100),
    Status VARCHAR2(50),
    Broj_Spasenih NUMBER,
    Broj_Povredjenih NUMBER,
    Uspesnost NUMBER
);

CREATE TABLE Prijava (
    Id NUMBER PRIMARY KEY,
    Datum_I_Vreme DATE NOT NULL,
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Tip VARCHAR2(50),
    Ime_Prijavioca VARCHAR2(50),
    Kontakt_Prijavioca VARCHAR2(50),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500),
    JMBG_Dispecera CHAR(13),
    Prioritet NUMBER
);

CREATE TABLE Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY,
    Proizvodjac VARCHAR2(50)
    Status VARCHAR2(50) CHECK (Status IN ('operativno', 'u_kvaru')),
    Lokacija VARCHAR2(100)
);


CREATE TABLE Oprema (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY,
    Naziv VARCHAR2(100),
    Status VARCHAR2(50),
    DatumNabavke DATE,
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
);




---
-- TABELE ZA HIJERARHIJU I VEZNE TABELE
---

-- Uloge Zaposlenih (Nasleđivanje sa 'Zaposlen')
CREATE TABLE Analiticar (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG)
);

CREATE TABLE Koordinator (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Timova NUMBER
);

CREATE TABLE Operativni_Radnik (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Sati NUMBER
    Fizicka_Spremnost VARCHAR2(50),
);
-- Tabela za istoriju uloga
CREATE TABLE Istorija_Uloga_Zaposlenih (
    Id NUMBER PRIMARY KEY,
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Uloga VARCHAR2(50),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
);

CREATE TABLE Ekspertiza (
    Id NUMBER PRIMARY KEY
    JMBG CHAR(13) REFERENCES Analiticar(JMBG) NOT NULL,
    Oblast VARCHAR2(50) NOT NULL,
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
    
);

CREATE TABLE Dzipovi
(
     Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Terensko_Vozilo(Registarska_Oznaka),    
)

CREATE TABLE Kamioni
(
     Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Terensko_Vozilo(Registarska_Oznaka),    
)
CREATE TABLE SpecijalnoVozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Namena VARCHAR2(50) CHECK (Namena IN ('Za vodu', 'Za hemiju', 'Za sator', 'Mobilna laboratorija'))
);

CREATE TABLE Sanitetsko_Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

-- Dodeljivanje vozila
-- CREATE TABLE Dodeljuje_Vozilo_Pojedincu (
--     Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
--     JMBG_Pojedinca CHAR(13) REFERENCES Zaposlen(JMBG),
--     Datum_Od DATE NOT NULL,
--     Datum_Do DATE,
--     PRIMARY KEY (Registarska_Oznaka, JMBG_Pojedinca, Datum_Od)
-- );

-- CREATE TABLE Dodeljuje_Vozilo_Jedinici (
--     Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
--     Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
--     Datum_Od DATE NOT NULL,
--     Datum_Do DATE,
--     PRIMARY KEY (Registarska_Oznaka, Id_Jedinice, Datum_Od)
-- );

--Izmenjeno u 

CREATE TABLE DodeljujeSe (
    Id NUMBER PRIMARY KEY,
    Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    JMBG_Pojedinca CHAR(13) REFERENCES Zaposlen(JMBG),
    IdJedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
);
CREATE TABLE LicnaZastita (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50) CHECK (Tip IN ("Odelo", "Maska", "Kaciga")),
);

CREATE TABLE Tehnicka (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50) CHECK (Tip IN ("Pumpa", "Detektor", "Radio_stanica")),
);

CREATE TABLE Zalihe (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50) CHECK (Tip IN ("Hrana", "Voda", "Sator", "Lek")),
    Kolicina NUMBER
);

CREATE TABLE MedicinskaOprema (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj)
    Tip VARCHAR2(50) CHECK (Tip IN ("Prenosive_nosiljka", "Defibrilator", "Komplet_za_reanimaciju")),
);

CREATE TABLE Predstavnik_Sluzbe (
    JMBG VARCHAR2(13) PRIMARY KEY;
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Pozicija VARCHAR2(50),
    Telefon VARCHAR2(20),
    Email VARCHAR2(100),
    Id_Sluzbe NUMBER REFERENCES Sluzba(Id),
);



CREATE TABLE Ucestvuje(
   Id NUMBER PRIMARY KEY,
   IdInterventneJed NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
   IdVanredneSituacije NUMBER REFERENCES IdVanredneSituacije(Id),
   IdInterventneJed NUMBER REFERENCES Intervencija(Id)
)

CREATE TABLE Ucestvovalo
(
    Id NUMBER PRIMARY KEY,
    Registarska_Oznaka_Vozila VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    IdIntervencije NUMBER REFERENCES Intervencija(Id),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE
)

CREATE TABLE Saradnja 
(
    Id NUMBER PRIMARY KEY,
    Uloga VARCHAR2(50) NOT NULL,
    Id_Sluzbe NUMBER REFERENCES Sluzba(Id),
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id)
)

CREATE TABLE SoftverAnaliticara
(
    Id NUMBER PRIMARY KEY,
    JMBG_Analiticara VARCHAR2(13) REFERENCES Analiticar(JMBG),
    Naziv VARCHAR2(20) NOT NULL
)

CREATE TABLE Specijalizacija (
    Id NUMBER PRIMARY KEY
    JMBG_Kordinatora CHAR(13) REFERENCES Koordinator(JMBG) NOT NULL,
    Oblast VARCHAR2(50) NOT NULL,
);

