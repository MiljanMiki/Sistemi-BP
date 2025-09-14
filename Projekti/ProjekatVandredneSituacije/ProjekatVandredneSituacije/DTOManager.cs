using FluentNHibernate.Conventions;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping;
using ProjekatVandredneSituacije;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije
{
    internal class DTOMAnager
    {
        #region VandrednaSituacija

        public static void obrisiVandrednuSituaciju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                VanrednaSituacija vandredna = s.Load<VanrednaSituacija>(id);

                s.Delete(vandredna);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }

        public static void DodajVandrednuSituaciju(VandrednaSituacijaBasic vs)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Entiteti.VanrednaSituacija v = new Entiteti.VanrednaSituacija();
                v.Id = vs.Id;
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Nivo_Opasnosti = vs.Nivo_Opasnosti;
                v.Opstina = vs.Opstina;
                v.Lokacija = vs.Lokacija;
                v.Opis = vs.Opis;
                v.Prijava_ID = s.Load<Prijava>(vs.IdPrijava);
                s.SaveOrUpdate(v);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static VandrednaSituacijaPregled VratiVandrednuSituaciju(int id)
        {
            VandrednaSituacijaPregled v = new VandrednaSituacijaPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                VanrednaSituacija vs = s.Load<VanrednaSituacija>(id);

                v.Id = vs.Id;
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Opstina = vs.Opstina;
                v.Opis = vs.Opis;
                v.IdPrijava = vs.Prijava_ID.Id;
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return v;

        }
        public static IList<VandrednaSituacijaBasic> VratiVandredneSituacije()
        {
            List<VandrednaSituacijaBasic> vs = new List<VandrednaSituacijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.VanrednaSituacija> v = from o in s.Query<VanrednaSituacija>()
                                                  select o;

                foreach (VanrednaSituacija vandredna in v)
                {
                    vs.Add(new VandrednaSituacijaBasic(vandredna.Id, vandredna.Datum_Od, vandredna.Datum_Do, vandredna.Tip, vandredna.Broj_Ugrozenih_Osoba, vandredna.Nivo_Opasnosti,
                        vandredna.Opstina, vandredna.Lokacija, vandredna.Opis, vandredna.Prijava_ID.Id));
                }
            }
            catch
            {

            }
            return vs;
        }
        public static void IzmeniVandrednuSituaciju(VandrednaSituacijaBasic vs)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                VanrednaSituacija v= s.Load<VanrednaSituacija>(vs.Id);
                v.Id = vs.Id;
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Opstina = vs.Opstina;
                v.Opis = vs.Opis;
                v.Prijava_ID = s.Load<Prijava>(vs.IdPrijava);

                s.Update(v);
                s.Flush();
                s.Close();
            }
            catch(Exception e)
            {

            }
        }


        #endregion

        #region IntervetnaJedinica
        public void DodajOpstuIntervetnuJedinicu(InterventnaJedinicaBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OpstaIntervetnaJed ij = new OpstaIntervetnaJed();
                ij.Jedinstveni_Broj = i.Jedinstveni_Broj;
                ij.Naziv = i.Naziv;
                ij.BrojClanova= i.BrojClanova;
                ij.Komandir = s.Load<OperativniRadnik>(i.Komandir);
                ij.Baza= i.Baza;
                s.SaveOrUpdate(ij);
                s.Flush();
                s.Close();

            }
            catch(Exception e)
            {

            }
        }

        public static void ObrisiOpstuInterventnuJedinicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OpstaIntervetnaJed ij = s.Load<OpstaIntervetnaJed>(id);
                s.Delete(ij);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void izmeniOpstuInterventnuJedinicu(OpstaIntervetnaJed i)
            {
                try
                {
                    ISession s = DataLayer.GetSession();
                    OpstaIntervetnaJed ij = s.Load<OpstaIntervetnaJed>(i.Jedinstveni_Broj);
                    ij.Jedinstveni_Broj = i.Jedinstveni_Broj;
                    ij.Naziv = i.Naziv;
                    ij.BrojClanova = i.BrojClanova;
                    ij.Komandir = s.Load<OperativniRadnik>(i.Komandir);
                    ij.Baza = i.Baza;
                    s.Update(ij);
                    s.Flush();
                    s.Close();
                }
                catch (Exception e)
                {
                }
        }
        public static IList<OpstaInterventnaJedBasic> VratiOpstejedinice()
        {
            List<OpstaInterventnaJedBasic> sveJedinice = new List<OpstaInterventnaJedBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.OpstaIntervetnaJed> p = from o in s.Query<OpstaIntervetnaJed>()
                                                  select o;

                foreach (OpstaIntervetnaJed o in p)
                {
                    
                    sveJedinice.Add(new OpstaInterventnaJedBasic(o.Jedinstveni_Broj, o.Naziv, o.BrojClanova, o.Komandir.JMBG, o.Baza));
                }
            }
            catch (Exception e)
            {
            }
            return sveJedinice;
        }

        public static OpstaInterventnaJedBasic VratiOpstuJedinicu(int id)
        {
            OpstaInterventnaJedBasic o = new OpstaInterventnaJedBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                OpstaIntervetnaJed ij = s.Load<OpstaIntervetnaJed>(id);
                o.Jedinstveni_Broj = ij.Jedinstveni_Broj;
                o.Naziv = ij.Naziv;
                o.BrojClanova = ij.BrojClanova;
                o.Komandir = ij.Komandir.JMBG;
                o.Baza = ij.Baza;
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return o;
        }


        public void DodajSpecijalnuIntervetnuJedinicu(SpecijalnaInterventnaJedinicaBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaInterventna ij = new SpecijalnaInterventna();
                ij.Jedinstveni_Broj = i.Jedinstveni_Broj;
                ij.Naziv = i.Naziv;
                ij.BrojClanova = i.BrojClanova;
                ij.Komandir = s.Load<OperativniRadnik>(i.Komandir);
                ij.Baza = i.Baza;
                s.SaveOrUpdate(ij);
                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {

            }
        }

        public static void ObrisiSpecijalnuInterventnuJedinicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaInterventna ij = s.Load<SpecijalnaInterventna>(id);
                s.Delete(ij);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void izmeniSpecijalnuInterventnuJedinicu(SpecijalnaInterventnaJedinicaBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaInterventna ij = s.Load<SpecijalnaInterventna>(i.Jedinstveni_Broj);
                ij.Jedinstveni_Broj = i.Jedinstveni_Broj;
                ij.Naziv = i.Naziv;
                ij.BrojClanova = i.BrojClanova;
                ij.Komandir = s.Load<OperativniRadnik>(i.Komandir);
                ij.Baza = i.Baza;
                ij.TipSpecijalneJedinice = i.TipSpecijalneJed;

                s.Update(ij);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
            }
        }
        public static IList<SpecijalnaInterventnaJedinicaBasic> VratiSpecijalneJedinice()
        {
            List<SpecijalnaInterventnaJedinicaBasic> sveJedinice = new List<SpecijalnaInterventnaJedinicaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.SpecijalnaInterventna> p = from o in s.Query<SpecijalnaInterventna>()
                                                             select o;

                foreach (SpecijalnaInterventna o in p)
                {

                    sveJedinice.Add(new SpecijalnaInterventnaJedinicaBasic(o.Jedinstveni_Broj, o.Naziv, o.BrojClanova, o.Komandir.JMBG, o.Baza, o.TipSpecijalneJedinice));
                }
            }
            catch (Exception e)
            {
            }
            return sveJedinice;
        }

        public static SpecijalnaInterventnaJedinicaBasic VratiSpecijalnuJedinicu(int id)
        {
            SpecijalnaInterventnaJedinicaBasic o = new SpecijalnaInterventnaJedinicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaInterventna ij = s.Load<SpecijalnaInterventna>(id);
                o.Jedinstveni_Broj = ij.Jedinstveni_Broj;
                o.Naziv = ij.Naziv;
                o.BrojClanova = ij.BrojClanova;
                o.Komandir = ij.Komandir.JMBG;
                o.Baza = ij.Baza;
                o.TipSpecijalneJed = ij.TipSpecijalneJedinice;
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return o;
        }

        public static IList<InterventnaJedinicaBasic> VratiSveJedinice()
        {
            List<InterventnaJedinicaBasic> sveJedinice = new List<InterventnaJedinicaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.InterventnaJedinica> p = from o in s.Query<InterventnaJedinica>()
                                                             select o;
                foreach (InterventnaJedinica o in p)
                {
                    if (o is OpstaIntervetnaJed)
                    {
                        OpstaIntervetnaJed oi = (OpstaIntervetnaJed)o;
                        sveJedinice.Add(new OpstaInterventnaJedBasic(oi.Jedinstveni_Broj, oi.Naziv, oi.BrojClanova, oi.Komandir.JMBG, oi.Baza));
                    }
                    else
                    {
                        SpecijalnaInterventna si = (SpecijalnaInterventna)o;
                        sveJedinice.Add(new SpecijalnaInterventnaJedinicaBasic(si.Jedinstveni_Broj, si.Naziv, si.BrojClanova, si.Komandir.JMBG, si.Baza, si.TipSpecijalneJedinice));
                    }
                }
            }
            catch (Exception e)
            {
            }
            return sveJedinice;
        }
        #endregion


        #region Intervencija
        public static void DodajIntervenciju(IntervencijaBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija intervencija = new Intervencija();
                intervencija.Id = i.ID;
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
                intervencija.Broj_Povredjenih = i.Broj_Povredjenih;
                intervencija.Uspesnost = i.Uspesnost;
                s.Save(intervencija);
                s.Flush();
                s.Close();
            }
            catch(Exception e)
            {

            }
        }

        public static void ObrisiIntervenciju()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija i = s.Load<Intervencija>(1);
                s.Delete(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void IzmeniIntervenciju(IntervencijaBasic i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija intervencija = s.Load<Intervencija>(i.ID);
                intervencija.Id = i.ID;
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
                intervencija.Broj_Povredjenih = i.Broj_Povredjenih;
                intervencija.Uspesnost = i.Uspesnost;
                s.Update(intervencija);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
            }
        }
        public static IList<IntervencijaBasic> VratiIntervencije()
        {
            List<IntervencijaBasic> sveIntervencije = new List<IntervencijaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Intervencija> p = from o in s.Query<Intervencija>()
                                                  select o;
                foreach (Intervencija i in p)
                {
                    sveIntervencije.Add(new IntervencijaBasic(i.Id, i.Datum_I_Vreme, i.Lokacija, i.Status, i.Broj_Spasenih, i.Broj_Povredjenih, i.Uspesnost));
                }
            }
            catch (Exception e)
            {
            }
            return sveIntervencije;
        }

        public static IntervencijaBasic VratiIntervenciju(int id)
        {
            IntervencijaBasic i = new IntervencijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija intervencija = s.Load<Intervencija>(id);
                i.ID = intervencija.Id;
                i.Datum_I_Vreme = intervencija.Datum_I_Vreme;
                i.Lokacija = intervencija.Lokacija;
                i.Status = intervencija.Status;
                i.Broj_Spasenih = intervencija.Broj_Spasenih;
                i.Broj_Povredjenih = intervencija.Broj_Povredjenih;
                i.Uspesnost = intervencija.Uspesnost;
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return i;
        }

        #endregion
        #region Prijava

        public static void DodajPrijavu(PrijavaBasic pr)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                Entiteti.Prijava p = new Entiteti.Prijava();
                p.Id = pr.Id;
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Id_VandrednaSituacija = s.Load<Entiteti.VanrednaSituacija>(pr.IdVandrednaSituacija.Value);
                p.Tip = pr.Tip;
                p.Ime_Prijavioca = pr.Ime_Prijavioca;
                p.Kontakt = pr.Kontakt_Prijavioca;
                p.Lokacija = pr.Lokacija;
                p.Opis = pr.Opis;
                p.JMBG_Dispecer = pr.JMBG_Dispecer;
                p.Prioritet = pr.Prioritet;

                s.SaveOrUpdate(p);

                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiPrijavu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prijava p = s.Load<Prijava>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniPrijavu(PrijavaBasic pr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Entiteti.Prijava p = s.Load<Prijava>(pr.Id);
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Id_VandrednaSituacija = s.Load<Entiteti.VanrednaSituacija>(pr.IdVandrednaSituacija);
                p.Tip = pr.Tip;
                p.Ime_Prijavioca = pr.Ime_Prijavioca;
                p.Kontakt = pr.Kontakt_Prijavioca;
                p.Lokacija = pr.Lokacija;
                p.Opis = pr.Opis;
                p.JMBG_Dispecer = pr.JMBG_Dispecer;
                p.Prioritet = pr.Prioritet;

                s.Update(p);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {

            }
        }

        public static IList<PrijavaBasic> VratiPrijave()
        {
            List<PrijavaBasic> SvePrijave = new List<PrijavaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Prijava> p = from o in s.Query<Prijava>()
                                                  select o;

                foreach (Prijava prijava in p)
                {
                    SvePrijave.Add(new PrijavaBasic(prijava.Id, prijava.Datum_I_Vreme, prijava.Id_VandrednaSituacija.Id, prijava.Tip, prijava.Ime_Prijavioca, prijava.Kontakt,
                        prijava.Lokacija, prijava.Opis, prijava.JMBG_Dispecer, prijava.Prioritet));
                }
            }
            catch (Exception e)
            {

            }

            return SvePrijave;
        }

        public static PrijavaBasic VratiPrijavu(int idPrijave)
        {
            PrijavaBasic p = new PrijavaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prijava pr = s.Load<Prijava>(idPrijave);

                p.Id = pr.Id;
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.IdVandrednaSituacija = pr.Id_VandrednaSituacija.Id;
                p.Tip = pr.Tip;
                p.Ime_Prijavioca = pr.Ime_Prijavioca;
                p.Kontakt_Prijavioca = pr.Kontakt;
                p.Lokacija = pr.Lokacija;
                p.Opis = pr.Opis;
                p.JMBG_Dispecer = pr.JMBG_Dispecer;
                p.Prioritet = pr.Prioritet;

                s.Close();
            }
            catch (Exception e)
            {

            }

            return p;
        }

        #endregion

        #region Analiticar

        public static void DodajAnalitcar(AnaliticarBasic a)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Analiticar analiticar = new Analiticar();
                analiticar.JMBG = a.JMBG;
                analiticar.Ime = a.Ime;
                analiticar.Prezime = a.Prezime;
                analiticar.Datum_Rodjenja = a.Datum_Rodjenja;
                analiticar.Pol = a.Pol;
                analiticar.Kontakt_Telefon = a.Kontakt_Telefon;

                analiticar.Email = a.Email;
                analiticar.AdresaStanovanja = a.AdresaStanovanja;
                analiticar.Datum_Zaposlenja = a.Datum_Zaposlenja;

                s.Save(analiticar);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiAnaliticara(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Analiticar z = s.Load<Analiticar>(JMBG);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniAnaliticar(AnaliticarBasic a)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Analiticar analiticar = s.Load<Analiticar>(a.JMBG);
                analiticar.JMBG= a.JMBG;
                analiticar.Ime = a.Ime;
                analiticar.Prezime = a.Prezime;
                analiticar.Datum_Rodjenja = a.Datum_Rodjenja;
                analiticar.Kontakt_Telefon = a.Kontakt_Telefon;
                analiticar.Email = a.Email;
                analiticar.AdresaStanovanja = a.AdresaStanovanja;
                analiticar.Datum_Zaposlenja = a.Datum_Zaposlenja;

                s.Update(analiticar);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<AnaliticarBasic> VratiAnaliticare()
        {
            List<AnaliticarBasic> sviAnaliticari = new List<AnaliticarBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Analiticar> z = from o in s.Query<Analiticar>()
                                                     select o;
                foreach (Analiticar analiticar in z)
                {
                    sviAnaliticari.Add(new AnaliticarBasic(analiticar.JMBG, analiticar.Ime, analiticar.Prezime, analiticar.Datum_Rodjenja,
                        analiticar.Pol, analiticar.Kontakt_Telefon, analiticar.Email, analiticar.AdresaStanovanja, analiticar.Datum_Zaposlenja));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviAnaliticari;
        }

        public static AnaliticarBasic VratiAnaliticara(string JMBG)
        {
            AnaliticarBasic analiticar = new AnaliticarBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Analiticar a = s.Load<Analiticar>(JMBG);
                analiticar.JMBG = a.JMBG;
                analiticar.Ime = a.Ime;
                analiticar.Prezime = a.Prezime;
                analiticar.Datum_Rodjenja = a.Datum_Rodjenja;
                analiticar.Pol = a.Pol;
                analiticar.Kontakt_Telefon = a.Kontakt_Telefon;
                analiticar.AdresaStanovanja = a.AdresaStanovanja;
                analiticar.Email = a.Email;
                analiticar.Datum_Zaposlenja = a.Datum_Zaposlenja;

                s.Close();
            }
            catch (Exception e)
            {
            }
            return analiticar;
        }
        #endregion



        #region OperativniRadnik


        public static void DodajOperativnogRadnik(OperativniRadnikBasic o)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                OperativniRadnik op = new OperativniRadnik();
                op.JMBG = o.JMBG;
                op.Ime = o.Ime;
                op.Prezime = o.Prezime;
                op.Datum_Rodjenja = o.Datum_Rodjenja;
                op.Pol = o.Pol;
                op.Kontakt_Telefon = o.Kontakt_Telefon;
                op.Email = o.Email;
                op.AdresaStanovanja = o.AdresaStanovanja;
                op.Datum_Zaposlenja = o.Datum_Zaposlenja;
                op.Broj_Sati = o.Broj_Sati;
                op.Fizicka_Spremnost = o.Fizicka_Spremnost;
                op.InterventnaJedinica = s.Load<InterventnaJedinica>(o.IdInterventnaJedinica);

                s.Save(op);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiOperativnogRadnika(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OperativniRadnik op = s.Load<OperativniRadnik>(JMBG);
                s.Delete(op);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniOperativnog(OperativniRadnikBasic o)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OperativniRadnik op = new OperativniRadnik();
                op.JMBG = o.JMBG;
                op.Ime = o.Ime;
                op.Prezime = o.Prezime;
                op.Datum_Rodjenja = o.Datum_Rodjenja;
                op.Pol = o.Pol;
                op.Kontakt_Telefon = o.Kontakt_Telefon;
                op.Email = o.Email;
                op.AdresaStanovanja = o.AdresaStanovanja;
                op.Datum_Zaposlenja = o.Datum_Zaposlenja;
                op.Broj_Sati = o.Broj_Sati;
                op.Fizicka_Spremnost = o.Fizicka_Spremnost;
                op.InterventnaJedinica = s.Load<InterventnaJedinica>(o.IdInterventnaJedinica);

                s.Update(op);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<OperativniRadnikBasic> VratiOperativneRadnike()
        {
            List<OperativniRadnikBasic> sviOp = new List<OperativniRadnikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.OperativniRadnik> z = from o in s.Query<OperativniRadnik>()
                                                           select o;
                foreach (OperativniRadnik o in z)
                {
                    sviOp.Add(new OperativniRadnikBasic(o.JMBG, o.Ime, o.Prezime, o.Datum_Rodjenja,
                        o.Pol, o.Kontakt_Telefon, o.Email, o.AdresaStanovanja, o.Datum_Zaposlenja, o.Broj_Sati, o.Fizicka_Spremnost, o.InterventnaJedinica.Jedinstveni_Broj));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviOp;
        }

        public static IList<OperativniRadnikBasic> VratiOperativneRadnikeIzJedincie(int IdJedinice)
        {
            List<OperativniRadnikBasic> sviOp = new List<OperativniRadnikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.OperativniRadnik> z = from o in s.Query<OperativniRadnik>()
                                                           where o.InterventnaJedinica.Jedinstveni_Broj == IdJedinice
                                                           select o;
                foreach (OperativniRadnik o in z)
                {
                    sviOp.Add(new OperativniRadnikBasic(o.JMBG, o.Ime, o.Prezime, o.Datum_Rodjenja,
                        o.Pol, o.Kontakt_Telefon, o.Email, o.AdresaStanovanja, o.Datum_Zaposlenja, o.Broj_Sati, o.Fizicka_Spremnost, o.InterventnaJedinica.Jedinstveni_Broj));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviOp;
        }

        public static OperativniRadnikBasic VratiOperativnogRadnika(string JMBG)
        {
            OperativniRadnikBasic op = new OperativniRadnikBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                OperativniRadnik o = s.Load<OperativniRadnik>(JMBG);
                op.JMBG = o.JMBG;
                op.Ime = o.Ime;
                op.Prezime = o.Prezime;
                op.Datum_Rodjenja = o.Datum_Rodjenja;
                op.Pol = o.Pol;
                op.Kontakt_Telefon = o.Kontakt_Telefon;
                op.Email = o.Email;
                op.AdresaStanovanja = o.AdresaStanovanja;
                op.Datum_Zaposlenja = o.Datum_Zaposlenja;
                op.Broj_Sati = o.Broj_Sati;
                op.Fizicka_Spremnost = o.Fizicka_Spremnost;
                op.IdInterventnaJedinica = o.InterventnaJedinica.Jedinstveni_Broj;


                s.Close();
            }
            catch (Exception e)
            {
            }
            return op;
        }

        
        #endregion

        #region Kordinator

        public static void DodajKordinatora(KordinatorBasic k)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Kordinator kordinator = new Kordinator();
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;
                s.Save(kordinator);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiKordinatora(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kordinator z = s.Load<Kordinator>(JMBG);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniKordinatora(KordinatorBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kordinator kordinator = s.Load<Kordinator>(k.JMBG);
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;

                s.Update(kordinator);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<KordinatorBasic> VratiKordinatora()
        {
            List<KordinatorBasic> sviKordinatori = new List<KordinatorBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Kordinator> z = from o in s.Query<Kordinator>()
                                                     select o;
                foreach (Kordinator k in z)
                {
                    sviKordinatori.Add(new KordinatorBasic(k.JMBG, k.Ime, k.Prezime, k.Datum_Rodjenja,
                        k.Pol, k.Kontakt_Telefon, k.Email, k.AdresaStanovanja, k.Datum_Zaposlenja, k.BrojTimova));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviKordinatori;
        }

        public static KordinatorBasic VratiKordinator(string JMBG)
        {
            KordinatorBasic kordinator = new KordinatorBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Kordinator k = s.Load<Kordinator>(JMBG);
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;

                s.Close();
            }
            catch (Exception e)
            {
            }
            return kordinator;
        }


        #endregion

        #region Zaposleni
        
        public static IList<ZaposlenBasic> VratiSveZaposlene()
        {
            List<ZaposlenBasic> sviZaposleni = new List<ZaposlenBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Zaposlen> z = from o in s.Query<Zaposlen>()
                                                     select o;
                foreach (Zaposlen zap in z)
                {
                    if (z is Analiticar)
                    {
                        Analiticar analiticar = (Analiticar)z;
                        sviZaposleni.Add(new AnaliticarBasic(analiticar.JMBG,analiticar.Ime,analiticar.Prezime, analiticar.Datum_Rodjenja, analiticar.Pol, analiticar.Kontakt_Telefon,analiticar.Email, analiticar.AdresaStanovanja, analiticar.Datum_Zaposlenja));
                    }
                    else if(z is Kordinator)
                    {
                        Kordinator ko = (Kordinator)z;
                        sviZaposleni.Add(new KordinatorBasic(ko.JMBG, ko.Ime, ko.Prezime, ko.Datum_Rodjenja, ko.Pol, ko.Kontakt_Telefon, ko.Email, ko.AdresaStanovanja, ko.Datum_Zaposlenja, ko.BrojTimova));
                    }
                    else if(z is OperativniRadnik)
                    {
                        OperativniRadnik op = (OperativniRadnik)z;
                        sviZaposleni.Add(new OperativniRadnikBasic(op.JMBG, op.Ime, op.Prezime, op.Datum_Rodjenja, op.Pol, op.Kontakt_Telefon, op.Email, op.AdresaStanovanja, op.Datum_Zaposlenja, op.Broj_Sati, op.Fizicka_Spremnost, op.InterventnaJedinica.Jedinstveni_Broj));
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviZaposleni;
        }
       #endregion


        #region SanitetskaVozila

        public static void DodajSanitetskaVozilo(SanitetskaBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo vozilo = new Vozilo();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Save(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiSanitetskoVozilo(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo z = s.Load<Sanitetska>(RegOznaka);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSanitetskoVozilo(SanitetskaBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sanitetska vozilo = s.Load<Sanitetska>(v.Registarska_Oznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Update(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SanitetskaBasic> VratiSanitetskaVozila()
        {
            List<SanitetskaBasic> svaVozila = new List<SanitetskaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Sanitetska> v = from o in s.Query<Sanitetska>()
                                                     select o;
                foreach (Sanitetska vo in v)
                {
                    svaVozila.Add(new SanitetskaBasic(vo.Registarska_Oznaka, vo.Proizvodjac, vo.Status, vo.Lokacija));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaVozila;
        }

        public static SanitetskaBasic VratiSanitetkoVozilo(string RegOznaka)
        {
            SanitetskaBasic vozilo = new SanitetskaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Sanitetska v = s.Load<Sanitetska>(RegOznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception e)
            {
            }
            return vozilo;
        }
        #endregion



        #region Specijalna

        public static void DodajSpecijalnoVozilo(SpecijalnaVozilaBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaVozila vozilo = new SpecijalnaVozila();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;
                s.Save(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public void ObrisiSpecijalnoVozilo(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaVozila z = s.Load<SpecijalnaVozila>(RegOznaka);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSpecijalnaVozila(SpecijalnaVozilaBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaVozila vozilo = s.Load<SpecijalnaVozila>(v.Registarska_Oznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;

                s.Update(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SpecijalnaVozilaBasic> VratiSpecijalnaVozila()
        {
            List<SpecijalnaVozilaBasic> svaVozila = new List<SpecijalnaVozilaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.SpecijalnaVozila> v = from o in s.Query<SpecijalnaVozila>()
                                                           select o;
                foreach (SpecijalnaVozila vo in v)
                {
                    svaVozila.Add(new SpecijalnaVozilaBasic(vo.Registarska_Oznaka, vo.Proizvodjac, vo.Status, vo.Lokacija, vo.Namena));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaVozila;
        }

        public static SpecijalnaVozilaBasic VratiSpecijalnoVozilo(string RegOznaka)
        {
            SpecijalnaVozilaBasic v = new SpecijalnaVozilaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaVozila vozilo = s.Load<SpecijalnaVozila>(RegOznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;
                s.Close();

            }
            catch (Exception e)
            {
            }
            return v;
        }

        #endregion

        #region Dzipovi
        public static void DodajDzip(DzipoviBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Dzipovi vozilo = new Dzipovi();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;

                s.Save(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiDzip(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Dzipovi z = s.Load<Dzipovi>(RegOznaka);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniDzip(DzipoviBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Dzipovi vozilo = s.Load<Dzipovi>(v.Registarska_Oznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Update(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<DzipoviBasic> VratiDzipove()
        {
            List<DzipoviBasic> svaVozila = new List<DzipoviBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Dzipovi> v = from o in s.Query<Dzipovi>()
                                                  select o;
                foreach (Dzipovi vo in v)
                {
                    svaVozila.Add(new DzipoviBasic(vo.Registarska_Oznaka, vo.Proizvodjac, vo.Status, vo.Lokacija));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaVozila;
        }

        public static DzipoviBasic VratiDzipove(string RegOznaka)
        {
            DzipoviBasic vozilo = new DzipoviBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Dzipovi v = s.Load<Dzipovi>(RegOznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception e)
            {
            }
            return vozilo;
        }
        
        #endregion

        #region Kamioni
        public static void DodajKamion(KamioniBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kamioni vozilo = new Kamioni();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Save(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiKamion(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kamioni z = s.Load<Kamioni>(RegOznaka);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniKamion(KamioniBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kamioni vozilo = s.Load<Kamioni>(v.Registarska_Oznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Update(vozilo);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<KamioniBasic> VratiKamione()
        {
            List<KamioniBasic> svaVozila = new List<KamioniBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Kamioni> v = from o in s.Query<Kamioni>()
                                                  select o;
                foreach (Kamioni vo in v)
                {
                    svaVozila.Add(new KamioniBasic(vo.Registarska_Oznaka, vo.Proizvodjac, vo.Status, vo.Lokacija));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaVozila;
        }

        public static KamioniBasic VratiKamion(string RegOznaka)
        {
            KamioniBasic vozilo = new KamioniBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Kamioni v = s.Load<Kamioni>(RegOznaka);
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception e)
            {
            }
            return vozilo;
        }
        #endregion

        #region Vozilo
        public static IList<VoziloBasic> VratiSvaVozila()
        {
            List<VoziloBasic> svaVozila = new List<VoziloBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Vozilo> z = from o in s.Query<Vozilo>()
                                                 select o;
                foreach (Vozilo vo in z)
                {

                    if (z is Sanitetska)
                    {
                        Sanitetska san = (Sanitetska)z;
                        svaVozila.Add(new SanitetskaBasic(san.Registarska_Oznaka, san.Proizvodjac, san.Status, san.Lokacija));
                    }
                    else if (z is Kamioni)
                    {
                        Kamioni ka = (Kamioni)z;
                        svaVozila.Add(new KamioniBasic(ka.Registarska_Oznaka, ka.Proizvodjac, ka.Status, ka.Lokacija));
                    }
                    else if (z is Dzipovi)
                    {
                        Dzipovi dzipovi = (Dzipovi)z;
                        svaVozila.Add(new DzipoviBasic(dzipovi.Registarska_Oznaka, dzipovi.Proizvodjac, dzipovi.Status, dzipovi.Lokacija));
                    }
                    else if (z is SpecijalnaVozila)
                    {
                        SpecijalnaVozila spec = (SpecijalnaVozila)z;
                        svaVozila.Add(new SpecijalnaVozilaBasic(spec.Registarska_Oznaka, spec.Proizvodjac, spec.Status, spec.Lokacija, spec.Namena));

                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
                return svaVozila;
        }

        #endregion
        #region Sertifikat
        public static void DodajSertifikat(SertifikatBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                SertifikatId id = new SertifikatId();
                Sertifikat sertifikat1 = new Sertifikat();
                id.OperativniRadnik= sess.Load<OperativniRadnik>(s.Id.OperativniRadnik.JMBG);
                id.Naziv = s.Id.Naziv;
                id.Institucija=s.Id.Institucija;

                sertifikat1.Id = id;
                sertifikat1.DatumIzdavanja = s.DatumIzdavanja;
                sertifikat1.DatumVazenja = s.DatumVazenja;





                sess.SaveOrUpdate(sertifikat1);

                sess.Flush();

                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiSertifikat(SertifikatBasic se)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sertifikat z = s.Load<Sertifikat>(se.Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSertifikat(SertifikatPregled sert)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SertifikatId id = new SertifikatId();
                id.OperativniRadnik = s.Load<OperativniRadnik>(sert.Id.OperativniRadnik.JMBG);
                id.Naziv = sert.Id.Naziv;
                id.Institucija = sert.Id.Naziv;
                Sertifikat sertifikat = s.Load<Sertifikat>(id);
                sertifikat.DatumIzdavanja = sert.DatumIzdavanja;
                sertifikat.DatumVazenja = sert.DatumVazenja;


                

                s.SaveOrUpdate(sertifikat);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SertifikatBasic> VratiSertifikate()
        {
            List<SertifikatBasic> sviSertifikati = new List<SertifikatBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sertifikat> sert = from o in s.Query<Sertifikat>()
                                               

                                               select o;

                foreach (Sertifikat se in sert)
                {
                    SertifikatIdBasic id = new SertifikatIdBasic();
                    id.OperativniRadnik = DTOMAnager.VratiOperativnogRadnika(se.Id.OperativniRadnik.JMBG);
                    id.Naziv = se.Id.Naziv;
                    id.Institucija = se.Id.Institucija;
                    sviSertifikati.Add(new SertifikatBasic(id, se.DatumIzdavanja, se.DatumVazenja));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return sviSertifikati;
        }
        public static IList<SertifikatBasic> VratiSertifikate(string JMBGZaposlenog)
        {
            List<SertifikatBasic> sviSertifikati = new List<SertifikatBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sertifikat> sert = from o in s.Query<Sertifikat>()
                                         where o.Id.OperativniRadnik.JMBG == JMBGZaposlenog
                                         
                                         select o;

                foreach (Sertifikat se in sert)
                {
                    SertifikatIdBasic id = new SertifikatIdBasic();
                    id.OperativniRadnik = DTOMAnager.VratiOperativnogRadnika(se.Id.OperativniRadnik.JMBG);
                    id.Naziv = se.Id.Naziv;
                    id.Institucija = se.Id.Institucija;
                    sviSertifikati.Add(new SertifikatBasic(id, se.DatumIzdavanja, se.DatumVazenja));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return sviSertifikati;
        }

        public static SertifikatPregled VratiSertifikat(OperativniRadnikBasic op, string Naziv)
        {
            SertifikatPregled sertifikat = new SertifikatPregled();
            try
            {
                ISession sess = DataLayer.GetSession();
                Sertifikat s = sess.Load<Sertifikat>(op);
                
                sertifikat.DatumIzdavanja = s.DatumIzdavanja;
                sertifikat.DatumVazenja = s.DatumVazenja;
                sess.Close();
            }
            catch (Exception e)
            {
            }
            return sertifikat;
        }

        
        #endregion


        #region Ekspertiza

        public static void DodajEkspertizu(EkspertizaPregled e)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ekspertiza ekspertiza = new Ekspertiza();
                ekspertiza.Id = e.Id;
                ekspertiza.Analiticar = sess.Load<Analiticar>(e.Analiticar);
                ekspertiza.Oblast = e.Oblast;
                sess.Save(ekspertiza);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void ObrisiEkspertizu(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ekspertiza z = s.Load<Ekspertiza>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniEkspertizu(EkspertizaPregled e)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ekspertiza ekspertiza = sess.Load<Ekspertiza>(e.Analiticar);
                ekspertiza.Id= e.Id;
                ekspertiza.Analiticar = sess.Load<Analiticar>(e.Analiticar);
                ekspertiza.Oblast = e.Oblast;
                sess.Update(ekspertiza);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<EkspertizaPregled> VratiEkspertize()
        {
            List<EkspertizaPregled> sveEkspertize = new List<EkspertizaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ekspertiza> z = from o in s.Query<Ekspertiza>()
                                                     select o;
                foreach (Ekspertiza ekspertiza in z)
                {
                    sveEkspertize.Add(new EkspertizaPregled(ekspertiza.Id, ekspertiza.Analiticar.JMBG, ekspertiza.Oblast));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sveEkspertize;
        }
        public static EkspertizaPregled VratiEkspertizu(Analiticar a, string Oblast)
        {
            EkspertizaPregled ekspertiza = new EkspertizaPregled();
            try
            {
                ISession sess = DataLayer.GetSession();
                Ekspertiza e = sess.Load<Ekspertiza>(a);
                ekspertiza.Id = e.Id;
                ekspertiza.Analiticar = e.Analiticar.JMBG;
                ekspertiza.Oblast = e.Oblast;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return ekspertiza;
        }
        #endregion

        #region Specijalizacija

        public static void DodajSpecijalizaciju(SpecijalizacijaPregled sp)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Specijalizacija specijalizacija = new Specijalizacija();
                specijalizacija.Id= sp.Id;
                specijalizacija.Kordinator = sess.Load<Kordinator>(sp.Kordinator);
                specijalizacija.Tip = sp.Tip;
                sess.Save(specijalizacija);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiSpecijalizaciju(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Specijalizacija z = s.Load<Specijalizacija>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSpecijalizaciju(SpecijalizacijaBasic sp)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Specijalizacija specijalizacija = sess.Load<Specijalizacija>(sp.Kordinator);
                specijalizacija.Id = sp.Id;
                specijalizacija.Kordinator = sess.Load<Kordinator>(sp.Kordinator);
                specijalizacija.Tip = sp.Tip;
                sess.Update(specijalizacija);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

        }
        public static IList<SpecijalizacijaPregled> VratiSpecijalizacije()
        {
            List<SpecijalizacijaPregled> sveSpecijalizacije = new List<SpecijalizacijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Specijalizacija> z = from o in s.Query<Specijalizacija>()
                                                          select o;
                foreach (Specijalizacija specijalizacija in z)
                {
                    sveSpecijalizacije.Add(new SpecijalizacijaPregled(specijalizacija.Id, specijalizacija.Kordinator.JMBG, specijalizacija.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sveSpecijalizacije;
        }

        public static SpecijalizacijaPregled VratiSpecijalizaciju(Kordinator k, string Tip)
        {
            SpecijalizacijaPregled specijalizacija = new SpecijalizacijaPregled();
            try
            {
                ISession sess = DataLayer.GetSession();
                Specijalizacija sp = sess.Load<Specijalizacija>(k);
                specijalizacija.Id = sp.Id;
                specijalizacija.Kordinator = sp.Kordinator.JMBG;
                specijalizacija.Tip = sp.Tip;
                sess.Close();
            }
            catch (Exception e)
            {
            }
            return specijalizacija;
        }
        #endregion


        #region LicnaZastita
        public static void DodajLicnuZastitu(LicnaZastitaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                LicnaZastita liz = new LicnaZastita();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Licna;
                s.Save(liz);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiLicnuZastitu(int SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                LicnaZastita z = s.Load<LicnaZastita>(SerijskiBroj);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniLicnuZastitu(LicnaZastitaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                LicnaZastita liz = s.Load<LicnaZastita>(l.Serijski_Broj);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Licna;


                s.Update(liz);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<LicnaZastitaBasic> VratiLicnuZastitu()
        {
            List<LicnaZastitaBasic> svaOprema = new List<LicnaZastitaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.LicnaZastita> l = from o in s.Query<LicnaZastita>()
                                                       select o;
                foreach (LicnaZastita liz in l)
                {
                    svaOprema.Add(new LicnaZastitaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }

        public static LicnaZastitaBasic VratiLicnuZastitu(string Naziv)
        {
            LicnaZastitaBasic liz = new LicnaZastitaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                LicnaZastita l = s.Load<LicnaZastita>(Naziv);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.IdJedinica = l.Jedinica.Jedinstveni_Broj;
                liz.Licna = l.Tip;
                s.Close();
            }
            catch (Exception e)
            {
            }
            return liz;
        }

        public static IList<LicnaZastitaBasic> VratiLicnuOpremuJedinice(int idJedinice)
        {
            List<LicnaZastitaBasic> svaOprema = new List<LicnaZastitaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.LicnaZastita> l = from o in s.Query<LicnaZastita>()
                                                       where o.Jedinica.Jedinstveni_Broj == idJedinice
                                                       select o;
                foreach (LicnaZastita liz in l)
                {
                    svaOprema.Add(new LicnaZastitaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        #endregion

        #region MedicinskaOprema

        public static void DodajMedicinskuOpremu(MedicinskaOpremaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                MedicinskaOprema liz = new MedicinskaOprema();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Medicinska;
                s.Save(liz);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiMedicinskuOpremu(int SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                MedicinskaOprema z = s.Load<MedicinskaOprema>(SerijskiBroj);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniMedicinskuOpremu(MedicinskaOpremaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                MedicinskaOprema liz = s.Load<MedicinskaOprema>(l.Serijski_Broj);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Medicinska;


                s.Update(liz);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<MedicinskaOpremaBasic> VratiMedicinskuZastitu()
        {
            List<MedicinskaOpremaBasic> svaOprema = new List<MedicinskaOpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.MedicinskaOprema> l = from o in s.Query<MedicinskaOprema>()
                                                           select o;
                foreach (MedicinskaOprema liz in l)
                {
                    svaOprema.Add(new MedicinskaOpremaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }

        public static MedicinskaOpremaBasic VratiMedicinskuOpremu(int SerijskiBroj)
        {
            MedicinskaOpremaBasic liz = new MedicinskaOpremaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                MedicinskaOprema l = s.Load<MedicinskaOprema>(SerijskiBroj);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.IdJedinica = l.Jedinica.Jedinstveni_Broj;
                liz.Medicinska = l.Tip;
                s.Close();
            }
            catch (Exception e)
            {
            }
            return liz;
        }

        public static IList<MedicinskaOpremaBasic> VratiMedicinskuOpremuJedinice(int idJedinice)
        {
            List<MedicinskaOpremaBasic> svaOprema = new List<MedicinskaOpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.MedicinskaOprema> l = from o in s.Query<MedicinskaOprema>()
                                                           where o.Jedinica.Jedinstveni_Broj == idJedinice
                                                           select o;
                foreach (MedicinskaOprema liz in l)
                {
                    svaOprema.Add(new MedicinskaOpremaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        #endregion

        #region TehnickaOprema
        public static void DodajTehnickuOpremu(TehnickaOpremaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TehnickaOprema liz = new TehnickaOprema();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Tehnicka;
                s.Save(liz);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void ObrisiTehnickuOpremu(int SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TehnickaOprema z = s.Load<TehnickaOprema>(SerijskiBroj);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniTehnickuOpremu(TehnickaOpremaBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TehnickaOprema liz = s.Load<TehnickaOprema>(l.Serijski_Broj);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = s.Load<InterventnaJedinica>(l.IdJedinica);
                liz.Tip = l.Tehnicka;
                s.Update(liz);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<TehnickaOpremaBasic> VratiTehnickuZastitu()
        {
            List<TehnickaOpremaBasic> svaOprema = new List<TehnickaOpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.TehnickaOprema> l = from o in s.Query<TehnickaOprema>()
                                                         select o;
                foreach (TehnickaOprema liz in l)
                {
                    svaOprema.Add(new TehnickaOpremaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }

        public static TehnickaOpremaBasic VratiTehnickuOpremu(int SerijskiBroj)
        {
            TehnickaOpremaBasic liz = new TehnickaOpremaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                TehnickaOprema l = s.Load<TehnickaOprema>(SerijskiBroj);
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.IdJedinica = l.Jedinica.Jedinstveni_Broj;
                liz.Tehnicka = l.Tip;
                s.Close();
            }
            catch (Exception e)
            {
            }
            return liz;
        }

        public static IList<TehnickaOpremaBasic> VratiTehnickuOpremuJedinice(int idJedinice)
        {
            List<TehnickaOpremaBasic> svaOprema = new List<TehnickaOpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.TehnickaOprema> l = from o in s.Query<TehnickaOprema>()
                                                         where o.Jedinica.Jedinstveni_Broj == idJedinice
                                                         select o;
                foreach (TehnickaOprema liz in l)
                {
                    svaOprema.Add(new TehnickaOpremaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        #endregion

        #region Zalihe
        public static void DodajZalihe(ZaliheBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zalihe zalihe = new Zalihe();
                zalihe.Serijski_Broj = z.Serijski_Broj;
                zalihe.Naziv = z.Naziv;
                zalihe.Status = z.Status;
                zalihe.DatumNabavke = z.DatumNabavke;
                zalihe.Jedinica = s.Load<InterventnaJedinica>(z.IdJedinica);
                zalihe.Kolicina = z.Kolicina;
                zalihe.Tip = z.Zalihe;
                s.Save(zalihe);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiZalihe(int SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zalihe z = s.Load<Zalihe>(SerijskiBroj);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniZalihe(ZaliheBasic z)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zalihe zalihe = s.Load<Zalihe>(z.Serijski_Broj);
                zalihe.Serijski_Broj = z.Serijski_Broj;
                zalihe.Naziv = z.Naziv;
                zalihe.Status = z.Status;
                zalihe.DatumNabavke = z.DatumNabavke;
                zalihe.Jedinica = s.Load<InterventnaJedinica>(z.IdJedinica);
                zalihe.Kolicina = z.Kolicina;
                zalihe.Tip = z.Zalihe;
                s.Update(zalihe);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<ZaliheBasic> VratiZalihe()
        {
            List<ZaliheBasic> svaOprema = new List<ZaliheBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Zalihe> l = from o in s.Query<Zalihe>()
                                                 select o;
                foreach (Zalihe liz in l)
                {
                    svaOprema.Add(new ZaliheBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Kolicina, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        public static ZaliheBasic VratiZalihe(int SerijskiBroj)
        {
            ZaliheBasic liz = new ZaliheBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Zalihe z = s.Load<Zalihe>(SerijskiBroj);
                liz.Serijski_Broj = z.Serijski_Broj;
                liz.Naziv = z.Naziv;
                liz.Status = z.Status;
                liz.DatumNabavke = z.DatumNabavke;
                liz.IdJedinica = z.Jedinica.Jedinstveni_Broj;
                liz.Kolicina = z.Kolicina;
                liz.Zalihe = z.Tip;
                s.Close();
            }
            catch (Exception e)
            {
            }
            return liz;
        }

        public static IList<ZaliheBasic> VratiZaliheJedinice(int idJedinice)
        {
            List<ZaliheBasic> svaOprema = new List<ZaliheBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Zalihe> l = from o in s.Query<Zalihe>()
                                                 where o.Jedinica.Jedinstveni_Broj == idJedinice
                                                 select o;
                foreach (Zalihe liz in l)
                {
                    svaOprema.Add(new ZaliheBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Kolicina, liz.Tip));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        #endregion

        #region Oprema
        public static IList<OpremaBasic> VratiSvuOpremu()
        {
            List<OpremaBasic> svaOprema = new List<OpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Oprema> l = from o in s.Query<Oprema>()
                                                 select o;
                foreach (Oprema o in l)
                {
                    if (o is LicnaZastita)
                    {
                        LicnaZastita liz = (LicnaZastita)o;
                        svaOprema.Add(new LicnaZastitaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                    }
                    else if (o is MedicinskaOprema)
                    {
                        MedicinskaOprema med = (MedicinskaOprema)o;
                        svaOprema.Add(new MedicinskaOpremaBasic(med.Serijski_Broj, med.Naziv, med.Status, med.DatumNabavke, med.Jedinica.Jedinstveni_Broj, med.Tip));
                    }
                    else if (o is TehnickaOprema)
                    {
                        TehnickaOprema tech = (TehnickaOprema)o;
                        svaOprema.Add(new TehnickaOpremaBasic(tech.Serijski_Broj, tech.Naziv, tech.Status, tech.DatumNabavke, tech.Jedinica.Jedinstveni_Broj, tech.Tip));
                    }
                    else if (o is Zalihe)
                    {
                        Zalihe zalihe = (Zalihe)o;
                        svaOprema.Add(new ZaliheBasic(zalihe.Serijski_Broj, zalihe.Naziv, zalihe.Status, zalihe.DatumNabavke, zalihe.Jedinica.Jedinstveni_Broj, zalihe.Kolicina, zalihe.Tip));
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }

        public static IList<OpremaBasic> VratiSvuOpremuJedinice(int IdJed)
        {
            List<OpremaBasic> svaOprema = new List<OpremaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Oprema> l = from o in s.Query<Oprema>()
                                                 where o.Jedinica.Jedinstveni_Broj==IdJed
                                                 select o;
                foreach (Oprema o in l)
                {
                    if (o is LicnaZastita)
                    {
                        LicnaZastita liz = (LicnaZastita)o;
                        svaOprema.Add(new LicnaZastitaBasic(liz.Serijski_Broj, liz.Naziv, liz.Status, liz.DatumNabavke, liz.Jedinica.Jedinstveni_Broj, liz.Tip));
                    }
                    else if (o is MedicinskaOprema)
                    {
                        MedicinskaOprema med = (MedicinskaOprema)o;
                        svaOprema.Add(new MedicinskaOpremaBasic(med.Serijski_Broj, med.Naziv, med.Status, med.DatumNabavke, med.Jedinica.Jedinstveni_Broj, med.Tip));
                    }
                    else if (o is TehnickaOprema)
                    {
                        TehnickaOprema tech = (TehnickaOprema)o;
                        svaOprema.Add(new TehnickaOpremaBasic(tech.Serijski_Broj, tech.Naziv, tech.Status, tech.DatumNabavke, tech.Jedinica.Jedinstveni_Broj, tech.Tip));
                    }
                    else if (o is Zalihe)
                    {
                        Zalihe zalihe = (Zalihe)o;
                        svaOprema.Add(new ZaliheBasic(zalihe.Serijski_Broj, zalihe.Naziv, zalihe.Status, zalihe.DatumNabavke, zalihe.Jedinica.Jedinstveni_Broj, zalihe.Kolicina, zalihe.Tip));
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return svaOprema;
        }
        #endregion
        #region Predstavnik

        public static void DodajPredstavnika(PredstavnikBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predstavnik predstavnik = new Predstavnik();
                predstavnik.JMBG = p.JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                predstavnik.Sluzba = s.Load<Sluzba>(p.IdSektor);
                s.Save(predstavnik);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiPredstavnika(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predstavnik z = s.Load<Predstavnik>(JMBG);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniPredstavnika(PredstavnikBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predstavnik predstavnik = s.Load<Predstavnik>(p.JMBG);
                predstavnik.JMBG = p.JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                predstavnik.Sluzba = s.Load<Sluzba>(p.IdSektor);
                s.Update(predstavnik);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<PredstavnikBasic> VratiPredstavnike()
        {
            List<PredstavnikBasic> sviPredstavnici = new List<PredstavnikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Predstavnik> z = from o in s.Query<Predstavnik>()
                                                      select o;
                foreach (Predstavnik predstavnik in z)
                {
                    sviPredstavnici.Add(new PredstavnikBasic(predstavnik.JMBG, predstavnik.Ime, predstavnik.Prezime,
                        predstavnik.Pozicija, predstavnik.Telefon, predstavnik.Email, predstavnik.Sluzba.TipSektora, predstavnik.Sluzba.Id_Sektora));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviPredstavnici;
        }

        public static PredstavnikPregled VratiPredstavnika(string JMBG)
        {
            PredstavnikPregled predstavnik = new PredstavnikPregled();
            try
            {
                ISession s = DataLayer.GetSession();
                Predstavnik p = s.Load<Predstavnik>(JMBG);
                predstavnik.JMBG = p.JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                predstavnik.IdSektor = p.Sluzba.Id_Sektora;
                predstavnik.ImeSektora = p.Sluzba.TipSektora;
                s.Close();
            }
            catch (Exception e)
            {
            }
            return predstavnik;
        }


        #endregion

     

        #region Servisi
        public static void DodajServis(ServisiBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Servisi servis = new Servisi();
                servis.Id = s.Id;
                servis.Vozilo = sess.Load<Vozilo>(s.RegistracijaVozilo);
                servis.TipServisa = s.TipServisa;
                servis.Datum = s.Datum;
                sess.Save(servis);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }


        public static void ObrisiServis(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Servisi z = s.Load<Servisi>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniServis(ServisiBasic s)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Servisi Servis = session.Load<Servisi>(s.RegistracijaVozilo);
                Servis.Id=s.Id;
                Servis.Vozilo = session.Load<Vozilo>(s.RegistracijaVozilo);
                Servis.TipServisa = s.TipServisa;
                Servis.Datum = s.Datum;
                session.Update(Servis);
                session.Flush();
                session.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

        }

        public static IList<ServisiBasic> VratiServise()
        {
            List<ServisiBasic> sviServisi = new List<ServisiBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Servisi> z = from o in s.Query<Servisi>()
                                                  select o;
                foreach (Servisi servis in z)
                {
                    sviServisi.Add(new ServisiBasic(servis.Id, servis.Vozilo.Registarska_Oznaka, servis.TipServisa, servis.Datum));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviServisi;
        }

        public static ServisiBasic VratiServis(string RegistracijaVozilo0)
        {
            ServisiBasic servis = new ServisiBasic();
            try
            {
                ISession sess = DataLayer.GetSession();
                Servisi s = sess.Load<Servisi>(RegistracijaVozilo0);
                servis.Id=s.Id;
                servis.RegistracijaVozilo = s.Vozilo.Registarska_Oznaka;
                servis.TipServisa = s.TipServisa;
                servis.Datum = s.Datum;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return servis;
        }

        public static IList<ServisiBasic> VratiServiseVozila(string RegistracijaVozilo)
        {
            List<ServisiBasic> sviServisi = new List<ServisiBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Servisi> z = from o in s.Query<Servisi>()
                                                  where o.Vozilo.Registarska_Oznaka == RegistracijaVozilo
                                                  select o;
                foreach (Servisi servis in z)
                {
                    sviServisi.Add(new ServisiBasic(servis.Id, servis.Vozilo.Registarska_Oznaka, servis.TipServisa, servis.Datum));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return sviServisi;
        }
        #endregion

        #region IstorijaUlogaZaposlenih
        public static void DodajIstorijuUloga(Istorija_Uloga_ZaposlenihBasic i)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Istorija_Uloga_Zaposlenih istorija = new Istorija_Uloga_Zaposlenih();
                istorija.Id = i.Id;
                istorija.Zaposleni = sess.Load<Zaposlen>(i.JMBGZaposleni);
                istorija.Uloga = i.Uloga;
                istorija.Datum_Od = i.Datum_Od;
                istorija.Datum_Do = i.Datum_Do;
                sess.Save(istorija);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void ObrisiIstorijuUloga(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Istorija_Uloga_Zaposlenih z = s.Load<Istorija_Uloga_Zaposlenih>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniIstorijuUloga(Istorija_Uloga_ZaposlenihBasic i)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Istorija_Uloga_Zaposlenih istorija = sess.Load<Istorija_Uloga_Zaposlenih>(i.JMBGZaposleni);
                istorija.Id = i.Id;
                istorija.Zaposleni = sess.Load<Zaposlen>(i.JMBGZaposleni);
                istorija.Uloga = i.Uloga;
                istorija.Datum_Od = i.Datum_Od;
                istorija.Datum_Do = i.Datum_Do;
                sess.Update(istorija);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<Istorija_Uloga_ZaposlenihBasic> VratiIstoriju()
        {
            List<Istorija_Uloga_ZaposlenihBasic> Istorija = new List<Istorija_Uloga_ZaposlenihBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Istorija_Uloga_Zaposlenih> i = from o in s.Query<Istorija_Uloga_Zaposlenih>()
                                                                    select o;
                foreach (Istorija_Uloga_Zaposlenih ist in i)
                {
                Istorija.Add(new Istorija_Uloga_ZaposlenihBasic(ist.Id, ist.Zaposleni.JMBG, ist.Uloga, ist.Datum_Od, ist.Datum_Do));
                }
                    s.Close();
                }
                catch (Exception e)
                {
                }
            return Istorija;
            }

        
        public static Istorija_Uloga_ZaposlenihBasic VratiIstorijuU(string JMBGZaposleni)
        {
            Istorija_Uloga_ZaposlenihBasic istorija = new Istorija_Uloga_ZaposlenihBasic();
            try
            {
                ISession sess = DataLayer.GetSession();
                Istorija_Uloga_Zaposlenih i = sess.Load<Istorija_Uloga_Zaposlenih>(JMBGZaposleni);
                istorija.JMBGZaposleni =i.Zaposleni.JMBG;
                istorija.Uloga = i.Uloga;
                istorija.Datum_Od = i.Datum_Od;
                istorija.Datum_Do = i.Datum_Do;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return istorija;
        }

        public static IList<Istorija_Uloga_ZaposlenihBasic> VratiIstorijuUZaposlenog(string JMBGZaposleni)
        {
            List<Istorija_Uloga_ZaposlenihBasic> Istorija = new List<Istorija_Uloga_ZaposlenihBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Istorija_Uloga_Zaposlenih> i = from o in s.Query<Istorija_Uloga_Zaposlenih>()
                                                                    where o.Zaposleni.JMBG == JMBGZaposleni
                                                                    select o;
                foreach (Istorija_Uloga_Zaposlenih ist in i)
                {
                    Istorija.Add(new Istorija_Uloga_ZaposlenihBasic(ist.Id , ist.Zaposleni.JMBG, ist.Uloga, ist.Datum_Od, ist.Datum_Do));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Istorija;
        }
        #endregion

        #region DodeljujeSe
        public static void DodajDodeljivanje(DodeljujeSeBasic d)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                DodeljujeSe dodeljivanje = new DodeljujeSe();
                dodeljivanje.Vozilo = sess.Load<Vozilo>(d.RegVozilo);
                dodeljivanje.Radnik = sess.Load<OperativniRadnik>(d.JMBGPojedinac);
                dodeljivanje.Jedinica = sess.Load<InterventnaJedinica>(d.idJedinica);
                sess.Save(dodeljivanje);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiDodeljivanje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                DodeljujeSe z = s.Load<DodeljujeSe>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<DodeljujeSeBasic> VratiSvaDodeljivanja()
        {
            List<DodeljujeSeBasic> Dodeljivanja = new List<DodeljujeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.DodeljujeSe> i = from o in s.Query<DodeljujeSe>()
                                                      select o;
                foreach (DodeljujeSe dodeljivanje in i)
                {
                    Dodeljivanja.Add(new DodeljujeSeBasic(dodeljivanje.Id ,dodeljivanje.Vozilo.Registarska_Oznaka, dodeljivanje.Radnik.JMBG, dodeljivanje.Jedinica.Jedinstveni_Broj, dodeljivanje.DatumOd, dodeljivanje.DatumDo));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Dodeljivanja;
        }
        public static IList<DodeljujeSeBasic> VratiDodeljivanjaVozila(string RegVozilo)
        {
            List<DodeljujeSeBasic> Dodeljivanja = new List<DodeljujeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.DodeljujeSe> i = from o in s.Query<DodeljujeSe>()
                                                      where o.Vozilo.Registarska_Oznaka == RegVozilo
                                                      select o;
                foreach (DodeljujeSe dodeljivanje in i)
                {
                    Dodeljivanja.Add(new DodeljujeSeBasic(dodeljivanje.Id, dodeljivanje.Vozilo.Registarska_Oznaka, dodeljivanje.Radnik.JMBG, dodeljivanje.Jedinica.Jedinstveni_Broj, dodeljivanje.DatumOd, dodeljivanje.DatumDo));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Dodeljivanja;
        }

        public static IList<DodeljujeSeBasic> VratiDodeljivanjaRadnika(string JMBGPojedinac)
        {
            List<DodeljujeSeBasic> Dodeljivanja = new List<DodeljujeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.DodeljujeSe> i = from o in s.Query<DodeljujeSe>()
                                                      where o.Radnik.JMBG == JMBGPojedinac
                                                      select o;
                foreach (DodeljujeSe dodeljivanje in i)
                {
                    Dodeljivanja.Add(new DodeljujeSeBasic(dodeljivanje.Id, dodeljivanje.Vozilo.Registarska_Oznaka, dodeljivanje.Radnik.JMBG, dodeljivanje.Jedinica.Jedinstveni_Broj, dodeljivanje.DatumOd, dodeljivanje.DatumDo));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Dodeljivanja;
        }

        #endregion

        #region Saradjuje
        public static void DodajSaradnju(SaradjujeBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Saradjuje saradnja = new Saradjuje();
                saradnja.Id=s.Id;
                saradnja.Uloga= s.Uloga;
                saradnja.Sektor = sess.Load<Sluzba>(s.IdSektor);
                saradnja.VandrednaSituacija = sess.Load<VanrednaSituacija>(s.IdVandrednaSituacija);

                sess.Save(saradnja);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiSaradnju(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Saradjuje z = s.Load<Saradjuje>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSaradnju(SaradjujeBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Saradjuje saradnja = sess.Load<Saradjuje>(s.Id);
                saradnja.Id = s.Id;
                saradnja.Uloga = s.Uloga;
                saradnja.Sektor = sess.Load<Sluzba>(s.IdSektor);
                saradnja.VandrednaSituacija = sess.Load<VanrednaSituacija>(s.IdVandrednaSituacija);
                sess.Update(saradnja);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SaradjujeBasic> VratiSaradnje()
        {
            List<SaradjujeBasic> Saradnje = new List<SaradjujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Saradjuje> i = from o in s.Query<Saradjuje>()
                                                   select o;
                foreach (Saradjuje saradnja in i)
                {
                    Saradnje.Add(new SaradjujeBasic(saradnja.Id, saradnja.Uloga, saradnja.Sektor.Id_Sektora, saradnja.VandrednaSituacija.Id));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Saradnje;
        }

        public static SaradjujeBasic VratiSaradnju(int Id)
        {
            SaradjujeBasic saradnja = new SaradjujeBasic();
            try
            {
                ISession sess = DataLayer.GetSession();
                Saradjuje s = sess.Load<Saradjuje>(Id);
                saradnja.Id = s.Id;
                saradnja.Uloga = s.Uloga;
                saradnja.IdSektor = s.Sektor.Id_Sektora;
                saradnja.IdVandrednaSituacija = s.VandrednaSituacija.Id;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return saradnja;
        }
        public static IList<SaradjujePregled> VratiSveSaradnjeSektora(int IdSektor)
        { 
                List<SaradjujePregled> Saradnje = new List<SaradjujePregled>();
                try
                {
                    ISession s = DataLayer.GetSession();

                    IEnumerable<Saradjuje> sek = from o in s.Query<Saradjuje>()
                                                 where o.Sektor.Id_Sektora == IdSektor
                                                 select o;

                    foreach (Saradjuje sa in sek)
                    {
                        SluzbaPregled sluzba = DTOMAnager.VratiSluzbu(sa.Sektor.Id_Sektora);
                        VandrednaSituacijaPregled vs = DTOMAnager.VratiVandrednuSituaciju(sa.VandrednaSituacija.Id);
                        Saradnje.Add(new SaradjujePregled(sa.Id, sa.Uloga, sluzba, vs));
                    }

                    ;

                }
                catch (Exception ec)
                {
                    //handle exceptions
                }

                return Saradnje;
           
        }
        #endregion

        #region Ucestvovalo
        public static void DodajUcestvovanje(UcestvovaloBasic u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvovalo ucestvovanje = new Ucestvovalo();
                ucestvovanje.ID = u.ID;
                ucestvovanje.Vozilo = sess.Load<Vozilo>(u.RegVozilo);
                ucestvovanje.Jedinica = sess.Load<InterventnaJedinica>(u.IdJedinica);
                sess.Save(ucestvovanje);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiUcestvovanje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ucestvovalo z = s.Load<Ucestvovalo>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniUcestvovanje(UcestvovaloBasic u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvovalo ucestvovanje = sess.Load<Ucestvovalo>(u.ID);
                ucestvovanje.ID = u.ID;
                ucestvovanje.Vozilo = sess.Load<Vozilo>(u.RegVozilo);
                ucestvovanje.Jedinica = sess.Load<InterventnaJedinica>(u.IdJedinica);
                sess.Update(ucestvovanje);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IList<UcestvovaloBasic> VratiUcestvovanja()
        {
            List<UcestvovaloBasic> ucestvovalo = new List<UcestvovaloBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvovalo> i = from o in s.Query<Ucestvovalo>()
                                                 select o;
                foreach (Ucestvovalo u in i)
                {
                    
                    ucestvovalo.Add(new UcestvovaloBasic(u.ID, u.Vozilo.Registarska_Oznaka, u.Jedinica.Jedinstveni_Broj));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
        
            return ucestvovalo;
        }
        public static UcestvovaloBasic VratiUcestvovanje(int Id)
        {
            UcestvovaloBasic ucestv = new UcestvovaloBasic();
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvovalo u = sess.Load<Ucestvovalo>(Id);
                ucestv.ID = u.ID;
                ucestv.RegVozilo = u.Vozilo.Registarska_Oznaka;
                ucestv.IdJedinica = u.Jedinica.Jedinstveni_Broj;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return ucestv;
        }
        public static IList<UcestvovaloBasic> VratiUcestvovanjaVozila(string RegVozilo)
        {
            List<UcestvovaloBasic> ucestvovalo = new List<UcestvovaloBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvovalo> i = from o in s.Query<Ucestvovalo>()
                                                     where o.Vozilo.Registarska_Oznaka == RegVozilo
                                                 select o;
                foreach (Ucestvovalo u in i)
                {
                    ucestvovalo.Add(new UcestvovaloBasic(u.ID, u.Vozilo.Registarska_Oznaka, u.Jedinica.Jedinstveni_Broj));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return ucestvovalo;
        }
        public static IList<UcestvovaloBasic> VratiUcestvovanjauIntervenciji(int IdIntervencije)
        {
            List<UcestvovaloBasic> ucestvovalo = new List<UcestvovaloBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvovalo> i = from o in s.Query<Ucestvovalo>()
                                                      where o.Jedinica.Jedinstveni_Broj == IdIntervencije
                                                      select o;
                foreach (Ucestvovalo u in i)
                {
                    ucestvovalo.Add(new UcestvovaloBasic(u.ID, u.Vozilo.Registarska_Oznaka, u.Jedinica.Jedinstveni_Broj));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return ucestvovalo;
        }

        #endregion

        #region Ucestvuje
        public static void DodajUcestvuje(UcestvujeBasic u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvuje ucestvovanje = new Ucestvuje();
                ucestvovanje.Id=u.Id;
                ucestvovanje.IdInterventneJed = sess.Load<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = sess.Load<VanrednaSituacija>(u.IdVandredneSituacije);
                ucestvovanje.IdIntervencije = sess.Load<Intervencija>(u.IdIntervencije);
                sess.Save(ucestvovanje);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void ObrisiUcestvuje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ucestvuje z = s.Load<Ucestvuje>(Id);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void IzmeniUcestvuje(UcestvujeBasic u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvuje ucestvovanje = sess.Load<Ucestvuje>(u.Id);
                ucestvovanje.Id = u.Id;
                ucestvovanje.IdInterventneJed = sess.Load<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = sess.Load<VanrednaSituacija>(u.IdVandredneSituacije);
                ucestvovanje.IdIntervencije = sess.Load<Intervencija>(u.IdIntervencije);
                sess.Update(ucestvovanje);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        
        public static IList<UcestvujeBasic> VratiSvaUcestvovanja()
        {
            List<UcestvujeBasic> ucestvuj = new List<UcestvujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvuje> i = from o in s.Query<Ucestvuje>()
                                                      select o;
                foreach (Ucestvuje u in i)
                {

                    ucestvuj.Add(new UcestvujeBasic(u.Id, u.IdInterventneJed.Jedinstveni_Broj, u.IdVandredneSituacije.Id, u.IdIntervencije.Id));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }

            return ucestvuj;
        }
        public static UcestvujeBasic VratiUcestvuje(int Id)
        {
            UcestvujeBasic ucestv = new UcestvujeBasic();
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvuje u = sess.Load<Ucestvuje>(Id);
                ucestv.Id = u.Id;
                ucestv.IdVandredneSituacije = u.IdVandredneSituacije.Id;
                ucestv.IdInterventneJed = u.IdInterventneJed.Jedinstveni_Broj;
                ucestv.IdIntervencije = u.IdIntervencije.Id;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return ucestv;
        }

        public static IList<UcestvujeBasic> VratiSvaUcestvovanjaUVandrednojSituaciji(int IdVS)
        {
            List<UcestvujeBasic> ucestvovalo = new List<UcestvujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvuje> i = from o in s.Query<Ucestvuje>()
                                                      where o.IdVandredneSituacije.Id == IdVS
                                                      select o;
                foreach (Ucestvuje u in i)
                {
                    ucestvovalo.Add(new UcestvujeBasic(u.Id, u.IdInterventneJed.Jedinstveni_Broj, u.IdVandredneSituacije.Id, u.IdIntervencije.Id));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return ucestvovalo;

        }

        public static IList<UcestvujeBasic> VratiSvaUcestvovanjaUIntervenciji(int IdInt)
        {
            List<UcestvujeBasic> ucestvovalo = new List<UcestvujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvuje> i = from o in s.Query<Ucestvuje>()
                                                    where o.IdIntervencije.Id == IdInt
                                                    select o;
                foreach (Ucestvuje u in i)
                {
                    ucestvovalo.Add(new UcestvujeBasic(u.Id, u.IdInterventneJed.Jedinstveni_Broj, u.IdVandredneSituacije.Id, u.IdIntervencije.Id));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return ucestvovalo;

        }

        public static IList<UcestvujeBasic> VratiSvaUcestvovanjaJedinice(int IdJed)
        {
            List<UcestvujeBasic> ucestvovalo = new List<UcestvujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Ucestvuje> i = from o in s.Query<Ucestvuje>()
                                                    where o.IdInterventneJed.Jedinstveni_Broj == IdJed
                                                    select o;
                foreach (Ucestvuje u in i)
                {
                    ucestvovalo.Add(new UcestvujeBasic(u.Id, u.IdInterventneJed.Jedinstveni_Broj, u.IdVandredneSituacije.Id, u.IdIntervencije.Id));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return ucestvovalo;

        }
        #endregion
        #region Sluzba
        public static void DodajSluzbu(SluzbaBasic s) 
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Sluzba sluzba = new Sluzba();
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik= sess.Load<Predstavnik>(s.Predstavnik);
                sess.Save(sluzba);
                sess.Flush();
                sess.Close();


            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void ObrisiSluzbu(int IdSektor)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sluzba z = s.Load<Sluzba>(IdSektor);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSluzbu(SluzbaBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Sluzba sluzba = sess.Load<Sluzba>(s.Id_Sektora);
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik = sess.Load<Predstavnik>(s.Predstavnik);
                sess.Update(sluzba);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SluzbaPregled> VratiSluzbe()
        {
            List<SluzbaPregled> Sluzbe = new List<SluzbaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Sluzba> i = from o in s.Query<Sluzba>()
                                                 select o;
                foreach (Sluzba sluzba in i)
                {
                    PredstavnikPregled p= DTOMAnager.VratiPredstavnika(sluzba.Predstavnik.JMBG);
                    Sluzbe.Add(new SluzbaPregled(sluzba.Id_Sektora, sluzba.TipSektora, p));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Sluzbe;
        }
        public static SluzbaPregled VratiSluzbu(int IdSektora)
        {
            SluzbaPregled sluzba = new SluzbaPregled();
            try
            {
                ISession sess = DataLayer.GetSession();
                Sluzba s = sess.Load<Sluzba>(IdSektora);
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                PredstavnikPregled p = DTOMAnager.VratiPredstavnika(s.Predstavnik.JMBG);
                sluzba.Predstavnik = p;
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return sluzba;
        }

        public static IList<SaradjujePregled> VratiSveVandredneUKojimaSaradjujeSektor(int IdSektor)
        {
            List<SaradjujePregled> Vandredne = new List<SaradjujePregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Saradjuje> i = from o in s.Query<Saradjuje>()
                                                   where o.Sektor.Id_Sektora == IdSektor
                                                   select o;
                foreach (Saradjuje saradnja in i)
                {

                    VandrednaSituacijaPregled v= DTOMAnager.VratiVandrednuSituaciju(saradnja.VandrednaSituacija.Id);
                    SluzbaPregled sluzba= DTOMAnager.VratiSluzbu(saradnja.Sektor.Id_Sektora);
                    Vandredne.Add(new SaradjujePregled(saradnja.Id, saradnja.Uloga,sluzba, v ));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Vandredne;
        }
        public static IList<SaradjujePregled> VratiSveSluzbeKojeSaradjujuSaVS(int IdVS)
        {
            List<SaradjujePregled> Sluzbe = new List<SaradjujePregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Saradjuje> i = from o in s.Query<Saradjuje>()
                                                    where o.VandrednaSituacija.Id == IdVS
                                                    select o;
                foreach (Saradjuje saradnja in i)
                {

                    VandrednaSituacijaPregled v = DTOMAnager.VratiVandrednuSituaciju(saradnja.VandrednaSituacija.Id);
                    SluzbaPregled sluzba = DTOMAnager.VratiSluzbu(saradnja.Sektor.Id_Sektora);
                    Sluzbe.Add(new SaradjujePregled(saradnja.Id, saradnja.Uloga, sluzba, v));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Sluzbe;
        }
        #endregion

        #region Ucestvuje
        #endregion

        #region Softver
        public static void DodajSoftver(SoftverBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Softver softver = new Softver();
                softver.Analiticar = sess.Load<Analiticar>(s.AnaliticarJMBG);
                softver.Naziv = s.Naziv;
                sess.Save(softver);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void ObrisiSoftver(int IdSoftver)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Softver z = s.Load<Softver>(IdSoftver);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniSoftver(SoftverBasic s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Softver softver = sess.Load<Softver>(s.AnaliticarJMBG);
                softver.Analiticar = sess.Load<Analiticar>(s.AnaliticarJMBG);
                softver.Naziv = s.Naziv;
                sess.Update(softver);
                sess.Flush();
                sess.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static IList<SoftverBasic> VratiSoftvere()
        {
            List<SoftverBasic> Softveri = new List<SoftverBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Softver> i = from o in s.Query<Softver>()
                                                  select o;
                foreach (Softver softver in i)
                {
                    Softveri.Add(new SoftverBasic(softver.Analiticar.JMBG, softver.Naziv));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Softveri;
        }

        public static SoftverBasic VratiSoftver(string JMBGAnaliticara)
        {
            SoftverBasic softver = new SoftverBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Softver so = s.Load<Softver>(JMBGAnaliticara);
                softver.AnaliticarJMBG= so.Analiticar.JMBG;
                softver.Naziv = so.Naziv;
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return softver;
        }

        public static IList<SoftverBasic> VratiSoftvereAnaliticara(string JMBGAnaliticara)
        {
            List<SoftverBasic> Softveri = new List<SoftverBasic>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Entiteti.Softver> i = from o in s.Query<Softver>()
                                                  where o.Analiticar.JMBG == JMBGAnaliticara
                                                  select o;
                foreach (Softver softver in i)
                {
                    Softveri.Add(new SoftverBasic(softver.Analiticar.JMBG, softver.Naziv));
                }
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Softveri;
        }
        #endregion
    }
}
