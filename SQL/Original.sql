CREATE TABLE Vanredna_Situacija (
    Id NUMBER PRIMARY KEY,
    Datum_Od DATE NOT NULL,
    Datum_Do DATE NOT NULL,
    Broj_Ugrozenih_Osoba NUMBER,
    Nivo_Opasnosti NUMBER,
    Opstina VARCHAR2(100),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500),

    CONSTRAINT fk_prijava
        FOREIGN KEY (Prijava_Id)
        REFERENCES Prijava(Id)
);

CREATE TABLE Prijava (
    Id NUMBER PRIMARY KEY,
    IdVanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Datum_I_Vreme DATE NOT NULL,
    Tip VARCHAR2(50),
    Ime VARCHAR2(50),
    Kontakt VARCHAR2(50),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500),
    JMBG_Dispecera CHAR(13) REFERENCES Zaposlen(JMBG),
    Prioritet NUMBER
);

CREATE TABLE Intervencija (
    Id NUMBER PRIMARY KEY,
    Datum_I_Vreme DATE NOT NULL,
    Lokacija VARCHAR2(100),
    Status VARCHAR2(50),
    Korisceni_Resursi VARCHAR2(200),
    Broj_Spasenih NUMBER,
    Broj_Povredjenih NUMBER,
    Uspesnost NUMBER
);

CREATE TABLE Zaposlen (
    JMBG CHAR(13) PRIMARY KEY,
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Datum_Rodjenja DATE,
    Pol CHAR(1) CHECK (Pol IN ('M','Z')),
    Kontakt_Telefon VARCHAR2(20),
    Email VARCHAR2(100),
    Adresa_Stanovanja VARCHAR2(200),
    Datum_Zaposlenja DATE,
    Tip VARCHAR2(50)
);

CREATE TABLE Analiticar (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Softver VARCHAR2(100)
);

CREATE TABLE Koordinator (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Timova NUMBER
);

CREATE TABLE Operativni_Radnik (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Sati NUMBER,
    Fizicka_Spremnost VARCHAR2(50),
    JedBrojIJ NUMBER
);

CREATE TABLE Ekspertize (
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Tip VARCHAR2(50),
    PRIMARY KEY (JMBG, Tip)
);

CREATE TABLE Specijalizacija (
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Tip VARCHAR2(50),
    PRIMARY KEY (JMBG, Tip)
);

CREATE TABLE Interventna_Jedinica (
    Jedinstveni_Broj NUMBER PRIMARY KEY,
    Naziv VARCHAR2(100),
    Broj_Clanova NUMBER,
    JMBG_Komandira CHAR(13) REFERENCES Zaposlen(JMBG),
    Baza VARCHAR2(100),
    OpremaId NUMBER,
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id),
    Id_Vozila NUMBER REFERENCES Vozilo(ID_Vozila)
);

CREATE TABLE Vozilo (
    Id_Vozila NUMBER PRIMARY KEY,
    Registarska_Oznaka VARCHAR2(20) UNIQUE,
    Proizvodjac VARCHAR2(50),
    Tip VARCHAR2(50),
    Status VARCHAR2(50),
    Lokacija VARCHAR2(100)
);

CREATE TABLE Oprema (
    Id NUMBER PRIMARY KEY,
    Naziv VARCHAR2(100),
    Tip VARCHAR2(50),
    Status VARCHAR2(50),
    DatumNabavke DATE,
    IdInterventneJedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    TipOpreme VARCHAR2(50)
);

CREATE TABLE LicnaZastita (
    Id NUMBER PRIMARY KEY REFERENCES Oprema(Id)
);

CREATE TABLE Tehnicka_Oprema (
    Id NUMBER PRIMARY KEY REFERENCES Oprema(Id)
);

CREATE TABLE Zalihe (
    Id NUMBER PRIMARY KEY REFERENCES Oprema(Id)
);

CREATE TABLE Medicinska_Oprema (
    Id NUMBER PRIMARY KEY REFERENCES Oprema(Id)
);

CREATE TABLE Specijalna (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Id_Vozila NUMBER REFERENCES Vozilo(Id_Vozila),
    Tip VARCHAR2(50)
);

CREATE TABLE Sanitetska (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Id_Vozila NUMBER REFERENCES Vozilo(Id_Vozila)
);

CREATE TABLE Hemija (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

CREATE TABLE Voda (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

CREATE TABLE Mobilna_Laboratorija (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

CREATE TABLE Sator (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

CREATE TABLE Sertifikat (
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Tip VARCHAR2(50),
    Institucija VARCHAR2(100),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    PRIMARY KEY (JMBG, Tip, Institucija)
);

CREATE TABLE Ucestvuje (
    IdIntervencije NUMBER REFERENCES Intervencija(Id),
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Id_VandredneSituacije NUMBER REFERENCES Vandredna_Situacija(Id),
    PRIMARY KEY (IdIntervencije, Id_Jedinice, Id_VandredneSituacije)
);

CREATE TABLE Je_Deo (
    Id_Vandredne_Situacije NUMBER REFERENCES Vandredna_Situacija(Id),
    Id_Intervencije NUMBER REFERENCES Intervencija(Id),
    PRIMARY KEY (Id_Vandredne_Situacije, Id_Intervencije)
);

CREATE TABLE Dodeljuje_Se (
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Datum_Od DATE,
    Datum_Do DATE,
    PRIMARY KEY (JMBG, Datum_Od)
);

CREATE TABLE Sektor (
    Id_Sektora NUMBER PRIMARY KEY,
    Tip VARCHAR2(50),
    Uloga VARCHAR2(50),
    Id_Vandredne_Situacije NUMBER REFERENCES Vandredna_Situacija(Id),
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Pozicija VARCHAR2(50),
    Telefon VARCHAR2(20),
    Email VARCHAR2(100)
);

CREATE TABLE Saradjuje (
    Id_Vandredne_Situacije NUMBER REFERENCES Vandredna_Situacija(Id),
    Id_Sektora NUMBER REFERENCES Sektor(Id_Sektora),
    PRIMARY KEY (Id_Vandredne_Situacije, Id_Sektora)
);

CREATE TABLE Dodeljuje (
    Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Pojedinac CHAR(13) REFERENCES Zaposlen(JMBG),
    Datum_Od DATE,
    Datum_Do DATE,
    PRIMARY KEY (Registarska_Oznaka, Id_Jedinice, Datum_Od)
);

CREATE TABLE Dzipovi (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    IdOperativnogRadnika CHAR(13) REFERENCES Operativni_Radnik(JMBG)
);

CREATE TABLE Kamioni (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

CREATE TABLE Daje_Se_Jedinicama (
    Id_Vozila NUMBER REFERENCES Vozilo(Id_Vozila),
    Id_Interventne_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    PRIMARY KEY (Id_Vozila, Id_Interventne_Jedinice)
);
