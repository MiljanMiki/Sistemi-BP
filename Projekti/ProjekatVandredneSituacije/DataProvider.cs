using FluentNHibernate.Conventions;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping;
using ProjekatVandredneSituacije;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Policy;
using System.Text;
using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Mapiranja;
using System.Text.RegularExpressions;
using NHibernate.Util;
using Remotion.Linq.Parsing;
using NHibernate.Cfg.Loquacious;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using NHibernate.Driver;
using System.Security.Cryptography;
using ProjekatVandredneSituacije.Entiteti;
using System.Net.Http.Headers;


namespace ProjekatVandredneSituacije
{
    public static class DataProvider
    {
        #region VanrednaSituacija

        public static async Task obrisiVanrednuSituaciju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri sesiji");
                }
                VanrednaSituacija Vanredna = await s.LoadAsync<VanrednaSituacija>(id);

                await s.DeleteAsync(Vanredna);
                await s.FlushAsync();

                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }


        }

        public static async Task DodajVanrednuSituaciju(VanrednaSituacijaAddView vs)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                VanrednaSituacija v = new VanrednaSituacija();
                if (vs.Datum_Od >= DateTime.Now)
                {
                    
                    v.Datum_Od = DateTime.Now;
                    v.Datum_Do = null;
                }
                else
                    v.Datum_Od = vs.Datum_Od;
                if (vs.Datum_Do <= vs.Datum_Od)
                {
                    throw new Exception("Zao nam je ali ne mozete upisati ovu vrednost");
                }
                else
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Nivo_Opasnosti = vs.Nivo_Opasnosti;
                v.Opstina = vs.Opstina;
                v.Lokacija = vs.Lokacija;
                v.Opis = vs.Opis;
                v.Prijava_ID = await s.GetAsync<Prijava>(vs.IdPrijave);

                await s.SaveOrUpdateAsync(v);
                await s.FlushAsync();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<VanrednaSituacijaView> VratiVanrednuSituaciju(int id)
        {
            VanrednaSituacijaView vanredna = null;

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                VanrednaSituacija vs = await s.LoadAsync<VanrednaSituacija>(id);

                vanredna = new VanrednaSituacijaView(vs);
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vanredna;


        }
        public static async Task<IList<VanrednaSituacijaView>> VratiVanredneSituacije()
        {
            List<VanrednaSituacijaView> vs = new List<VanrednaSituacijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                vs = await s.Query<VanrednaSituacija>()
                    .Fetch(v => v.Prijava_ID) // N+1 potencijalni
                    .Select(v => new VanrednaSituacijaView(v))
                    .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vs;
        }
        public static async Task IzmeniVanrednuSituaciju(VanrednaSituacijaAddView vs, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                VanrednaSituacija v = await s.LoadAsync<VanrednaSituacija>(Id);

                v.Nivo_Opasnosti = vs.Nivo_Opasnosti;
                v.Lokacija = vs.Lokacija;
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Opstina = vs.Opstina;
                v.Opis = vs.Opis;
                v.Prijava_ID = await s.GetAsync<Prijava>(vs.IdPrijave);

                await s.UpdateAsync(v);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }


        #endregion

        #region IntervetnaJedinica
        public static async Task DodajOpstuIntervetnuJedinicu(OpstaInterventnaBasicView i)
        {

            try
            {

                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                OpstaIntervetnaJed ij = new OpstaIntervetnaJed();
                ij.Naziv = i.Naziv;
                ij.Komandir = await s.GetAsync<OperativniRadnik>(i.JMBGKomandira);
                ij.Baza = i.Baza;
                OperativniRadnik Komandir = await s.GetAsync<OperativniRadnik>(i.JMBGKomandira);
                await s.SaveOrUpdateAsync(ij);
                if (Komandir != null)
                {
                    Komandir.InterventnaJedinica = ij;
                    await s.SaveOrUpdateAsync(Komandir);
                }
                await s.FlushAsync();
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiOpstuInterventnuJedinicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                OpstaIntervetnaJed ij = await s.LoadAsync<OpstaIntervetnaJed>(id);
                await s.DeleteAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task IzmeniOpstuInterventnuJedinicu(OpstaInterventnaBasicView i, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                OpstaIntervetnaJed ij = await s.LoadAsync<OpstaIntervetnaJed>(Id);
                ij.Naziv = i.Naziv;

                OperativniRadnik Komandir = await s.GetAsync<OperativniRadnik>(i.JMBGKomandira);
                ij.Komandir = Komandir; //Dodato

                ij.Baza = i.Baza;

                if (Komandir != null)
                {
                    Komandir.InterventnaJedinica = ij;
                    await s.SaveOrUpdateAsync(Komandir);
                    ij.BrojClanova++;
                }
                await s.UpdateAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<OpstaIntervetnaGetView>> VratiOpstejedinice()
        {
            List<OpstaIntervetnaGetView> sveJedinice = new List<OpstaIntervetnaGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveJedinice = await s.Query<OpstaIntervetnaJed>()
                   .Fetch(o => o.Komandir) // N+1 potencijalni
                   .Select(o => new OpstaIntervetnaGetView(o))
                   .ToListAsync();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveJedinice;
        }

        public static async Task<OpstaIntervetnaGetView> VratiOpstuJedinicu(int id)
        {
            OpstaIntervetnaGetView o = null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                OpstaIntervetnaJed ij = await s.LoadAsync<OpstaIntervetnaJed>(id);
                if (ij == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji Opsta Intervetna jedinica sa ovim Id-em");
                }
                o = new OpstaIntervetnaGetView(ij);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return o;
        }


        public static async Task DodajSpecijalnuIntervetnuJedinicu(SpecijalnaIntervetnaJedinicaBasicView i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SpecijalnaInterventna ij = new SpecijalnaInterventna();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                ij.Naziv = i.Naziv;
                ij.Komandir = await s.GetAsync<OperativniRadnik>(i.JMBGKomandira);
                OperativniRadnik Komandir = await s.GetAsync<OperativniRadnik>(i.JMBGKomandira);
                ij.Baza = i.Baza;
                ij.TipSpecijalneJedinice = i.TipSpecijalneJedinice;
                await s.SaveOrUpdateAsync(ij);
                if (Komandir != null)
                {
                    Komandir.InterventnaJedinica = ij;
                    await s.SaveOrUpdateAsync(Komandir);
                    ij.BrojClanova++;
                }
                await s.FlushAsync();
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiSpecijalnuInterventnuJedinicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaInterventna ij = await s.LoadAsync<SpecijalnaInterventna>(id);

                await s.DeleteAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task izmeniSpecijalnuInterventnuJedinicu(SpecijalnaIntervetnaJedinicaBasicView i, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaInterventna ij = await s.LoadAsync<SpecijalnaInterventna>(Id);

                ij.Naziv = i.Naziv;
                ij.Komandir = await s.LoadAsync<OperativniRadnik>(i.JMBGKomandira);
                ij.Baza = i.Baza;
                ij.TipSpecijalneJedinice = i.TipSpecijalneJedinice;

                await s.UpdateAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SpecijalnaIntervetnaGetView>> VratiSpecijalneJedinice()
        {
            List<SpecijalnaIntervetnaGetView> sveJedinice = new List<SpecijalnaIntervetnaGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                sveJedinice = await s.Query<SpecijalnaInterventna>()
                   .Fetch(o => o.Komandir) // N+1 potencijalni
                   .Select(v => new SpecijalnaIntervetnaGetView(v))
                   .ToListAsync();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveJedinice;
        }

        public static async Task<SpecijalnaIntervetnaGetView> VratiSpecijalnuJedinicu(int id)
        {
            SpecijalnaIntervetnaGetView o = null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaInterventna ij = await s.LoadAsync<SpecijalnaInterventna>(id);
                o = new SpecijalnaIntervetnaGetView(ij);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return o;
        }

        public static async Task<IList<InterventnaJedinicaGetView>> VratiSveJedinice()
        {
            List<InterventnaJedinicaGetView> sveJedinice = new List<InterventnaJedinicaGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                var sveOpsteQuery = await s.Query<OpstaIntervetnaJed>()
                    .Fetch(o => o.Komandir) // N+1 potencijalni
                    .ToListAsync();
                var sveSpecQuery = await s.Query<SpecijalnaInterventna>()
                    .Fetch(o => o.Komandir) // N+1 potencijalni
                    .ToListAsync();
                foreach (var o in sveOpsteQuery)
                {
                    sveJedinice.Add(new OpstaIntervetnaGetView(o));
                }
                foreach (var o in sveSpecQuery)
                {
                    sveJedinice.Add(new SpecijalnaIntervetnaGetView(o));
                }
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveJedinice;
        }
        #endregion


        #region Intervencija
        public static async Task DodajIntervenciju(IntervencijaBasicView i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija intervencija = new Intervencija();
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
                intervencija.Resursi = i.Resursi;
                intervencija.Broj_Povredjenih = i.Broj_Povredjenih;
                intervencija.Uspesnost = i.Uspesnost;
                await s.SaveAsync(intervencija);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiIntervenciju(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Intervencija i = await s.LoadAsync<Intervencija>(Id);
                await s.DeleteAsync(i);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task IzmeniIntervenciju(IntervencijaBasicView i, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Intervencija intervencija = await s.LoadAsync<Intervencija>(Id);
                intervencija.Id = Id;
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
                intervencija.Broj_Povredjenih = i.Broj_Povredjenih;
                intervencija.Uspesnost = i.Uspesnost;
                intervencija.Resursi = i.Resursi;
                await s.UpdateAsync(intervencija);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<IntervencijaView>> VratiIntervencije()
        {
            List<IntervencijaView> sveIntervencije = new List<IntervencijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveIntervencije = await s.Query<Intervencija>()
                                  .Select(i => new IntervencijaView(i))
                                  .ToListAsync();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveIntervencije;
        }

        public static async Task<IntervencijaView> VratiIntervenciju(int id)
        {
            IntervencijaView i = new IntervencijaView();
            try
            {
                ISession s = DataLayer.GetSession();

                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Intervencija intervencija = await s.LoadAsync<Intervencija>(id);
                i.Datum_I_Vreme = intervencija.Datum_I_Vreme;
                i.Lokacija = intervencija.Lokacija;
                i.Status = intervencija.Status.ToString();
                i.Broj_Spasenih = intervencija.Broj_Spasenih;
                i.Resursi = intervencija.Resursi;
                i.Broj_Povredjenih = intervencija.Broj_Povredjenih;
                i.Uspesnost = intervencija.Uspesnost;
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return i;
        }

        #endregion


        #region Prijava

        public static async Task DodajPrijavu(PrijavaAddView pr)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Prijava p = new Prijava();
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Tip = pr.Tip;
                p.Ime_Prijavioca = pr.Ime_Prijavioca;
                p.Kontakt = pr.Kontakt;
                p.Lokacija = pr.Lokacija;
                p.Opis = pr.Opis;
                p.JMBG_Dispecer = pr.JMBG_Dispecer;
                p.Prioritet = pr.Prioritet;

                await s.SaveOrUpdateAsync(p);

                await s.FlushAsync();
                s.Close();


            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiPrijavu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Prijava p = await s.LoadAsync<Prijava>(id);

                await s.DeleteAsync(p);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniPrijavu(PrijavaAddView pr, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Prijava p = await s.LoadAsync<Prijava>(Id);

                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Tip = pr.Tip;
                p.Ime_Prijavioca = pr.Ime_Prijavioca;
                p.Kontakt = pr.Kontakt;
                p.Lokacija = pr.Lokacija;
                p.Opis = pr.Opis;
                p.JMBG_Dispecer = pr.JMBG_Dispecer;
                p.Prioritet = pr.Prioritet;

                await s.UpdateAsync(p);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<PrijavaView>> VratiPrijave()
        {
            List<PrijavaView> SvePrijave = new List<PrijavaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                SvePrijave = await s.Query<Prijava>().
                             Select(p => new PrijavaView(p))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return SvePrijave;
        }

        public static async Task<PrijavaView> VratiPrijavu(int idPrijave)
        {
            PrijavaView prijava = null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                Prijava pr = await s.LoadAsync<Prijava>(idPrijave);
                if (pr == null)
                {
                    throw new KeyNotFoundException("Zao nam je doslo je do greske prijava sa ovim Id-em ne postoji!");
                }
                prijava = new PrijavaView(pr);


                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return prijava;
        }

        #endregion

        #region Analiticar

        public static async Task DodajAnalitcar(AnaliticarView a)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
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
                Istorija_Uloga_Zaposlenih i = new Istorija_Uloga_Zaposlenih
                {
                    Zaposleni = analiticar,
                    Uloga = analiticar.GetType().Name,
                    Datum_Od = DateTime.Now,
                    Datum_Do = null
                };

                await s.SaveAsync(analiticar);

                await s.SaveAsync(i);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiAnaliticara(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Analiticar z = await s.LoadAsync<Analiticar>(JMBG);
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je Analiticar sa ovim JMBG ne postoji");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniAnaliticar(AnaliticarView a, string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Analiticar analiticar = await s.LoadAsync<Analiticar>(JMBG);
                analiticar.JMBG = JMBG;
                analiticar.Ime = a.Ime;
                analiticar.Prezime = a.Prezime;
                analiticar.Datum_Rodjenja = a.Datum_Rodjenja;
                analiticar.Kontakt_Telefon = a.Kontakt_Telefon;
                analiticar.Email = a.Email;
                analiticar.AdresaStanovanja = a.AdresaStanovanja;
                analiticar.Datum_Zaposlenja = a.Datum_Zaposlenja;
                analiticar.Pol = a.Pol;

                await s.UpdateAsync(analiticar);
                await s.FlushAsync();
                s.Close();


            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<AnaliticarView>> VratiAnaliticare()
        {
            List<AnaliticarView> sviAnaliticari = new List<AnaliticarView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviAnaliticari = await s.Query<Analiticar>()
                                .Select(a => new AnaliticarView(a))
                                .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviAnaliticari;
        }

        public static async Task<AnaliticarView> VratiAnaliticara(string JMBG)
        {
            AnaliticarView analiticar = new AnaliticarView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Analiticar a = await s.LoadAsync<Analiticar>(JMBG);
                if (a == null)
                {
                    throw new KeyNotFoundException("Zao nam je Analiticar sa ovim Id-em ne postoji");
                }
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
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return analiticar;
        }
        #endregion



        #region OperativniRadnik


        public static async Task DodajOperativnogRadnik(OperativniRadnikAddView o)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
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
                if (o.InterventnaJedinica != null || o.InterventnaJedinica > 0)
                {
                    InterventnaJedinica ij = await s.GetAsync<InterventnaJedinica>(o.InterventnaJedinica);
                    op.InterventnaJedinica = ij;
                    if (ij != null)
                    {
                        ij.BrojClanova++;

                        await s.UpdateAsync(ij);
                    }
                }
                else
                    op.InterventnaJedinica = null;


                Istorija_Uloga_Zaposlenih i = new Istorija_Uloga_Zaposlenih
                {
                    Zaposleni = op,
                    Uloga = op.GetType().Name,
                    Datum_Od = DateTime.Now,
                    Datum_Do = null
                };

                await s.SaveAsync(op);
                await s.SaveAsync(i);

                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiOperativnogRadnika(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                OperativniRadnik op = await s.LoadAsync<OperativniRadnik>(JMBG);
                if (op == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji OperativniRadnik sa ovim JMBG");
                }
                InterventnaJedinica ij = await s.LoadAsync<InterventnaJedinica>(op.InterventnaJedinica.Jedinstveni_Broj);
                ij.Radnici.Remove(op);
                ij.BrojClanova--;
                await s.UpdateAsync(ij);
                await s.DeleteAsync(op);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniOperativnog(OperativniRadnikAddView o, string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                OperativniRadnik op = await s.LoadAsync<OperativniRadnik>(JMBG);
                op.JMBG = JMBG;
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
                InterventnaJedinica oldij = op.InterventnaJedinica;
                InterventnaJedinica newij = await s.GetAsync<InterventnaJedinica>(o.InterventnaJedinica);
                if (oldij != null && newij != null && op.InterventnaJedinica.Jedinstveni_Broj != o.InterventnaJedinica)
                {
                    newij.BrojClanova++;
                    oldij.BrojClanova--;
                    op.InterventnaJedinica = newij;
                    await s.SaveOrUpdateAsync(newij);
                    await s.SaveOrUpdateAsync(oldij);
                }
                else if (oldij != null && newij == null)
                {
                    oldij.BrojClanova--;
                    op.InterventnaJedinica = null;
                    await s.SaveOrUpdateAsync(oldij);
                }
                else if (oldij == null && newij != null)
                {
                    newij.BrojClanova++;
                    op.InterventnaJedinica = newij;
                    await s.SaveOrUpdateAsync(newij);
                }



                await s.UpdateAsync(op);
                await s.FlushAsync();
                s.Close();
            }
        
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<OperativniRadnikView>> VratiOperativneRadnike()
        {
            List<OperativniRadnikView> sviOp = new List<OperativniRadnikView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviOp = await s.Query<OperativniRadnik>()
                        .Fetch( op => op.InterventnaJedinica)
                        .Select(op => new OperativniRadnikView(op))
                        .ToListAsync();
               
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviOp;
        }

        public static async Task<IList<OperativniRadnikView>> VratiOperativneRadnikeIzJedincie(int IdJedinice)
        {
            List<OperativniRadnikView> sviOp = new List<OperativniRadnikView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviOp = s.Query<OperativniRadnik>()
                      .Fetch(op => op.InterventnaJedinica)
                      .Where(v => v.InterventnaJedinica.Jedinstveni_Broj == IdJedinice)
                      .ToList()
                      .Select(op => new OperativniRadnikView(op))
                      .ToList();


                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviOp;
        }

        public static async Task<OperativniRadnikView> VratiOperativnogRadnika(string JMBG)
        {
            OperativniRadnikView op=null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                OperativniRadnik o = await s.LoadAsync<OperativniRadnik>(JMBG);
                //op.JMBG = o.JMBG;
                //op.Ime = o.Ime;
                //op.Prezime = o.Prezime;
                //op.Datum_Rodjenja = o.Datum_Rodjenja;
                //op.Pol = o.Pol;
                //op.Kontakt_Telefon = o.Kontakt_Telefon;
                //op.Email = o.Email;
                //op.AdresaStanovanja = o.AdresaStanovanja;
                //op.Datum_Zaposlenja = o.Datum_Zaposlenja;
                //op.Broj_Sati = o.Broj_Sati;
                //op.Fizicka_Spremnost = o.Fizicka_Spremnost;
                //op.InterventnaJedinica = o.InterventnaJedinica;

                op= new OperativniRadnikView(o);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return op;
        }

        
        #endregion

        #region Kordinator

        public static async Task DodajKordinatora(KordinatorView k)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kordinator kordinator = new Kordinator();
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.AdresaStanovanja = k.AdresaStanovanja;
                kordinator.BrojTimova = k.BrojTimova;
                Istorija_Uloga_Zaposlenih i = new Istorija_Uloga_Zaposlenih();
                i.Zaposleni = kordinator;
                i.Uloga = kordinator.GetType().Name;
                i.Datum_Od = DateTime.Now;
                i.Datum_Do = null;

                await s.SaveAsync(kordinator);
                await s.SaveAsync(i);

                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiKordinatora(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kordinator z = await s.LoadAsync<Kordinator>(JMBG);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniKordinatora(KordinatorView k,string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kordinator kordinator = await s.LoadAsync<Kordinator>(JMBG);
                kordinator.JMBG = JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;


                Istorija_Uloga_ZaposlenihAddView i = new Istorija_Uloga_ZaposlenihAddView
                {
                    JMBGZaposlenog = kordinator.JMBG,
                    Uloga = kordinator.GetType().ToString(),
                    Datum_Od = DateTime.Now,
                    Datum_Do = null
                };

                await DataProvider.DodajIstorijuUloga(i);

                await s.UpdateAsync(kordinator);
                await s.FlushAsync();
                s.Close();


            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<KordinatorView>> VratiKordinatora()
        {
            List<KordinatorView> sviKordinatori = new List<KordinatorView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviKordinatori = await s.Query<Kordinator>()
                                .Select(s => new KordinatorView(s))
                                .ToListAsync();

                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviKordinatori;
        }

        public static async Task<KordinatorView> VratiKordinator(string JMBG)
        {
            KordinatorView kordinator = new KordinatorView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kordinator k = await s.LoadAsync<Kordinator>(JMBG);
                if(k==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji kordinator sa ovim Id-em");
                }
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.AdresaStanovanja= k.AdresaStanovanja;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return kordinator;
        }


        #endregion

        #region Zaposleni
        
        public static async Task<IList<ZaposleniView>> VratiSveZaposlene()
        {
            var sviZaposleni = new List<ZaposleniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                var analiticari = await s.Query<Analiticar>().ToListAsync();
                var koordinatori = await s.Query<Kordinator>().ToListAsync();
                var operativniradnici = await s.Query<OperativniRadnik>().ToListAsync();
                foreach (var v in analiticari)
                {
                    sviZaposleni.Add(new AnaliticarView(v));
                }
                foreach (var v in koordinatori)
                {
                    sviZaposleni.Add(new KordinatorView(v));
                }
                foreach (var v in operativniradnici)
                {
                    sviZaposleni.Add(new OperativniRadnikView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviZaposleni;
        }

       
       #endregion


        #region SanitetskaVozila

        public static async Task DodajSanitetskaVozilo(SanitetskaAddView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sanitetska vozilo = new Sanitetska();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                await s.SaveAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiSanitetskoVozilo(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo z = await s.LoadAsync<Sanitetska>(RegOznaka);
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                if(z==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji vozilo sa ovom registracijom!");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task  IzmeniSanitetskoVozilo(SanitetskaChangeView v, string Registarska_Oznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sanitetska vozilo = await s.LoadAsync<Sanitetska>(Registarska_Oznaka);
               

                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                await s.UpdateAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SanitetskaView>> VratiSanitetskaVozila()
        {
            List<SanitetskaView> svaVozila = new List<SanitetskaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                
                    svaVozila = await s.Query<Sanitetska>()
                            .Select(s => new SanitetskaView(s))
                            .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        public static async Task<SanitetskaView> VratiSanitetkoVozilo(string RegOznaka)
        {
            SanitetskaView vozilo = new SanitetskaView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sanitetska v = await s.LoadAsync<Sanitetska>(RegOznaka);
                if(v== null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji sanitetsko vozilo sa ovom registracijom");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vozilo;
        }
        #endregion



        #region Specijalna

        public static async Task  DodajSpecijalnoVozilo(SpecijalnaVozilaAddView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaVozila vozilo = new SpecijalnaVozila();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;
                await s.SaveAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task  ObrisiSpecijalnoVozilo(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                SpecijalnaVozila z = await s.LoadAsync<SpecijalnaVozila>(RegOznaka);
                if(z==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji Specijalno vozilo sa ovom registracijom");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniSpecijalnaVozila(SpecijalnaVozilaAddView v, string Registarska_Oznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaVozila vozilo = await s.LoadAsync<SpecijalnaVozila>(Registarska_Oznaka);
                vozilo.Registarska_Oznaka = Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;

                await s.UpdateAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SpecijalnaVozilaView>> VratiSpecijalnaVozila()
        {
            List<SpecijalnaVozilaView> svaVozila = new List<SpecijalnaVozilaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaVozila = await s.Query<SpecijalnaVozila>()
                           .Select(s => new SpecijalnaVozilaView(s))
                           .ToListAsync();
               
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        public static async Task<SpecijalnaVozilaView> VratiSpecijalnoVozilo(string RegOznaka)
        {
            SpecijalnaVozilaView v = new SpecijalnaVozilaView(); //Dodato
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaVozila vozilo = await s.LoadAsync<SpecijalnaVozila>(RegOznaka);
               
                v.Registarska_Oznaka = vozilo.Registarska_Oznaka;
                v.Proizvodjac = vozilo.Proizvodjac;
                v.Status = vozilo.Status;
                v.Lokacija = vozilo.Lokacija;
                v.Namena = vozilo.Namena;
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return v;
        }

        #endregion

        #region Dzipovi
        public static async Task   DodajDzip(DzipoviAddView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dzipovi vozilo = new Dzipovi();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;

                await s.SaveAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiDzip(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dzipovi z = await s.LoadAsync<Dzipovi>(RegOznaka);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniDzip(DzipoviAddView v, string Registarska_Oznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dzipovi vozilo = await s.LoadAsync<Dzipovi>(Registarska_Oznaka);
                vozilo.Registarska_Oznaka = Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                await s.UpdateAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<DzipoviView>> VratiDzipove()
        {
            List<DzipoviView> svaVozila = new List<DzipoviView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaVozila =await s.Query<Dzipovi>()
                        .Select(dz => new DzipoviView(dz))
                        .ToListAsync();
               
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        public static async Task<DzipoviView> VratiDzip(string RegOznaka)
        {
            DzipoviView vozilo = new DzipoviView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dzipovi v = await s.LoadAsync<Dzipovi>(RegOznaka);
                
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vozilo;
        }
        
        #endregion

        #region Kamioni
        public static async Task DodajKamion(KamioniAddView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kamioni vozilo = new Kamioni();
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                await s.SaveAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiKamion(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kamioni z = await s.LoadAsync<Kamioni>(RegOznaka);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task  IzmeniKamion(KamioniAddView v, string Registarska_Oznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kamioni vozilo = await s.LoadAsync<Kamioni>(Registarska_Oznaka);
                vozilo.Registarska_Oznaka = Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                await s.UpdateAsync(vozilo);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<KamioniView>> VratiKamione()
        {
            List<KamioniView> svaVozila = new List<KamioniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaVozila = await s.Query<Kamioni>()
                            .Select(k => new KamioniView(k))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        public static async Task<KamioniView> VratiKamion(string RegOznaka)
        {
            KamioniView vozilo = new KamioniView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kamioni v = await s.LoadAsync<Kamioni>(RegOznaka);
                
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vozilo;
        }
        #endregion

        #region Vozilo
        public static async Task<IList<VoziloView>> VratiSvaVozila()
        {
            var svaVozila = new List<VoziloView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var sanitetska = await s.Query<Sanitetska>()
                                    .ToListAsync();
                var specijalnavozila = await s.Query<SpecijalnaVozila>()
                                   .ToListAsync();
                var dzipovi = await s.Query<Dzipovi>()
                                   .ToListAsync();
                var kamioni = await s.Query<Kamioni>()
                                   .ToListAsync();

                foreach (var vozilo in sanitetska)
                    {

                        svaVozila.Add(new SanitetskaView(vozilo));
                    }
                    foreach(var vozilo in kamioni)
                    {
                        svaVozila.Add(new KamioniView(vozilo));
                    }
                    foreach(var vozilo in dzipovi)
                    {

                        svaVozila.Add(new DzipoviView(vozilo));
                    }
                    foreach(var vozilo in specijalnavozila)
                    {
                        svaVozila.Add(new SpecijalnaVozilaView(vozilo));

                    }
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        public static async Task ObrisiVozilo(string RegOznaka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Vozilo z = await s.LoadAsync<Vozilo>(RegOznaka);
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
               
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        #endregion
        #region Sertifikat
        public static async Task  DodajSertifikat(SertifikatView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
               
                Sertifikat sertifikat1 = new Sertifikat();
                OperativniRadnik op= await sess.LoadAsync<OperativniRadnik>(s.Id.JMBGRadnika);
                SertifikatId id = new SertifikatId
                {
                    OperativniRadnik = op,
                    Naziv = s.Id.Naziv,
                    Institucija = s.Id.Institucija
                };
              
                sertifikat1.Id = id;
                if (s.DatumIzdavanja > DateTime.Now)
                    throw new Exception("Datum izdavanja ne može biti u budućnosti.");

               
                if (s.DatumVazenja == null)
                {
                    sertifikat1.DatumIzdavanja = s.DatumIzdavanja;
                    sertifikat1.DatumVazenja = null;
                }
                else
                {
                  
                    if (s.DatumVazenja <= s.DatumIzdavanja)
                        throw new Exception("Datum važenja mora biti posle datuma izdavanja.");

                    sertifikat1.DatumIzdavanja = s.DatumIzdavanja;
                    sertifikat1.DatumVazenja = s.DatumVazenja;
                }

                await sess.SaveOrUpdateAsync(sertifikat1);

                await sess.FlushAsync();

                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiSertifikat(SertifikatIdAddView se)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SertifikatId id = new SertifikatId
                {
                    OperativniRadnik = await s.LoadAsync<OperativniRadnik>(se.JMBGRadnika),
                    Naziv = se.Naziv,
                    Institucija = se.Institucija
                };
                Sertifikat z = await s.LoadAsync<Sertifikat>(id);
               
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniSertifikat(SertifikatView sert)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SertifikatId id = new SertifikatId();
                id.OperativniRadnik = await s.LoadAsync<OperativniRadnik>(sert.Id);
                id.Naziv = sert.Id.Naziv;
                id.Institucija = sert.Id.Institucija;
                Sertifikat sertifikat = await s.LoadAsync<Sertifikat>(id);
                
                sertifikat.DatumIzdavanja = sert.DatumIzdavanja;
                sertifikat.DatumVazenja = sert.DatumVazenja;
                await  s.SaveOrUpdateAsync(sertifikat);

                await s.FlushAsync();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SertifikatGetView>> VratiSertifikate()
        {
            List<SertifikatGetView> sviSertifikati = new List<SertifikatGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviSertifikati =await s.Query<Sertifikat>()

                                .Select(s => new SertifikatGetView(s))
                                .ToListAsync();

                

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return sviSertifikati;
        }
        public static async Task<IList<SertifikatGetView>> VratiSertifikateZaposlenog(string JMBGZaposlenog)
        {
            List<SertifikatGetView> sviSertifikati = new List<SertifikatGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviSertifikati = s.Query<Sertifikat>()
                                
                                .Where(s => s.Id.OperativniRadnik.JMBG==JMBGZaposlenog)
                                .ToList()
                                .Select(s => new SertifikatGetView(s))
                                .ToList();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return sviSertifikati;
        }

        public static async Task<SertifikatView> VratiSertifikat(string JMBG,string Naziv, string Institucija)
        {
            SertifikatView sertifikat = new SertifikatView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SertifikatId sId = new SertifikatId
                {
                    OperativniRadnik = await sess.LoadAsync<OperativniRadnik>(JMBG),
                    Naziv = Naziv,
                    Institucija = Institucija
                };
                Sertifikat s = await sess.LoadAsync<Sertifikat>(sId);
                
                sertifikat.DatumIzdavanja = s.DatumIzdavanja;
                sertifikat.DatumVazenja = s.DatumVazenja;
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sertifikat;
        }

        
        #endregion


        #region Ekspertiza

        public static async Task   DodajEkspertizu(EkspertizaChangeView e)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ekspertiza ekspertiza = new Ekspertiza();
                ekspertiza.Analiticar = await sess.LoadAsync<Analiticar>(e.JMBGAnaliticara);
                
                ekspertiza.Oblast = e.Oblast;
                await sess.SaveAsync(ekspertiza);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   ObrisiEkspertizu(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ekspertiza z = await s.LoadAsync<Ekspertiza>(Id);
               
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniEkspertizu(EkspertizaChangeView e, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ekspertiza ekspertiza = await sess.LoadAsync<Ekspertiza>(Id);
                
                ekspertiza.Analiticar = await sess.LoadAsync<Analiticar>(e.JMBGAnaliticara);
                
                ekspertiza.Oblast = e.Oblast;
                await sess.UpdateAsync(ekspertiza);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<EkspertizaView>> VratiEkspertize()
        {
            List<EkspertizaView> sveEkspertize = new List<EkspertizaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveEkspertize = await s.Query<Ekspertiza>()
                               .Fetch(e => e.Analiticar)
                               .Select(e => new EkspertizaView(e))
                               .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveEkspertize;
        }

        public static async Task<IList<EkspertizaView>> VratiEkspertizeAnaliticara(string JMBG)
        {
            List<EkspertizaView> sveEkspertize = new List<EkspertizaView>();
            try
            {
                ISession s = DataLayer.GetSession();
               
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveEkspertize =await s.Query<Ekspertiza>()
                               .Fetch(e => e.Analiticar)
                               .Where(e=> e.Analiticar.JMBG==JMBG)
                               .Select(e => new EkspertizaView(e))
                               .ToListAsync();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveEkspertize;
        }
        public static async Task<EkspertizaView> VratiEkspertizu(int Id)
        {
            EkspertizaView ekspertiza = new EkspertizaView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ekspertiza e = await sess.LoadAsync<Ekspertiza>(Id);
               
                ekspertiza = new EkspertizaView(e);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ekspertiza;
        }
        #endregion

        #region Specijalizacija

        public static async Task  DodajSpecijalizaciju(SpecijalizacijaAddView sp)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija specijalizacija = new Specijalizacija();

                specijalizacija.Kordinator = await sess.LoadAsync<Kordinator>(sp.JMBG_Kordinator);
               
                specijalizacija.Tip = sp.Tip;
                await sess.SaveAsync(specijalizacija);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiSpecijalizaciju(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija z = await s.LoadAsync<Specijalizacija>(Id);
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniSpecijalizaciju(SpecijalizacijaAddView sp, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija specijalizacija = await sess.LoadAsync<Specijalizacija>(Id);
                specijalizacija.Kordinator = await sess.LoadAsync<Kordinator>(sp.JMBG_Kordinator);
                
                specijalizacija.Tip = sp.Tip;
                await sess.UpdateAsync(specijalizacija);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

        }
        public static async Task<IList<SpecijalizacijaView>> VratiSpecijalizacije()
        {
            List<SpecijalizacijaView> sveSpecijalizacije = new List<SpecijalizacijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveSpecijalizacije = await s.Query<Specijalizacija>()
                                    .Fetch(s => s.Kordinator)
                                    .Select(s => new SpecijalizacijaView(s))
                                    .ToListAsync();
                
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveSpecijalizacije;
        }

        public static async Task<IList<SpecijalizacijaView>> VratiSpecijalizacijeKoordinatora(string JMBG)
        {
            List<SpecijalizacijaView> sveSpecijalizacije = new List<SpecijalizacijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sveSpecijalizacije = await s.Query<Specijalizacija>()
                                    .Where(s=> s.Kordinator.JMBG==JMBG)
                                    .Fetch(s => s.Kordinator)
                                    .Select(s => new SpecijalizacijaView(s))
                                    .ToListAsync();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sveSpecijalizacije;
        }

        public static async Task<SpecijalizacijaView> VratiSpecijalizaciju(int Id)
        {
            SpecijalizacijaView specijalizacija = new SpecijalizacijaView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija sp = await sess.LoadAsync<Specijalizacija>(Id);
                specijalizacija = new SpecijalizacijaView(sp);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return specijalizacija;
        }
        #endregion

        #region Oprema
        #region LicnaZastita
        public static async Task   DodajLicnuZastitu(LicnaZastitaAddView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita liz = new LicnaZastita();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;
                await s.SaveAsync(liz);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiLicnuZastitu(string SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita z = await s.LoadAsync<LicnaZastita>(SerijskiBroj);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniLicnuZastitu(LicnaZastitaAddView l, string Serijski_Broj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita liz = await s.LoadAsync<LicnaZastita>(Serijski_Broj);
                liz.Serijski_Broj = Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;


                await s.UpdateAsync(liz);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<LicnaZastitaAddView>> VratiOpremuLicneZastite()
        {
            List<LicnaZastitaAddView> svaOprema = new List<LicnaZastitaAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                svaOprema = await  s.Query<LicnaZastita>()
                           .Fetch(s=>s.Jedinica)
                           .Select(l => new LicnaZastitaAddView(l))
                           .ToListAsync();
              
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<LicnaZastitaAddView> VratiLicnuZastitu(string SerijskiBroj)
        {
            LicnaZastitaAddView liz = null ;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita l = await s.LoadAsync<LicnaZastita>(SerijskiBroj);
               
                liz = new LicnaZastitaAddView(l);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<LicnaZastitaMiniView>> VratiLicnuOpremuJedinice(int idJedinice)
        {
            List<LicnaZastitaMiniView> svaOprema = new List<LicnaZastitaMiniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema = await s.Query<LicnaZastita>()
                            .Fetch(s => s.Jedinica)
                            .Where(s => s.Jedinica.Jedinstveni_Broj == idJedinice)
                            .Select(l => new LicnaZastitaMiniView(l))
                            .ToListAsync();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        #endregion

        #region MedicinskaOprema

        public static async Task   DodajMedicinskuOpremu(MedicinskaOpremaAddView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                MedicinskaOprema liz = new MedicinskaOprema();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;
                await s.SaveAsync(liz);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiMedicinskuOpremu(string SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                MedicinskaOprema z = await s.LoadAsync<MedicinskaOprema>(SerijskiBroj);
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniMedicinskuOpremu(string SerijskiBroj, MedicinskaOpremaAddView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                MedicinskaOprema liz = await s.LoadAsync<MedicinskaOprema>(SerijskiBroj);
                liz.Serijski_Broj = SerijskiBroj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;


                await s.UpdateAsync(liz);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<MedicinskaOpremaAddView>> VratiMedicinskuZastitu()
        {
            List<MedicinskaOpremaAddView> svaOprema = new List<MedicinskaOpremaAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema = await s.Query<MedicinskaOprema>()
                            .Fetch(i => i.Jedinica)
                            .Select(med => new MedicinskaOpremaAddView(med))
                            .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<MedicinskaOpremaAddView> VratiMedicinskuOpremu(string SerijskiBroj)
        {
            MedicinskaOpremaAddView liz = new MedicinskaOpremaAddView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                MedicinskaOprema l = await s.LoadAsync<MedicinskaOprema>(SerijskiBroj);
               
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.JedinicaID = l.Jedinica.Jedinstveni_Broj;
                liz.Tip = l.Tip;
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<MedicinskaOpremaMiniView>> VratiMedicinskuOpremuJedinice(int idJedinice)
        {
            List<MedicinskaOpremaMiniView> svaOprema = new List<MedicinskaOpremaMiniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema =await  s.Query<MedicinskaOprema>()
                            .Fetch(s => s.Jedinica)
                            .Where(s => s.Jedinica.Jedinstveni_Broj == idJedinice)
                            .Select(m => new MedicinskaOpremaMiniView(m))
                            .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        #endregion

        #region TehnickaOprema
        public static async Task   DodajTehnickuOpremu(TehnickaOpremaAddView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                TehnickaOprema liz = new TehnickaOprema();
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;
                await s.SaveAsync(liz);
                await s.FlushAsync();
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   ObrisiTehnickuOpremu(string SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                TehnickaOprema z = await s.LoadAsync<TehnickaOprema>(SerijskiBroj);
                if(z==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji tehnicka oprema sa ovim serijskim brojem");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniTehnickuOpremu(TehnickaOpremaAddView l, string Serijski_Broj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                TehnickaOprema liz = await s.LoadAsync<TehnickaOprema>(Serijski_Broj);
                liz.Serijski_Broj = Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;
                await s.UpdateAsync(liz);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<TehnickaOpremaAddView>> VratiTehnickuZastitu()
        {
            List<TehnickaOpremaAddView> svaOprema = new List<TehnickaOpremaAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema = await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Select(l => new TehnickaOpremaAddView(l))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<TehnickaOpremaAddView> VratiTehnickuOpremu(string SerijskiBroj)
        {
            TehnickaOpremaAddView liz = null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                TehnickaOprema l = await s.LoadAsync<TehnickaOprema>(SerijskiBroj);

                liz = new TehnickaOpremaAddView(l);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<TehnickaOpremaMiniView>> VratiTehnickuOpremuJedinice(int idJedinice)
        {
            List<TehnickaOpremaMiniView> svaOprema = new List<TehnickaOpremaMiniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                svaOprema =await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == idJedinice)
                           .Select(t => new TehnickaOpremaMiniView(t))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        
        public static async Task DodajZalihe(ZaliheAddView z)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe zalihe = new Zalihe
                {
                    Serijski_Broj = z.Serijski_Broj,
                    Naziv = z.Naziv,
                    Status = z.Status,
                    DatumNabavke = z.DatumNabavke,
                    Jedinica = await s.GetAsync<InterventnaJedinica>(z.JedinicaID),
                    Kolicina = z.Kolicina,
                    Tip = z.Tip
                };

                await s.SaveAsync(zalihe);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiZalihe(string SerijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe z = await s.LoadAsync<Zalihe>(SerijskiBroj);
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao na je ne postoji zaliha sa ovim serijskim brojem");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task  IzmeniZalihe(ZaliheAddView z, string Serijski_Broj)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe zalihe = await s.LoadAsync<Zalihe>(Serijski_Broj);
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao na je ne postoji zaliha sa ovim serijskim brojem");
                }
                zalihe.Serijski_Broj = Serijski_Broj;
                zalihe.Naziv = z.Naziv;
                zalihe.Status = z.Status;
                zalihe.DatumNabavke = z.DatumNabavke;
                zalihe.Jedinica = await s.GetAsync<InterventnaJedinica>(z.JedinicaID);
                zalihe.Kolicina = z.Kolicina;
                zalihe.Tip = z.Tip;
                await s.UpdateAsync(zalihe);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<ZaliheAddView>> VratiZalihe()
        {
            List<ZaliheAddView> svaOprema = new List<ZaliheAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema =await  s.Query<Zalihe>()
                           .Fetch(s => s.Jedinica)
                            .Select(z => new ZaliheAddView(z))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        public static async Task<ZaliheAddView> VratiZalihe(string SerijskiBroj)
        {
            ZaliheAddView liz=null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe z = await s.LoadAsync<Zalihe>(SerijskiBroj);
                liz = new ZaliheAddView(z);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<ZaliheMiniView>> VratiZaliheJedinice(int idJedinice)
        {
            List<ZaliheMiniView> svaOprema = new List<ZaliheMiniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema =await s.Query<Zalihe>()
                            .Fetch(s => s.Jedinica)
                            .Where(s => s.Jedinica.Jedinstveni_Broj == idJedinice)

                            .Select(z => new ZaliheMiniView(z))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        #endregion

        
        public static async Task<IList<OpremaAddView>> VratiSvuOpremu()
        {
            List<OpremaAddView> svaOprema = new List<OpremaAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var licnazastita =await s.Query<LicnaZastita>()
                           .Fetch(s => s.Jedinica)
                           .ToListAsync();
                var medicinska = await s.Query<MedicinskaOprema>()
                           .Fetch(s => s.Jedinica)
                           .ToListAsync();
                var tehnicka = await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .ToListAsync();
                var zalihe = await s.Query<Zalihe>()
                           .Fetch(s => s.Jedinica)
                           .ToListAsync();
              

                    foreach (var o in licnazastita)
                    {
                        svaOprema.Add(new LicnaZastitaAddView(o));
                    }
                    foreach(var o in medicinska)
                    {
                        svaOprema.Add(new MedicinskaOpremaAddView(o));
                    }
                    foreach(var o in tehnicka)
                    {
                        svaOprema.Add(new TehnickaOpremaAddView(o));
                    }
                    foreach(var o in zalihe)
                    {

                        svaOprema.Add(new ZaliheAddView(o));
                    }
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<IList<OpremaMiniView>> VratiSvuOpremuJedinice(int IdJed)
        {
            List<OpremaMiniView> svaOprema = new List<OpremaMiniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var svaLOpremaQuery =await  s.Query<LicnaZastita>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == IdJed)
                           .ToListAsync();
                var svaMOpremaQuery = await s.Query<MedicinskaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == IdJed)
                           .ToListAsync();
                var svaZYOpremaQuery = await s.Query<Zalihe>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == IdJed)
                           .ToListAsync();
                var svaTOpremaQuery = await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == IdJed)
                           .ToListAsync();
                foreach (var o in svaLOpremaQuery)
                {
                    svaOprema.Add(new LicnaZastitaMiniView(o));
                }
                foreach (var o in svaMOpremaQuery)
                {
                    svaOprema.Add(new MedicinskaOpremaMiniView(o));
                }
                foreach (var o in svaTOpremaQuery)
                {
                    svaOprema.Add(new TehnickaOpremaMiniView(o));
                }
                foreach (var o in svaZYOpremaQuery)
                {

                    svaOprema.Add(new ZaliheMiniView(o));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        #endregion Oprema

        #region Predstavnik

        public static async Task   DodajPredstavnika(PredstavnikView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Predstavnik predstavnik = new Predstavnik();
                predstavnik.JMBG = p.JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                
                await s.SaveAsync(predstavnik);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiPredstavnika(string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Predstavnik z = await s.LoadAsync<Predstavnik>(JMBG);
                await s.DeleteAsync(z);
               await  s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniPredstavnika(PredstavnikView p, string JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Predstavnik predstavnik = await s.LoadAsync<Predstavnik>(JMBG);
                predstavnik.JMBG = JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                await s.UpdateAsync(predstavnik);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<PredstavnikView>> VratiPredstavnike()
        {
            List<PredstavnikView> sviPredstavnici = new List<PredstavnikView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviPredstavnici =await s.Query<Predstavnik>()
                                .Select(s => new PredstavnikView(s))
                                .ToListAsync();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviPredstavnici;
        }

        public static  async Task<PredstavnikView> VratiPredstavnika(string JMBG)
        {
            PredstavnikView predstavnik = new PredstavnikView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Predstavnik p = await s.LoadAsync<Predstavnik>(JMBG);
                predstavnik = new PredstavnikView(p);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return predstavnik;
        }


        public static  async Task<PredstavnikView> VratiPredstacnikaJedinice(int IdSluzbe)
        {
            PredstavnikView predstavnik = new PredstavnikView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba sluzba = await s.LoadAsync<Sluzba>(IdSluzbe);
                
               
                Predstavnik p = sluzba.Predstavnik;
                predstavnik = await DataProvider.VratiPredstavnika(p.JMBG);
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return predstavnik;
        }

        #endregion



        #region Servisi
        public static async Task   DodajServis(ServisiAddView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Servisi servis = new Servisi();
                servis.Vozilo = await sess.LoadAsync<Vozilo>(s.RegistarskaOznakaVozila);
               
                servis.TipServisa = s.TipServisa;
                servis.Datum = s.Datum;
                await sess.SaveAsync(servis);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }


        public static async Task   ObrisiServis(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
               
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Servisi z = await s.LoadAsync<Servisi>(Id);
               
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniServis(ServisiAddView s, int Id)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Servisi Servis = session.Load<Servisi>(Id);
                
                Servis.Vozilo = session.Load<Vozilo>(s.RegistarskaOznakaVozila);
                Servis.TipServisa = s.TipServisa;
                Servis.Datum = s.Datum;
                await session.UpdateAsync(Servis);
                await session.FlushAsync();
                session.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

        }

        public static async Task<IList<ServisiView>> VratiServise()
        {
            List<ServisiView> sviServisi = new List<ServisiView>();
            try
            {
                ISession s = DataLayer.GetSession();
                
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviServisi = await s.Query<Servisi>()
                            .Fetch(v=> v.Vozilo)
                            .Select(s => new ServisiView(s))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviServisi;
        }

       

        public static async Task<IList<ServisiView>> VratiServiseVozila(string RegistracijaVozilo)
        {
            List<ServisiView> sviServisi = new List<ServisiView>();
            try
            {
                ISession s = DataLayer.GetSession();
                sviServisi =await s.Query<Servisi>()
                           .Fetch(v => v.Vozilo)
                           .Where(s => s.Vozilo.Registarska_Oznaka == RegistracijaVozilo)
                           .Select(s => new ServisiView(s))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sviServisi;
        }
        #endregion

        #region IstorijaUlogaZaposlenih
        public static async Task   DodajIstorijuUloga(Istorija_Uloga_ZaposlenihAddView i)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija_Uloga_Zaposlenih istorija = new Istorija_Uloga_Zaposlenih();
                istorija.Zaposleni = await sess.LoadAsync<Zaposlen>(i.JMBGZaposlenog);
                istorija.Uloga = i.Uloga;
                if (i.Datum_Do <= i.Datum_Od)
                {
                    throw new Exception("Zao nam je ali ne mozete upisati ovu vrednost");
                }
                istorija.Datum_Od = i.Datum_Od;
                istorija.Datum_Do = i.Datum_Do;
                await sess.SaveAsync(istorija);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   ObrisiIstorijuUloga(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija_Uloga_Zaposlenih z = await s.LoadAsync<Istorija_Uloga_Zaposlenih>(Id);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }


        public static async Task  ObrisiCeluIstorijuKorisnika(string JMBG)
        {
            List<Istorija_Uloga_Zaposlenih> istorija = new List<Istorija_Uloga_Zaposlenih>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                istorija =await  s.Query<Istorija_Uloga_Zaposlenih>()
                            .Fetch(s => s.Zaposleni)
                            .Where(s => s.Zaposleni.JMBG == JMBG)
                            .ToListAsync();

                foreach(Istorija_Uloga_Zaposlenih i in istorija)
                {
                    await s.DeleteAsync(i);
                }
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   IzmeniIstorijuUloga(Istorija_Uloga_ZaposlenihAddView i, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija_Uloga_Zaposlenih istorija = await sess.LoadAsync<Istorija_Uloga_Zaposlenih>(Id);
                
                istorija.Zaposleni = await sess.LoadAsync<Zaposlen>(i.JMBGZaposlenog);
               
                istorija.Uloga = i.Uloga;
                istorija.Datum_Od = i.Datum_Od;
                istorija.Datum_Do = i.Datum_Do;
                await sess.UpdateAsync(istorija);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<Istorija_Uloga_ZaposlenihView>> VratiIstoriju()
        {
            List<Istorija_Uloga_ZaposlenihView> Istorija = new List<Istorija_Uloga_ZaposlenihView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija = await s.Query<Istorija_Uloga_Zaposlenih>()
                                .Select(x => new Istorija_Uloga_ZaposlenihView
                                {
                                    Id = x.Id,
                                    Uloga = x.Uloga,
                                    JMBGZaposlenog = x.Zaposleni.JMBG, 
                                    Datum_Od = x.Datum_Od,
                                    Datum_Do = x.Datum_Do
                                })
                                .ToListAsync();
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Istorija;
        }

        public static IList<Istorija_Uloga_ZaposlenihAddView> VratiIstorijuu()
        {
            List<Istorija_Uloga_ZaposlenihAddView> Istorija = new List<Istorija_Uloga_ZaposlenihAddView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija =  s.Query<Istorija_Uloga_Zaposlenih>()
                                .Select(x => new Istorija_Uloga_ZaposlenihAddView
                                {
                                    
                                    Uloga = x.Uloga,
                                    JMBGZaposlenog = x.Zaposleni.JMBG,
                                    Datum_Od = x.Datum_Od,
                                    Datum_Do = x.Datum_Do
                                })
                                .ToList();
                s.Close();
            }
            catch (Exception e)
            {
            }
            return Istorija;
        }

        public static async Task<Istorija_Uloga_ZaposlenihView> VratiIstorijuU(int Id) 
        {
            Istorija_Uloga_ZaposlenihView istorija=null;
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija_Uloga_Zaposlenih ist = await sess.LoadAsync<Istorija_Uloga_Zaposlenih>(Id);
                istorija = new Istorija_Uloga_ZaposlenihView(ist);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return istorija;
        }

        public static async Task<IList<Istorija_Uloga_ZaposlenihView>> VratiIstorijuUZaposlenog(string JMBGZaposleni)
        {
            List<Istorija_Uloga_ZaposlenihView> Istorija = new List<Istorija_Uloga_ZaposlenihView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Istorija = await s.Query<Istorija_Uloga_Zaposlenih>()
                                 .Fetch(s=>s.Zaposleni)
                                 .Where(s=> s.Zaposleni.JMBG== JMBGZaposleni)
                                .Select(s => new Istorija_Uloga_ZaposlenihView(s))
                                .ToListAsync();
                
                s.Close();
            }
            
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Istorija;
        }
        #endregion

        #region DodeljujeSe
        public static async Task DodajDodeljivanje(DodeljujeSeAddView d)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                DodeljujeSe dodeljivanje = new DodeljujeSe();
                var vozilo = await sess.LoadAsync<Vozilo>(d.RegVozilo);
                dodeljivanje.Vozilo = vozilo;
                var Jedinica = await sess.GetAsync<InterventnaJedinica>(d.IdJedinica);
                var Radnik = await sess.GetAsync<OperativniRadnik>(d.JMBGRadnik);
                if(vozilo.Status==StatusVozila.U_kvaru)
                {
                    throw new Exception("Zao nam je ali vozilo se ne moze dodeliti jer je u kvaru");
                }
                if (vozilo is Dzipovi && d.IdJedinica.HasValue)
                {
                    throw new Exception("Zao nam je nije moguce dodeliti ovaj tip vozila jedinici");
                }
                else if (d.IdJedinica.HasValue && d.JMBGRadnik.IsNotEmpty())
                {
                    throw new Exception("Nije moguce da radnik i jedinica imaju vrednosti u ovoj tabeli");
                }
                dodeljivanje.Radnik = Radnik;
                dodeljivanje.Jedinica = Jedinica;
                if (d.DatumDo <= d.DatumOd)
                {
                    throw new Exception("Zao nam je ali ne mozete upisati ovu vrednost");
                }
                dodeljivanje.DatumOd = d.DatumOd;
                dodeljivanje.DatumDo = d.DatumDo;

                await sess.SaveAsync(dodeljivanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiDodeljivanje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                DodeljujeSe z = await s.LoadAsync<DodeljujeSe>(Id);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task IzmeniDodeljujeSe(DodeljujeSeAddView d, int Id)
        {
            
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                DodeljujeSe dodela = await sess.LoadAsync<DodeljujeSe>(Id);

                var vozilo = await sess.LoadAsync<Vozilo>(d.RegVozilo);
                if (vozilo.Status == StatusVozila.U_kvaru)
                {
                    throw new Exception("Zao nam je ali vozilo se ne moze dodeliti jer je u kvaru");
                }
                dodela.Vozilo = vozilo;

                var Jedinica = await sess.LoadAsync<InterventnaJedinica>(d.IdJedinica);
                var Radnik = await sess.LoadAsync<OperativniRadnik>(d.JMBGRadnik);
                if (vozilo is Dzipovi && d.IdJedinica.HasValue)
                {
                    throw new Exception("Zao nam je nije moguce dodeliti ovaj tip vozila jedinici");
                }
                else if (d.IdJedinica.HasValue && d.JMBGRadnik.IsNotEmpty())
                {
                    throw new Exception("Nije moguce da radnik i jedinica imaju vrednosti u ovoj tabeli");
                }
                dodela.Radnik = Radnik;
                dodela.Jedinica = Jedinica;
                dodela.DatumOd = d.DatumOd;
                dodela.DatumDo = d.DatumDo;
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        

        public static async Task<IList<DodeljujeSeGetView>> VratiSvaDodeljivanja()
        {
            List<DodeljujeSeGetView> Dodeljivanja = new List<DodeljujeSeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dodeljivanja =await  s.Query<DodeljujeSe>()
                        //      .Fetch(s => s.Radnik)
                         //     .Fetch(s => s.Jedinica)
                              .Select(s=> new DodeljujeSeGetView(s))
                              .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Dodeljivanja;
        }

        public static async Task<DodeljujeSeGetView> VratiDodeljivanje(int Id)
        {
            DodeljujeSeGetView d = new DodeljujeSeGetView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                DodeljujeSe dodeljivanje= await s.LoadAsync<DodeljujeSe>(Id);
                d= new DodeljujeSeGetView(dodeljivanje);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return d;
        }
        public static async Task<IList<DodeljujeSeView>> VratiDodeljivanjaVozila(string RegVozilo)
        {
            List<DodeljujeSeView> Dodeljivanja = new List<DodeljujeSeView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dodeljivanja =await s.Query<DodeljujeSe>()
                             .Fetch(s => s.Radnik)
                             .Fetch(s => s.Jedinica)
                             .Where(s=> s.Vozilo.Registarska_Oznaka==RegVozilo)
                             .Select(s => new DodeljujeSeView(s))
                             .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Dodeljivanja;
        }

        public static async Task<IList<VoziloView>> VratiDodeljenaVozilaRadniku(string JMBGPojedinac)
        {
            List<VoziloView> Vozila = new List<VoziloView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var DodeljujeSe =await s.Query<DodeljujeSe>()
                                .Where(s => s.Radnik.JMBG == JMBGPojedinac)
                                .Fetch(s => s.Vozilo)
                                .ToListAsync();
                foreach (var dodeljena in DodeljujeSe)
                {
                    Vozila.Add(new VoziloView(dodeljena.Vozilo));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Vozila;
        }

        public static async Task<IList<VoziloView>> VratiDodeljivanjaJedinic(int IdJedinica)
        {
            List<VoziloView> Vozila = new List<VoziloView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var DodeljujeSe =await s.Query<DodeljujeSe>()
                                .Where(s => s.Jedinica.Jedinstveni_Broj == IdJedinica)
                                .Fetch(s => s.Vozilo)
                                .ToListAsync();
                foreach (var dodeljena in DodeljujeSe)
                {
                    Vozila.Add(new VoziloView(dodeljena.Vozilo));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Vozila;
        }
        #endregion

        #region Saradjuje
        public static async Task   DodajSaradnju(SaradjujeAddView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Saradjuje saradnja = new Saradjuje();
                saradnja.Uloga= s.Uloga;
                saradnja.Sektor = await sess.LoadAsync<Sluzba>(s.SektorID);
                saradnja.VandrednaSituacija = await sess.LoadAsync<VanrednaSituacija>(s.VanrednaSituacijaID);
                
                await sess.SaveAsync(saradnja);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiSaradnju(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Saradjuje z = await s.LoadAsync<Saradjuje>(Id);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniSaradnju(SaradjujeAddView s, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Saradjuje saradnja = await sess.LoadAsync<Saradjuje>(Id);
               
                saradnja.Uloga = s.Uloga;
                saradnja.Sektor = await sess.LoadAsync<Sluzba>(s.SektorID);
                saradnja.VandrednaSituacija = await sess.LoadAsync<VanrednaSituacija>(s.VanrednaSituacijaID);
               
                await sess.UpdateAsync(saradnja);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SaradjujeGetView>> VratiSaradnje()
        {
            List<SaradjujeGetView> Saradnje = new List<SaradjujeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Saradnje =await  s.Query<Saradjuje>()
                         .Fetch(s => s.VandrednaSituacija)
                         .Fetch(s => s.Sektor)
                         .Select(s => new SaradjujeGetView(s))
                         .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Saradnje;
        }

        public static async Task<SaradjujeView> VratiSaradnju(int Id)
        {
            SaradjujeView saradnja = new SaradjujeView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Saradjuje s = await sess.LoadAsync<Saradjuje>(Id);
               
               
                saradnja = new SaradjujeView(s);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return saradnja;
        }
        public static async Task<IList<SluzbaView>> VratiSveSluzbeUVandrednojSituaciji(int IdVS)
        { 
                List<SluzbaView> Sluzba = new List<SluzbaView>();
                try
                {
                    ISession s = DataLayer.GetSession();

                var Saradnja = await s.Query<Saradjuje>()
                               .Where(s => s.VandrednaSituacija.Id == IdVS)
                               .Fetch(s => s.Sektor)
                               .ToListAsync();

                    foreach (var S in Saradnja)
                    {
                        Sluzba.Add(new SluzbaView(S.Sektor));
                    }

                    

                }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return Sluzba;
           
        }

        public static async Task<IList<VanrednaSituacijaView>> VratiSveUVanredneSituacijeUKojojJeUcestvovalaSluzba(int IdSluzbe)
        {
            List<VanrednaSituacijaView> VSituacije = new List<VanrednaSituacijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                var Saradnja =await  s.Query<Saradjuje>()
                               .Where(s => s.Sektor.Id_Sektora == IdSluzbe)
                               .Fetch(s => s.VandrednaSituacija)
                               .ToListAsync();

                foreach (var S in Saradnja)
                {
                    VSituacije.Add(new VanrednaSituacijaView(S.VandrednaSituacija));
                }



            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return VSituacije;

        }
        #endregion

        #region Ucestvovalo
        public static async Task   DodajUcestvovanje(UcestvovaloAddView u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvovalo ucestvovanje = new Ucestvovalo();
                ucestvovanje.Vozilo = await sess.LoadAsync<Vozilo>(u.VoziloReg);
                ucestvovanje.Intervencija = await sess.LoadAsync<Intervencija>(u.IntervencijaID);

                //TODO proveriti logiku ovoga
                if (u.Datum_Od >= DateTime.Now)
                {

                    ucestvovanje.Datum_Od = DateTime.Now;
                    ucestvovanje.Datum_Do = null;
                }
                else
                    ucestvovanje.Datum_Od = u.Datum_Od;
                if (u.Datum_Do <= u.Datum_Od)
                {
                    throw new Exception("Zao nam je ali ne mozete upisati ovu vrednost");
                }
                else
                    ucestvovanje.Datum_Do = ucestvovanje.Datum_Do;
                await sess.SaveAsync(ucestvovanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiUcestvovanje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvovalo ucestvuje = await s.LoadAsync<Ucestvovalo>(Id);
               
                await s.DeleteAsync(ucestvuje);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniUcestvovanje(UcestvovaloAddView u, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess== null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
               
                Ucestvovalo ucestvovanje = await sess.LoadAsync<Ucestvovalo>(Id);
               
                ucestvovanje.Vozilo = await sess.LoadAsync<Vozilo>(u.VoziloReg);
                ucestvovanje.Intervencija = await sess.LoadAsync<Intervencija>(u.IntervencijaID);
                
                ucestvovanje.Datum_Od = u.Datum_Od;
                ucestvovanje.Datum_Do = u.Datum_Do;
                await sess.UpdateAsync(ucestvovanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<UcestvovaloGetView>> VratiUcestvovanja()
        {
            List<UcestvovaloGetView> ucestvovalo = new List<UcestvovaloGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                
                ucestvovalo =await s.Query<Ucestvovalo>()
                            .Fetch(v => v.Vozilo)
                            .Fetch(i => i.Intervencija)
                            .Select(s => new UcestvovaloGetView(s))
                            .ToListAsync();
              
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return ucestvovalo;
        }
        public static async Task<UcestvovaloGetView> VratiUcestvovanje(int Id)
        {
            UcestvovaloGetView ucestv = new UcestvovaloGetView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvovalo u = await sess.LoadAsync<Ucestvovalo>(Id);
               
                ucestv = new UcestvovaloGetView(u);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestv;
        }

        public static async Task<IList<UcestvovaloView>> VratiUcestvovanjaVozilaU(int IntervencijaId)
        {
            List<UcestvovaloView> ucestvovalo = new List<UcestvovaloView>();
            try
            {
                ISession s = DataLayer.GetSession();

                var Ucestvovalo = await s.Query<Ucestvovalo>()
                                .Fetch(s => s.Vozilo)
                                .Where(s => s.Intervencija.Id == IntervencijaId)
                                .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    ucestvovalo.Add(new UcestvovaloView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;
        }


        public static async Task<IList<VoziloView>> VratiUcestvovanjaVozilaUIntervencijama(int IntervencijaId)
        {
            List<VoziloView> vozila = new List<VoziloView>();
            try
            {
                ISession s = DataLayer.GetSession();

                var Ucestvovalo =await s.Query<Ucestvovalo>()
                                .Fetch(s => s.Vozilo)
                                .Where(s => s.Intervencija.Id == IntervencijaId)
                                .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    vozila.Add(new VoziloView(v.Vozilo));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return vozila;
        }
        public static async Task<IList<IntervencijaView>> VratiIntervencijeUKojimajeUcestvovaloVozilo(string RegOznaka)
        {
            List<IntervencijaView> Intervencije = new List<IntervencijaView>();
            try
            {
                ISession s = DataLayer.GetSession();

                var Ucestvovalo =await s.Query<Ucestvovalo>()
                                //.Fetch(s => s.Intervencija)
                                .Where(s => s.Vozilo.Registarska_Oznaka == RegOznaka)
                                .ToListAsync();
                foreach (var v in Ucestvovalo)
                { 
                    Intervencije.Add(new IntervencijaView(v.Intervencija));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Intervencije;
        }

        public static async Task<IList<UcestvovaloView>> VratiUcestvovanjeVozilaUKojimajeUcestvovalo(string RegOznaka)
        {
            List<UcestvovaloView> ucestvovalo = new List<UcestvovaloView>();
            try
            {
                ISession s = DataLayer.GetSession();

                var Ucestvovalo = await s.Query<Ucestvovalo>()
                                .Fetch(s => s.Intervencija)
                                .Where(s => s.Vozilo.Registarska_Oznaka == RegOznaka)
                                .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    ucestvovalo.Add(new UcestvovaloView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;
        }

        #endregion

        #region Ucestvuje
        public static async Task DodajUcestvuje(UcestvujeAddView u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvuje ucestvovanje = new Ucestvuje();
                ucestvovanje.IdInterventneJed = await sess.LoadAsync<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = await sess.LoadAsync<VanrednaSituacija>(u.IdVanredneSituacije);
                ucestvovanje.IdIntervencije = await sess.LoadAsync<Intervencija>(u.IdIntervencije);
                
                await sess.SaveAsync(ucestvovanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   ObrisiUcestvuje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ucestvuje z = await s.LoadAsync<Ucestvuje>(Id);
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ucestvovanje sa ovim id-em");
                }
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   IzmeniUcestvuje(UcestvujeAddView u, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession(); 
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvuje ucestvovanje = await sess.LoadAsync<Ucestvuje>(Id);
               
                ucestvovanje.IdInterventneJed = await sess.LoadAsync<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = await sess.LoadAsync<VanrednaSituacija>(u.IdVanredneSituacije);
                ucestvovanje.IdIntervencije = await sess.LoadAsync<Intervencija>(u.IdIntervencije);
               
                await sess.UpdateAsync(ucestvovanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        
        public static async Task<IList<UcestvujeGetView>> VratiSvaUcestvovanja()
        {
            List<UcestvujeGetView> ucestvuj = new List<UcestvujeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                ucestvuj = await s.Query<Ucestvuje>()
                          .Select(s=> new UcestvujeGetView(s))
                          .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return ucestvuj;
        }
        public static async Task<UcestvujeGetView>VratiUcestvuje(int Id)
        {
            UcestvujeGetView ucestv = new UcestvujeGetView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvuje u = await sess.LoadAsync<Ucestvuje>(Id);
              
                ucestv = new UcestvujeGetView(u);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestv;
        }

        public static async Task<IList<UcestvujeGetView>> VratiSvaUcestvovanjaUVanrednojSituaciji(int IdVS)
        {
            List<UcestvujeGetView> ucestvovalo = new List<UcestvujeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var Ucestvovalo =await s.Query<Ucestvuje>()
                                 .Fetch(s => s.IdInterventneJed)
                                 .Where(s => s.IdVandredneSituacije.Id == IdVS)
                                 .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    ucestvovalo.Add(new UcestvujeGetView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;

        }

        public static async Task<IList<UcestvujeGetView>> VratiSvaUcestvovanjaUIntervenciji(int IdIntervencije)
        {
            List<UcestvujeGetView> ucestvovalo = new List<UcestvujeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var Ucestvovalo = await s.Query<Ucestvuje>()
                                 .Fetch(s => s.IdInterventneJed)
                                 .Where(s => s.IdIntervencije.Id == IdIntervencije)
                                 .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    ucestvovalo.Add(new UcestvujeGetView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;

        }

        public static async Task<IList<UcestvujeGetView>> VratiSvaUcestvovanjaJedinice(int IdJed)
        {
            List<UcestvujeGetView> ucestvovalo = new List<UcestvujeGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var Ucestvovalo = await s.Query<Ucestvuje>()
                                 .Fetch(s => s.IdInterventneJed)
                                 .Where(s => s.IdInterventneJed.Jedinstveni_Broj == IdJed)
                                 .ToListAsync();
                foreach (var v in Ucestvovalo)
                {
                    ucestvovalo.Add(new UcestvujeGetView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;

        }
        #endregion

        #region Sluzba
        public static async Task   DodajSluzbu(SluzbaAddView s) 
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba sluzba = new Sluzba();
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik= await sess.GetAsync<Predstavnik>(s.JMBG_Predstavnik);
                await sess.SaveAsync(sluzba);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task  ObrisiSluzbu(int IdSektor)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba z = await s.LoadAsync<Sluzba>(IdSektor);
               
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   IzmeniSluzbu(SluzbaAddView s, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba sluzba = await sess.LoadAsync<Sluzba>(Id);
                
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik = await sess.LoadAsync<Predstavnik>(s.JMBG_Predstavnik);
                await sess.UpdateAsync(sluzba);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SluzbaGetView>> VratiSluzbe()
        {
            List<SluzbaGetView> Sluzbe = new List<SluzbaGetView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzbe =await s.Query<Sluzba>()
                       .Fetch(s => s.Predstavnik)
                       .Select(s => new SluzbaGetView(s))
                       .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Sluzbe;
        }
        public static  async Task<SluzbaView> VratiSluzbu(int IdSektora)
        {
            SluzbaView sluzba = new SluzbaView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba s = await sess.LoadAsync<Sluzba>(IdSektora);
               
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                PredstavnikView p = new PredstavnikView();
                p = await DataProvider.VratiPredstavnika(s.Predstavnik.JMBG);
                sluzba.Predstavnik = p;
                
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return sluzba;
        }

        public static async Task<IList<VanrednaSituacijaView>> VratiSveVanredneUKojimaSaradjujeSektor(int IdSektor)
        {
            List<VanrednaSituacijaView> Vanredne = new List<VanrednaSituacijaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var Query = await s.Query<Saradjuje>()
                             .Where(o => o.Sektor.Id_Sektora == IdSektor)
                             .Fetch(o => o.Sektor)
                             .ToListAsync();
                Vanredne = Query.Select(o => new VanrednaSituacijaView(o.VandrednaSituacija))
                                            .Distinct()
                                            .ToList();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Vanredne;
        }
        public static  async Task<IList<SluzbaView>> VratiSveSluzbeKojeSaradjujuSaVS(int IdVS)
        {
            List<SluzbaView> Sluzbe = new List<SluzbaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var izvuciSluzbe =await s.Query<Saradjuje>()
                             .Where(o => o.VandrednaSituacija.Id == IdVS)
                             .Fetch(o => o.VandrednaSituacija)
                             .ToListAsync();
                Sluzbe =  izvuciSluzbe.Select(o => new SluzbaView(o.Sektor))
                                            .Distinct()
                                            .ToList();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Sluzbe;
        }
        #endregion

      

        #region Softver
        public static async Task  DodajSoftver(SoftverAddView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Softver softver = new Softver();
                softver.Analiticar = await sess.LoadAsync<Analiticar>(s.JMBG_Analiticar);
               
                softver.Naziv = s.Naziv;
                await sess.SaveAsync(softver);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task ObrisiSoftver(int IdSoftver)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Softver z = await s.LoadAsync<Softver>(IdSoftver);
                
                await s.DeleteAsync(z);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniSoftver(SoftverAddView s, int Id)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Softver softver = await sess.LoadAsync<Softver>(s.JMBG_Analiticar);
                
                softver.Analiticar = await sess.LoadAsync<Analiticar>(s.JMBG_Analiticar);
                
                softver.Naziv = s.Naziv;
                await sess.UpdateAsync(softver);
                await sess.FlushAsync();
                sess.Close();
                
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<SoftverView> VratiSoftver(int id)
        {
            SoftverView softver = new SoftverView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                Softver s =await sess.LoadAsync<Softver>(id);
                softver.Id = s.Id;
                softver.JMBGAnaliticara = s.Analiticar.JMBG;
                softver.Naziv = s.Naziv;
                sess.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Zao nam je doslo je do greskew");
            }
            return softver;
        }
        public static async Task<IList<SoftverView>> VratiSoftvere()
        {
            List<SoftverView> Softveri = new List<SoftverView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Softveri =await s.Query<Softver>()
                          .Fetch(s => s.Analiticar)
                          .Select(s => new SoftverView(s))
                          .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Softveri;
        }

        public static async Task<IList<SoftverView>> VratiSoftvereAnaliticara(string JMBGAnaliticara)
        {
            List<SoftverView> Softveri = new List<SoftverView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Softveri =await  s.Query<Softver>()
                            .Fetch(s => s.Analiticar)
                            .Where(s => s.Analiticar.JMBG == JMBGAnaliticara)
                            .Select(s => new SoftverView(s))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Softveri;
        }
        #endregion
    }
}
