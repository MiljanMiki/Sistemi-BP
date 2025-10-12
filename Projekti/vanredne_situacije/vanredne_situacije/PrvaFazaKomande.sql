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
    Id NUMBER,
    Datum_Od DATE NOT NULL,
    Datum_Do DATE,
    Tip VARCHAR2(50),
    Broj_Ugrozenih_Osoba NUMBER,
    Nivo_Opasnosti VARCHAR2(20) CHECK (Nivo_Opasnosti IN('nizak', 'srednji','visok'));,
    Opstina VARCHAR2(50),
    Lokacija VARCHAR2(100),
    Opis VARCHAR2(500)
);

--op radnik i interventna jedinica se referenciraju medjusobno, pa je bolje da ovi FKs ostanu nullable,
--da ne bi bilo greske prilikom dodavanja
CREATE TABLE Interventna_Jedinica (
    Jedinstveni_Broj NUMBER ,
    Naziv VARCHAR2(100),
    Broj_Clanova NUMBER,
    JMBG_Komandira CHAR(13) REFERENCES Operativni_Radnik(JMBG),
    Baza VARCHAR2(100)
);

CREATE TABLE OpstaIntervetnaJedinica
(
    Jedinstveni_Broj NUMBER PRIMARY KEY REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
)

CREATE TABLE SpecijalnaIntervetnaJedinica
(
    Jedinstveni_Broj NUMBER PRIMARY KEY REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    TipSpecijalneJedinice VARCHAR2(50)
)

CREATE TABLE Intervencija (
    Id NUMBER PRIMARY KEY,
    Datum_I_Vreme DATE NOT NULL,
    Lokacija VARCHAR2(100),
    Status VARCHAR2(50),
    Broj_Spasenih NUMBER,
    Broj_Povredjenih NUMBER,
    Uspesnost NUMBER,
    Resursi VARCHAR2(50)

);

CREATE TABLE Prijava (
    Id NUMBER PRIMARY KEY,
    Datum_I_Vreme DATE NOT NULL,
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

--da li id_jedinice da bude not null?mozda moze da bude null, ako je nijedna jedinica ne koristi trenutno
CREATE TABLE Oprema (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY,
    Naziv VARCHAR2(100),
    Status VARCHAR2(50),
    DatumNabavke DATE,
    Id_Jedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
);

CREATE TABLE Servisi (
    Id NUMBER PRIMARY KEY,
    Registarska_Oznaka_Vozila VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    Tip VARCHAR2(20),
    Datum DATE
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

--op radnik i interventna jedinica se referenciraju medjusobno, pa je bolje da ovi FKs ostanu null,
--da ne bi bilo greske prilikom dodavanja
CREATE TABLE Operativni_Radnik (
    JMBG CHAR(13) PRIMARY KEY REFERENCES Zaposlen(JMBG),
    Broj_Sati NUMBER,
    Fizicka_Spremnost VARCHAR2(50),
    Jedinica_Id NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj)
);
-- Tabela za istoriju uloga
CREATE TABLE Istorija_Uloga_Zaposlenih (
    Id NUMBER PRIMARY KEY,
    JMBG CHAR(13) REFERENCES Zaposlen(JMBG),
    Uloga VARCHAR2(50),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE
);

CREATE TABLE Ekspertiza (
    Id NUMBER PRIMARY KEY,
    JMBG CHAR(13) REFERENCES Analiticar(JMBG) NOT NULL,
    Oblast VARCHAR2(50) NOT NULL,
);

--nzm da li ovde treba da se stave za jmbg,naziv i institucija not null, jer ako je stavljeno
--za primary key podrazumeva se (valjda?)
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
     Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Terensko_Vozilo(Registarska_Oznaka) 
)

CREATE TABLE Kamioni
(
     Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Terensko_Vozilo(Registarska_Oznaka)   
)
CREATE TABLE SpecijalnoVozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka),
    Namena VARCHAR2(50) CHECK (Namena IN ('Za_vodu', 'Za_hemiju', 'Za_sator', 'Mobilna_laboratorija'))
);

CREATE TABLE Sanitetsko_Vozilo (
    Registarska_Oznaka VARCHAR2(20) PRIMARY KEY REFERENCES Vozilo(Registarska_Oznaka)
);

--sluzba i predstavnik se medjusobno referenciraju, moze ovde da se stavi not_null za id sluzbe, ali onda
--bi se prvo uvek kreirala sluzba pa njen predstavnik
--najprostije da oba medjusobno budu nullable
CREATE TABLE Sluzba (
    Id_Sektora  NUMBER PRIMARY KEY,
    Tip VARCHAR2(50),
    Uloga VARCHAR2(50),
    JMBGPredstavnika VARCHAR2(13) REFERENCES Predstavnik_Sluzbe(JMBG)
);

--samo reg treba da bude not null, jmbg/id moraju da budu nullable jer se samo
--jednom dodeljuje
CREATE TABLE DodeljujeSe (
    Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    Registarska_Oznaka VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    JMBG_Pojedinca CHAR(13) REFERENCES Zaposlen(JMBG),
    IdJedinice NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE
);

--za sve ove 4 tabele ima duplikati constraints...ukloni ih
CREATE TABLE LicnaZastita (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50)-- CHECK (Tip IN ('Odelo', 'Maska', 'Kaciga'))
);

CREATE TABLE Tehnicka (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50) --CHECK (Tip IN ('Pumpa', 'Detektor', 'Radio_stanica'))
);

CREATE TABLE Zalihe (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50) --CHECK (Tip IN ('Hrana', 'Voda', 'Sator', 'Lek')),
    Kolicina NUMBER
);

CREATE TABLE MedicinskaOprema (
    Serijski_Broj VARCHAR2(50) PRIMARY KEY REFERENCES Oprema(Serijski_Broj),
    Tip VARCHAR2(50)-- CHECK (Tip IN ('Prenosive_nosiljka', 'Defibrilator', 'Komplet_za_reanimaciju'))
);

--sluzba i predstavnik se medjusobno referenciraju, moze ovde da se stavi not_null za id sluzbe, ali onda
--bi se prvo uvek kreirala sluzba pa njen predstavnik
--najprostije da oba medjusobno budu nullable
CREATE TABLE Predstavnik_Sluzbe (
    JMBG VARCHAR2(13) PRIMARY KEY,
    Ime VARCHAR2(50),
    Prezime VARCHAR2(50),
    Pozicija VARCHAR2(50),
    Telefon VARCHAR2(20),
    Email VARCHAR2(100),
    Id_Sluzbe NUMBER REFERENCES Sluzba(Id)
);



CREATE TABLE Ucestvuje(
   Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
   IdInterventneJed NUMBER REFERENCES Interventna_Jedinica(Jedinstveni_Broj),
   IdVanredneSituacije NUMBER REFERENCES Vanredna_Situacija(Id),
   IdIntervencije NUMBER REFERENCES Intervencija(Id)
)

--necu da diram Datum_Do
CREATE TABLE Ucestvovalo
(
    Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    Registarska_Oznaka_Vozila VARCHAR2(20) REFERENCES Vozilo(Registarska_Oznaka),
    IdIntervencije NUMBER REFERENCES Intervencija(Id),
    Datum_Od DATE NOT NULL,
    Datum_Do DATE
)

CREATE TABLE Saradnja 
(
    Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    Uloga VARCHAR2(50) NOT NULL,
    Id_Sluzbe NUMBER REFERENCES Sluzba(Id),
    Id_Vanredne_Situacije NUMBER REFERENCES Vanredna_Situacija(Id)
)

CREATE TABLE SoftverAnaliticara
(
    Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    JMBG_Analiticara VARCHAR2(13) REFERENCES Analiticar(JMBG),
    Naziv VARCHAR2(20) NOT NULL
)

CREATE TABLE Specijalizacija (
    Id NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    JMBG_Kordinatora CHAR(13) REFERENCES Koordinator(JMBG) NOT NULL,
    Oblast VARCHAR2(50) NOT NULL,
);

--************************************************CONSTRAINTS*********************************************************

ALTER TABLE ZAPOSLEN
ADD CONSTRAINT CHK_ZAPOSLEN_JMBG
CHECK (LENGTH(JMBG) = 13 AND TRANSLATE(JMBG, '0123456789', '0') = RPAD('0',13,'0'))

ALTER TABLE PREDSTAVNIK_SLUZBE
ADD CONSTRAINT CHK_PREDSTAVNIK_SLUZBE_JMBG
CHECK (LENGTH(JMBG) = 13 AND TRANSLATE(JMBG, '0123456789', '0') = RPAD('0',13,'0'))


ALTER TABLE ZAPOSLEN
ADD CONSTRAINT CHK_ZAPOSLEN_TELEFON
CHECK (REGEXP_LIKE(KONTAKT_TELEFON, '^[0-9]+$'));


ALTER TABLE INTERVENCIJA--good
ADD CONSTRAINT CHK_INTERVENCIJA_STATUS
CHECK (STATUS IN ('U_toku', 'Zavrsena'));


ALTER TABLE VOZILO
ADD CONSTRAINT CHK_VOZILO_STATUS--good
CHECK (STATUS IN ('Operativno', 'U_kvaru'));


ALTER TABLE LICNAZASTITA
ADD CONSTRAINT CHK_LICNAZASTITA_TIP--good
CHECK (TIP IN ('Odelo', 'Maska', 'Kaciga'));

ALTER TABLE TEHNICKA
ADD CONSTRAINT CHK_TEHNICKA_TIP--good
CHECK (TIP IN ('Pumpa', 'Detektor', 'Radio_stanica'));

ALTER TABLE ZALIHE--U BAZI STOJI LEK!!!
ADD CONSTRAINT CHK_ZALIHE_TIP
CHECK (TIP IN ('Sator', 'Hrana', 'Voda', 'Lekovi'));

ALTER TABLE MEDICINSKAOPREMA--treba Prenosiva_nosiljka...
ADD CONSTRAINT CHK_MEDICINSKAOPREMA_TIP
CHECK (TIP IN ('Prenosiva_nosiljka', 'Defibrilator', 'Komplet_za_reanimaciju'));



--************************************************SEKVENCE*********************************************************

CREATE SEQUENCE SekvencaEkspertiza START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_Ime
BEFORE INSERT ON Ekspertiza
FOR EACH ROW
BEGIN
    SELECT SekvencaEkspertiza.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaDodeljujeSe START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_DodeljujeSe
BEFORE INSERT ON DODELJUJESE
FOR EACH ROW
BEGIN
    SELECT SekvencaDodeljujeSe.NEXTVAL INTO :NEW.ID FROM dual;
END;
---
CREATE SEQUENCE SekvencaIntervencija START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_Intervencija
BEFORE INSERT ON Intervencija
FOR EACH ROW
BEGIN
    SELECT SekvencaIntervencija.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaIstorijaZaposlenih START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_istorij
BEFORE INSERT ON Istorija_Uloga_Zaposlenih
FOR EACH ROW
BEGIN
    SELECT SekvencaIstorijaZaposlenih.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaPrijava START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_prijava
BEFORE INSERT ON Prijava
FOR EACH ROW
BEGIN
    SELECT SekvencaPrijava.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaSaradnja START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_saradnja
BEFORE INSERT ON Saradnja
FOR EACH ROW
BEGIN
    SELECT SekvencaSaradnja.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaSluzba START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_sluzba
BEFORE INSERT ON Sluzba
FOR EACH ROW
BEGIN
    SELECT SekvencaSluzba.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaSoftverAnaliticar START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_sAnaliticar
BEFORE INSERT ON SoftverAnaliticara
FOR EACH ROW
BEGIN
    SELECT SekvencaSoftverAnaliticar.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaSpecijalizacija START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_specijalizacija
BEFORE INSERT ON Specijalizacija
FOR EACH ROW
BEGIN
    SELECT SekvencaSpecijalizacija.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaUcestvovalo START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_ucestvovalo
BEFORE INSERT ON Ucestvovalo
FOR EACH ROW
BEGIN
    SELECT SekvencaUcestvovalo.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaUcestvuje START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_ucestvuje
BEFORE INSERT ON Ucestvuje
FOR EACH ROW
BEGIN
    SELECT SekvencaUcestvuje.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaVanSituacija START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_vanSituacija
BEFORE INSERT ON Vanredna_situacija
FOR EACH ROW
BEGIN
    SELECT SekvencaVanSituacija.NEXTVAL INTO :NEW.ID FROM dual;
END;

CREATE SEQUENCE SekvencaInterventnaJedinica START WITH 1 INCREMENT BY 1  
CREATE OR REPLACE TRIGGER trg_interventaJedinica
BEFORE INSERT ON Interventna_jedinica
FOR EACH ROW
BEGIN
    SELECT SekvencaInterventnaJedinica.NEXTVAL INTO :NEW.JEDINSTVENI_BROJ FROM dual;
END;

--Unique indeksi za komandira i predstacnika 1:1
CREATE UNIQUE INDEX jmbg_predstavnik_sluzba
ON Sluzba (CASE WHEN JMBGPREDSTAVNIKA IS NOT NULL THEN JMBGPREDSTAVNIKA END);

CREATE UNIQUE INDEX jmbg_komandira_ij
ON interventna_jedinica (CASE WHEN JMBG_Komandira IS NOT NULL THEN JMBG_Komandira END);


--*************************************DODAVANJE NOT NULL TABELAMA(Kasnije ispravke)*************************************

ALTER TABLE Interventna_Jedinica--AJDE OVO POSLEDNJE...
MODIFY (JMBG_Komandira CHAR(13) NOT NULL);

--ipak bolje da bude nullable, da moze bilo ko da uzme opremu
ALTER TABLE Oprema
MODIFY(ID_JEDINICE NUMBER NOT NULL)

ALTER TABLE Servisi
MODIFY(Registarska_Oznaka_Vozila VARCHAR2(20) NOT NULL);


ALTER TABLE Istorija_Uloga_Zaposlenih
MODIFY(JMBG CHAR(13) NOT NULL);

ALTER TABLE DodeljujeSe
MODIFY(Registarska_Oznaka VARCHAR2(20) NOT NULL);

ALTER TABLE Ucestvuje
MODIFY( IdInterventneJed NUMBER NOT NULL,IdVanredneSituacije NUMBER NOT NULL, IdIntervencije NUMBER NOT NULL);

--i datum_do moze da bude not null, zavisi od implementacije
ALTER TABLE Ucestvovalo
MODIFY(Registarska_Oznaka_Vozila VARCHAR2(20) NOT NULL,IdIntervencije NUMBER NOT NULL);

ALTER TABLE Saradnja
MODIFY(Id_Sluzbe NUMBER NOT NULL, Id_Vanredne_Situacije NUMBER NOT NULL);

ALTER TABLE SoftverAnaliticara
MODIFY(JMBG_Analiticara VARCHAR2(13) NOT NULL);

--*************************************dodatni chekovi za neka polja*************************************

ALTER TABLE VANREDNA_SITUACIJA
ADD CONSTRAINT CHK_VANREDNASITUACIJA_BROJUGROZENIH
CHECK(BROJ_UGROZENIH_OSOBA>=0);

ALTER TABLE INTERVENTNA_JEDINICA
ADD CONSTRAINT CHK_INTERVENTNAJEDINICA_BROJCLANOVA
CHECK(BROJ_CLANOVA>=0);

ALTER TABLE INTERVENCIJA
ADD CONSTRAINT CHK_INTERVENCIJA_BROJSPASENIH
CHECK(BROJ_SPASENIH>=0);

ALTER TABLE INTERVENCIJA
ADD CONSTRAINT CHK_INTERVENCIJA_BROJPOVREDJENIH
CHECK(BROJ_POVREDJENIH>=0);

