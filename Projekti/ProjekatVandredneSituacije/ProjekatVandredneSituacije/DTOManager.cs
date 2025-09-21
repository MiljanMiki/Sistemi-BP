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
using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Mapiranja;
using System.Text.RegularExpressions;
using NHibernate.Util;
using Remotion.Linq.Parsing;
using NHibernate.Cfg.Loquacious;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;


namespace ProjekatVandredneSituacije
{
    internal class DTOManager
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
                VanrednaSituacija Vanredna =await s.LoadAsync<VanrednaSituacija>(id);
                if(Vanredna == null)
                {
                    throw new Exception("Ne postoji Vanredna situacija sa ovim Id-em");
                }
                await s.DeleteAsync(Vanredna);
                await s.FlushAsync();
                
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!" ,ec);
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
                Entiteti.VanrednaSituacija v = new Entiteti.VanrednaSituacija();
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Nivo_Opasnosti = vs.Nivo_Opasnosti;
                v.Opstina = vs.Opstina;
                v.Lokacija = vs.Lokacija;
                v.Opis = vs.Opis;
                v.Prijava_ID =await s.LoadAsync<Prijava>(vs.IdPrijave);
                if (v.Prijava_ID == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske sa ucitavanjem prijave tj. nemamo prijavu sa ovim Id-em");
                }
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
            VanrednaSituacijaView vanredna=null;
            
            try
            {
                ISession s = DataLayer.GetSession();

                VanrednaSituacija vs =await s.LoadAsync<VanrednaSituacija>(id);
                if(vs==null)
                {
                    throw new KeyNotFoundException("Zao nam je Vanredna situacija sa ovim Id-jem ne postoji");
                }
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
                VanrednaSituacija v= await s.LoadAsync<VanrednaSituacija>(Id);

                if(v==null)
                {
                    throw new KeyNotFoundException("Zao nam je Vanredna situacija sa ovim Id ne postoji");
                }
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip = vs.Tip;
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Opstina = vs.Opstina;
                v.Opis = vs.Opis;
                v.Prijava_ID= await s.LoadAsync<Prijava>(vs.IdPrijave);
                if (v.Prijava_ID == null)
                {
                    throw new Exception("Zao nam je ne postoji Prijava sa ovim idem");
                }
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
        public static async Task DodajOpstuIntervetnuJedinicu(InterventnaJedinicaView i)
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
                ij.BrojClanova= i.BrojClanova;
                ij.Komandir = await s.LoadAsync<OperativniRadnik>(i.JMBGKomandira);
                ij.Baza= i.Baza;
                await s.SaveOrUpdateAsync(ij);
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

                OpstaIntervetnaJed ij =await s.LoadAsync<OpstaIntervetnaJed>(id);
                await s.DeleteAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   izmeniOpstuInterventnuJedinicu(OpstaInterventnaView i, int Id)
            {
                try
                {
                    ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                OpstaIntervetnaJed ij = await s.LoadAsync<OpstaIntervetnaJed>(Id);
                if(ij == null)
                {
                    throw new Exception($"Opsta jedinica sa Id=em{Id} ne postoji");    
                }
                    ij.Naziv = i.Naziv;
                    ij.BrojClanova = i.BrojClanova;
                    ij.Komandir =await s.LoadAsync<OperativniRadnik>(i.JMBGKomandira);
                    if (ij.Komandir == null)
                    {
                        throw new KeyNotFoundException("Zao nam je komandir sa ovim JMBG ne postoji!");
                    }
                    ij.Baza = i.Baza;
                    await s.UpdateAsync(ij);
                    s.FlushAsync();
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
                sveJedinice =await s.Query<OpstaIntervetnaJed>()
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
            OpstaIntervetnaGetView o=null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                OpstaIntervetnaJed ij =await s.LoadAsync<OpstaIntervetnaJed>(id);
                if(ij==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji Opsta Intervetna jedinica sa ovim Id-em");
                }
                o= new OpstaIntervetnaGetView(ij);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return o;
        }


        public static async Task DodajSpecijalnuIntervetnuJedinicu(SpecijalnaIntervetnaJedinicaView i)
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
                ij.BrojClanova = i.BrojClanova;
                ij.Komandir =await  s.LoadAsync<OperativniRadnik>(i.JMBGKomandira);
                if (ij.Komandir == null)
                {
                    throw new KeyNotFoundException("Zao nam je Komandir sa ovim JMBG-om ne postoji");
                }
                ij.Baza = i.Baza;
                await s.SaveOrUpdateAsync(ij);
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
                SpecijalnaInterventna ij =await s.LoadAsync<SpecijalnaInterventna>(id);
                if(ij==null)
                {
                    throw new KeyNotFoundException("Zao nam je intervetna jed sa ovim Id-em ne postoji");
                }
                await s.DeleteAsync(ij);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task   izmeniSpecijalnuInterventnuJedinicu(SpecijalnaIntervetnaJedinicaView i, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaInterventna ij = await s.LoadAsync<SpecijalnaInterventna>(Id);
                if(ij==null)
                {
                    throw new KeyNotFoundException("Zao nam je intervetna jed sa ovim Id-em ne postoji");
                }
                ij.Naziv = i.Naziv;
                ij.BrojClanova = i.BrojClanova;
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
            SpecijalnaIntervetnaGetView o=null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaInterventna ij =await s.LoadAsync<SpecijalnaInterventna>(id);
                o= new SpecijalnaIntervetnaGetView(ij);
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

                var sveJediniceQuery =await s.Query<OpstaIntervetnaJed>()
                    .Fetch(o => o.Komandir) // N+1 potencijalni
                    .ToListAsync();

                foreach (InterventnaJedinica o in sveJediniceQuery)
                {
                    if (o is OpstaIntervetnaJed)
                    {
                        OpstaIntervetnaJed oi = (OpstaIntervetnaJed)o;
                        sveJedinice.Add(new OpstaIntervetnaGetView(oi));
                    }
                    else
                    {
                        SpecijalnaInterventna si = (SpecijalnaInterventna)o;
                        sveJedinice.Add(new SpecijalnaIntervetnaGetView(si));
                    }
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
        public static async Task DodajIntervenciju(IntervencijaView i)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Intervencija intervencija = new Intervencija();
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
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

        public static async Task ObrisiIntervenciju()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Intervencija i =await s.LoadAsync<Intervencija>(1);
                await s.DeleteAsync(i);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task IzmeniIntervenciju(IntervencijaView i, int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Intervencija intervencija =await s.LoadAsync<Intervencija>(Id);
                if (intervencija == null)
                {
                    throw new KeyNotFoundException("Zao nam je intervencija s aovim Id-em ne postoji");
                }
                intervencija.Datum_I_Vreme = i.Datum_I_Vreme;
                intervencija.Lokacija = i.Lokacija;
                intervencija.Status = i.Status;
                intervencija.Broj_Spasenih = i.Broj_Spasenih;
                intervencija.Broj_Povredjenih = i.Broj_Povredjenih;
                intervencija.Uspesnost = i.Uspesnost;
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
                Intervencija intervencija =await s.LoadAsync<Intervencija>(id);
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
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return i;
        }

        #endregion


        #region Prijava

        public static async Task  DodajPrijavu(PrijavaAddView pr)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Entiteti.Prijava p = new Entiteti.Prijava();
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Id_VandrednaSituacija =await s.LoadAsync<VanrednaSituacija>(pr.Id_VandrednaSituacija);
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
                if (p == null)
                {
                    throw new Exception("Zao nam je ne postoji Prijava sa ovim Id-em");
                }
                await s.DeleteAsync(p);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniPrijavu(PrijavaAddView pr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Entiteti.Prijava p = await s.LoadAsync<Prijava>(pr.Id);
                if (p == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji Prijava sa ovim Id-em");
                }
                p.Datum_I_Vreme = pr.Datum_I_Vreme;
                p.Id_VandrednaSituacija =await s.LoadAsync<Entiteti.VanrednaSituacija>(pr.Id_VandrednaSituacija);
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

        public static async Task<IList<PrijavaAddView>> VratiPrijave()
        {
            List<PrijavaAddView> SvePrijave = new List<PrijavaAddView>(); // koristim drugi DTO zbog moguce rekurzije u obicnom DTO
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }

                SvePrijave =await s.Query<Prijava>().
                             Select(p => new PrijavaAddView(p))
                            .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return SvePrijave;
        }

        public static async Task<PrijavaMiniView> VratiPrijavu(int idPrijave)
        {
            PrijavaMiniView prijava=null;
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
                prijava = new PrijavaMiniView(pr);
              

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

                await s.SaveAsync(analiticar);
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
                Analiticar z =await s.LoadAsync<Analiticar>(JMBG);
                if(z== null)
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

        public static async Task   IzmeniAnaliticar(AnaliticarView a)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Analiticar analiticar = await s.LoadAsync<Analiticar>(a.JMBG);
                analiticar.JMBG= a.JMBG; // dozvolicemo da se menja JMBG ako slucajno dodje do greske prilikom ubacivanja korisnika 
                analiticar.Ime = a.Ime;
                analiticar.Prezime = a.Prezime;
                analiticar.Datum_Rodjenja = a.Datum_Rodjenja;
                analiticar.Kontakt_Telefon = a.Kontakt_Telefon;
                analiticar.Email = a.Email;
                analiticar.AdresaStanovanja = a.AdresaStanovanja;
                analiticar.Datum_Zaposlenja = a.Datum_Zaposlenja;

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
                if(a==null)
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


        public static async Task DodajOperativnogRadnik(OperativniRadnikView o, int IdJedinice)
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
                op.InterventnaJedinica = await s.LoadAsync<InterventnaJedinica>(IdJedinice);
                InterventnaJedinica ij = await s.LoadAsync<InterventnaJedinica>(IdJedinice);
                
                ij.BrojClanova++;

                await s.SaveAsync(op);
                await s.UpdateAsync(ij);
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
                InterventnaJedinica ij= await s.LoadAsync<InterventnaJedinica>(op.InterventnaJedinica.Jedinstveni_Broj);
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

        public static async Task   IzmeniOperativnog(OperativniRadnikChangeView o, int IdJedinice)
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

                InterventnaJedinica oldij = await s.LoadAsync<InterventnaJedinica>(o.IdJedinice);
                oldij.BrojClanova--;
                oldij.Radnici.Remove(op);
                await s.SaveOrUpdateAsync(oldij);

                op.InterventnaJedinica = await s.LoadAsync<InterventnaJedinica>(IdJedinice);

                InterventnaJedinica newij = await s.LoadAsync<InterventnaJedinica>(IdJedinice);
                newij.BrojClanova++;

                await s.SaveOrUpdateAsync(newij);

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
                kordinator.BrojTimova = k.BrojTimova;
                await s.SaveAsync(kordinator);
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
                Kordinator z = await s.LoadAsync<Kordinator>(JMBG);
                if(z==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji kordinator sa ovim JMBG");
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

        public static async Task   IzmeniKordinatora(KordinatorView k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kordinator kordinator = await s.LoadAsync<Kordinator>(k.JMBG);
                if(kordinator==null)
                {
                    throw new KeyNotFoundException("Zao nam je kordinator sa ovim JMBG ne postoji");
                }
                kordinator.JMBG = k.JMBG;
                kordinator.Ime = k.Ime;
                kordinator.Prezime = k.Prezime;
                kordinator.Datum_Rodjenja = k.Datum_Rodjenja;
                kordinator.Pol = k.Pol;
                kordinator.Kontakt_Telefon = k.Kontakt_Telefon;
                kordinator.Email = k.Email;
                kordinator.Datum_Zaposlenja = k.Datum_Zaposlenja;
                kordinator.BrojTimova = k.BrojTimova;

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
            List<ZaposleniView> sviZaposleni = new List<ZaposleniView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var SviZaposleniQuery =await s.Query<Zaposlen>()
                                        .ToListAsync();
                                        
                foreach (Zaposlen zap in SviZaposleniQuery)
                {
                    if (zap is Analiticar)
                    {
                        Analiticar analiticar = (Analiticar)zap;
                        sviZaposleni.Add(new AnaliticarView(analiticar));
                    }
                    else if(zap is Kordinator)
                    {
                        Kordinator ko = (Kordinator)zap;
                        sviZaposleni.Add(new KordinatorView(ko));
                    }
                    else if(zap is OperativniRadnik)
                    {
                        OperativniRadnik op = (OperativniRadnik)zap;
                        sviZaposleni.Add(new OperativniRadnikView(op));
                    }
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

        public static async Task DodajSanitetskaVozilo(SanitetskaView v)
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

        public static async Task  IzmeniSanitetskoVozilo(SanitetskaView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sanitetska vozilo = await s.LoadAsync<Sanitetska>(v.Registarska_Oznaka);
                if (vozilo == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji vozilo sa ovom registracijom!");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
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

        public static async Task   DodajSpecijalnoVozilo(SpecijalnaVozilaView v)
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

        public static async Task IzmeniSpecijalnaVozila(SpecijalnaVozilaView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaVozila vozilo = await s.LoadAsync<SpecijalnaVozila>(v.Registarska_Oznaka);
                if(vozilo==null)
                {
                    throw new KeyNotFoundException("Zao nam je doslo je do greske ne postoji vozilo sa ovom registraskom oznakom");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
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
            SpecijalnaVozilaView v = new SpecijalnaVozilaView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SpecijalnaVozila vozilo = await s.LoadAsync<SpecijalnaVozila>(RegOznaka);
                if(vozilo==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji vozilo sa ovom regitracijom");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
                vozilo.Proizvodjac = v.Proizvodjac;
                vozilo.Status = v.Status;
                vozilo.Lokacija = v.Lokacija;
                vozilo.Namena = v.Namena;
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
        public static async Task   DodajDzip(DzipoviView v)
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Doslo je do ne postoji dzip sa ovom registracijom");
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

        public static async Task   IzmeniDzip(DzipoviView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dzipovi vozilo = await s.LoadAsync<Dzipovi>(v.Registarska_Oznaka);
                if (vozilo == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji dzip sa ovom registracijom");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
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

        public static async Task<DzipoviView> VratiDzipove(string RegOznaka)
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
                if (v == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji dzip sa ovom reg. oznakom!");
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

        #region Kamioni
        public static async Task DodajKamion(KamioniView v)
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji kamion sa ovom reg. oznakom!");
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

        public static async Task  IzmeniKamion(KamioniView v)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Kamioni vozilo = await s.LoadAsync<Kamioni>(v.Registarska_Oznaka);
                if (vozilo == null)
                {
                    throw new SessionException("Doslo je do greske ne postoji vozilo sa ovom reg. oznakom!");
                }
                vozilo.Registarska_Oznaka = v.Registarska_Oznaka;
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
                if (s == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji dzip sa ovom reg. oznakom!");
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

        #region Vozilo
        public static async Task<IList<VoziloView>> VratiSvaVozila()
        {
            List<VoziloView> svaVozila = new List<VoziloView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var SvaVozilaQuery = await s.Query<Vozilo>()
                                    .ToListAsync();
                foreach (Vozilo vozilo in SvaVozilaQuery)
                {

                    if (vozilo is Sanitetska)
                    {
                        Sanitetska san = (Sanitetska)vozilo;
                        svaVozila.Add(new SanitetskaView(san));
                    }
                    else if (vozilo is Kamioni)
                    {
                        Kamioni ka = (Kamioni)vozilo;
                        svaVozila.Add(new KamioniView(ka));
                    }
                    else if (vozilo is Dzipovi)
                    {
                        Dzipovi dzipovi = (Dzipovi)vozilo;
                        svaVozila.Add(new DzipoviView(dzipovi));
                    }
                    else if (vozilo is SpecijalnaVozila)
                    {
                        SpecijalnaVozila spec = (SpecijalnaVozila)vozilo;
                        svaVozila.Add(new SpecijalnaVozilaView(spec));

                    }
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaVozila;
        }

        #endregion
        #region Sertifikat
        public static async Task   DodajSertifikat(SertifikatView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                SertifikatId id = new SertifikatId();
                Sertifikat sertifikat1 = new Sertifikat();
                id.OperativniRadnik= await sess.LoadAsync<OperativniRadnik>(s.Id.OperativniRadnik.JMBG);
                if (id.OperativniRadnik == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji Operativni radnik");
                }
                id.Naziv = s.Id.Naziv;
                id.Institucija=s.Id.Institucija;

                sertifikat1.Id = id;
                sertifikat1.DatumIzdavanja = s.DatumIzdavanja;
                sertifikat1.DatumVazenja = s.DatumVazenja;

                await sess.SaveOrUpdateAsync(sertifikat1);

                await sess.FlushAsync();

                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task   ObrisiSertifikat(SertifikatView se)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sertifikat z = await s.LoadAsync<Sertifikat>(se.Id);
                if (z == null)
                {
                    throw new SessionException("Doslo je do greske ne postoji sertifikat sa ovim Id-em!");
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
                id.OperativniRadnik = await s.LoadAsync<OperativniRadnik>(sert.Id.OperativniRadnik.JMBG);
                
                id.Naziv = sert.Id.Naziv;
                id.Institucija = sert.Id.Naziv;
                Sertifikat sertifikat = await s.LoadAsync<Sertifikat>(id);
                if (sertifikat == null)
                {
                    throw new SessionException("Doslo je do greske ne postoji sertifikat sa ovim Id-em!");
                }
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
        public static async Task<IList<SertifikatView>> VratiSertifikate()
        {
            List<SertifikatView> sviSertifikati = new List<SertifikatView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviSertifikati =  s.Query<Sertifikat>()
                                .Fetch(s => s.Id.OperativniRadnik)
                                .ToList()
                                .Select(s => new SertifikatView(s))
                                .ToList();

                

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return sviSertifikati;
        }
        public static async Task<IList<SertifikatView>> VratiSertifikateZaposlenog(string JMBGZaposlenog)
        {
            List<SertifikatView> sviSertifikati = new List<SertifikatView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                sviSertifikati = s.Query<Sertifikat>()
                                .Fetch(s => s.Id.OperativniRadnik)
                                .Where(s => s.Id.OperativniRadnik.JMBG==JMBGZaposlenog)
                                .ToList()
                                .Select(s => new SertifikatView(s))
                                .ToList();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return sviSertifikati;
        }

        public static async Task<SertifikatView> VratiSertifikat(int Id)
        {
            SertifikatView sertifikat = new SertifikatView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sertifikat s = await sess.LoadAsync<Sertifikat>(Id);
                if(s==null)
                {
                    throw new KeyNotFoundException("Zao nam je Sertifikat sa ovim Id-em ne postoji");
                }
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
                ekspertiza.Id = e.Id;
                ekspertiza.Analiticar = await sess.LoadAsync<Analiticar>(e.JMBGAnaliticara);
                if (sess == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji Analiticar(obavezno polje)");
                }
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji ekspertiza sa voim Id-em");
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
                if(ekspertiza==null)
                {
                    throw new KeyNotFoundException("Zao nam je ekspertiza sa ovim Id ne postoji");
                }
                ekspertiza.Analiticar = await sess.LoadAsync<Analiticar>(e.JMBGAnaliticara);
                if(ekspertiza.Analiticar==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji analiticar(oBavezno polje)");
                }
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
                if (e == null)
                {
                    throw new KeyNotFoundException("Doslo je do greske ne postoji ekspertiza sa ovim Id-em");
                }
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

        public static async Task   DodajSpecijalizaciju(SpecijalizacijaAddView sp)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija specijalizacija = new Specijalizacija();
                specijalizacija.Id= sp.Id;
                specijalizacija.Kordinator = await sess.LoadAsync<Kordinator>(sp.JMBG_Kordinator);
                if (specijalizacija.Kordinator == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji kordinator(obavezno polje)");
                }
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

        public static async Task IzmeniSpecijalizaciju(SpecijalizacijaAddView sp)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Specijalizacija specijalizacija = await sess.LoadAsync<Specijalizacija>(sp.Id);
                specijalizacija.Id = sp.Id;
                specijalizacija.Kordinator = await sess.LoadAsync<Kordinator>(sp.JMBG_Kordinator);
                if(specijalizacija.Kordinator==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji kordinator sa ovim id-em");
                }
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
        public static async Task   DodajLicnuZastitu(LicnaZastitaView l)
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
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.Jedinica);
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
                if(z==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ova licna zastita");
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

        public static async Task IzmeniLicnuZastitu(LicnaZastitaView l)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita liz = await s.LoadAsync<LicnaZastita>(l.Serijski_Broj);
                liz.Serijski_Broj = l.Serijski_Broj; // stavimo da ne generisemo automatski sifre vec da korisnik moze da upise sifru opreme
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.Jedinica);
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

        public static async Task<IList<LicnaZastitaView>> VratiLicnuZastitu()
        {
            List<LicnaZastitaView> svaOprema = new List<LicnaZastitaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                svaOprema = await  s.Query<LicnaZastita>()
                           .Fetch(s=>s.Jedinica)
                           .Select(l => new LicnaZastitaView(l))
                           .ToListAsync();
              
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<LicnaZastitaView> VratiLicnuZastitu(string SerijskiBroj)
        {
            LicnaZastitaView liz = null ;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                LicnaZastita l = await s.LoadAsync<LicnaZastita>(SerijskiBroj);
                if(l==null)
                {
                    throw new KeyNotFoundException("Zao nam je licna zastita sa ovim id-em ne postoji");
                }
                liz = new LicnaZastitaView(l);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<LicnaZastitaView>> VratiLicnuOpremuJedinice(int idJedinice)
        {
            List<LicnaZastitaView> svaOprema = new List<LicnaZastitaView>();
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
                            .Select(l => new LicnaZastitaView(l))
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
                if(liz==null)
                {
                    throw new KeyNotFoundException("Zao nam je medicinska oprema sa ovim Id-em ne postoji");
                }
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;


                s.Update(liz);
                s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<MedicinskaOpremaView>> VratiMedicinskuZastitu()
        {
            List<MedicinskaOpremaView> svaOprema = new List<MedicinskaOpremaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema = await s.Query<MedicinskaOprema>()
                            .Fetch(i => i.Jedinica)
                            .Select(med => new MedicinskaOpremaView(med))
                            .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<MedicinskaOpremaView> VratiMedicinskuOpremu(string SerijskiBroj)
        {
            MedicinskaOpremaView liz = new MedicinskaOpremaView();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                MedicinskaOprema l = await s.LoadAsync<MedicinskaOprema>(SerijskiBroj);
                if(l==null)
                {
                    throw new KeyNotFoundException("Zao nam je medicinska oprema sa ovim brojem ne postoji");
                }
                liz.Serijski_Broj = l.Serijski_Broj;
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = new InterventnaJedinicaView(l.Jedinica);
                liz.Tip = l.Tip;
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<MedicinskaOpremaView>> VratiMedicinskuOpremuJedinice(int idJedinice)
        {
            List<MedicinskaOpremaView> svaOprema = new List<MedicinskaOpremaView>();
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
                            .Select(m => new MedicinskaOpremaView(m))
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
                if (liz == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji tehnicka oprema sa ovim serijskim brojem");
                }
                liz.Naziv = l.Naziv;
                liz.Status = l.Status;
                liz.DatumNabavke = l.DatumNabavke;
                liz.Jedinica = await s.LoadAsync<InterventnaJedinica>(l.JedinicaID);
                liz.Tip = l.Tip;
                s.Update(liz);
                s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task<IList<TehnickaOpremaView>> VratiTehnickuZastitu()
        {
            List<TehnickaOpremaView> svaOprema = new List<TehnickaOpremaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema = await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Select(l => new TehnickaOpremaView(l))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<TehnickaOpremaView> VratiTehnickuOpremu(string SerijskiBroj)
        {
            TehnickaOpremaView liz = null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                TehnickaOprema l = await s.LoadAsync<TehnickaOprema>(SerijskiBroj);

                liz = new TehnickaOpremaView(l);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<TehnickaOpremaView>> VratiTehnickuOpremuJedinice(int idJedinice)
        {
            List<TehnickaOpremaView> svaOprema = new List<TehnickaOpremaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                svaOprema =await s.Query<TehnickaOprema>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == idJedinice)
                           .Select(t => new TehnickaOpremaView(t))
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

        #region Zalihe
        public static async Task DodajZalihe(ZaliheAddView z)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe zalihe = new Zalihe();
                zalihe.Naziv = z.Naziv;
                zalihe.Status = z.Status;
                zalihe.DatumNabavke = z.DatumNabavke;
                zalihe.Jedinica = await s.LoadAsync<InterventnaJedinica>(z.JedinicaID);
                if(zalihe.Jedinica==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji jedinica sa ovim Id-em");
                }
                zalihe.Kolicina = z.Kolicina;
                zalihe.Tip = z.Tip;
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
                zalihe.Naziv = z.Naziv;
                zalihe.Status = z.Status;
                zalihe.DatumNabavke = z.DatumNabavke;
                zalihe.Jedinica = await s.LoadAsync<InterventnaJedinica>(z.JedinicaID);
                if(zalihe.Jedinica==null)
                {
                    throw new KeyNotFoundException("Zao na je ne postoji jedinica id");
                }
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

        public static async Task<IList<ZaliheView>> VratiZalihe()
        {
            List<ZaliheView> svaOprema = new List<ZaliheView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                svaOprema =await  s.Query<Zalihe>()
                           .Fetch(s => s.Jedinica)
                            .Select(z => new ZaliheView(z))
                           .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }
        public static async Task<ZaliheView> VratiZalihe(string SerijskiBroj)
        {
            ZaliheView liz=null;
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Zalihe z = await s.LoadAsync<Zalihe>(SerijskiBroj);
                liz = new ZaliheView(z);
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return liz;
        }

        public static async Task<IList<ZaliheView>> VratiZaliheJedinice(int idJedinice)
        {
            List<ZaliheView> svaOprema = new List<ZaliheView>();
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

                            .Select(z => new ZaliheView(z))
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

        
        public static async Task<IList<OpremaView>> VratiSvuOpremu()
        {
            List<OpremaView> svaOprema = new List<OpremaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var svaOpremaQuery =await s.Query<Oprema>()
                           .Fetch(s => s.Jedinica)
                           .ToListAsync();

                foreach (Oprema o in svaOpremaQuery)
                {
                    if (o is LicnaZastita)
                    {
                        LicnaZastita liz = (LicnaZastita)o;
                        svaOprema.Add(new LicnaZastitaView(liz));
                    }
                    else if (o is MedicinskaOprema)
                    {
                        MedicinskaOprema med = (MedicinskaOprema)o;
                        svaOprema.Add(new MedicinskaOpremaView(med));
                    }
                    else if (o is TehnickaOprema)
                    {
                        TehnickaOprema tech = (TehnickaOprema)o;
                        svaOprema.Add(new TehnickaOpremaView(tech));
                    }
                    else if (o is Zalihe)
                    {
                        Zalihe zalihe = (Zalihe)o;
                        svaOprema.Add(new ZaliheView(zalihe));
                    }
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return svaOprema;
        }

        public static async Task<IList<OpremaView>> VratiSvuOpremuJedinice(int IdJed)
        {
            List<OpremaView> svaOprema = new List<OpremaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                var svaOpremaQuery =await  s.Query<Oprema>()
                           .Fetch(s => s.Jedinica)
                           .Where(s => s.Jedinica.Jedinstveni_Broj == IdJed)
                           .ToListAsync();
                foreach (Oprema o in svaOpremaQuery)
                {
                    if (o is LicnaZastita)
                    {
                        LicnaZastita liz = (LicnaZastita)o;
                        svaOprema.Add(new LicnaZastitaView(liz));
                    }
                    else if (o is MedicinskaOprema)
                    {
                        MedicinskaOprema med = (MedicinskaOprema)o;
                        svaOprema.Add(new MedicinskaOpremaView(med));
                    }
                    else if (o is TehnickaOprema)
                    {
                        TehnickaOprema tech = (TehnickaOprema)o;
                        svaOprema.Add(new TehnickaOpremaView(tech));
                    }
                    else if (o is Zalihe)
                    {
                        Zalihe zalihe = (Zalihe)o;
                        svaOprema.Add(new ZaliheView(zalihe));
                    }
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
                predstavnik.Sluzba = await s.LoadAsync<Sluzba>(p.Sluzba.Id_Sektora);
                if (predstavnik.Sluzba== null)
                {
                    throw new KeyNotFoundException("Zao na je ne postoji sluzba sa ovim id-em");
                }
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

        public static async Task   IzmeniPredstavnika(PredstavnikView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Predstavnik predstavnik = await s.LoadAsync<Predstavnik>(p.JMBG);
                if(predstavnik==null)
                {
                    throw new Exception("Zao nam je ne postoji predstavnik sa ovim JMBG");
                }
                predstavnik.JMBG = p.JMBG;
                predstavnik.Ime = p.Ime;
                predstavnik.Prezime = p.Prezime;
                predstavnik.Pozicija = p.Pozicija;
                predstavnik.Telefon = p.Telefon;
                predstavnik.Email = p.Email;
                predstavnik.Sluzba = await s.LoadAsync<Sluzba>(p.Id_Sektora);
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
                
                if (sluzba != null)
                {
                    Predstavnik p = sluzba.Predstavnik;
                    predstavnik = await DTOManager.VratiPredstavnika(p.JMBG);
                }
   
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
                servis.Id = s.Id;
                servis.Vozilo = await sess.LoadAsync<Vozilo>(s.RegistarskaOznakaVozila);
                if(servis.Vozilo== null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji vozila sa ovom registracijom");
                }
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji servis sa ovim Id");
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

        public static async Task   IzmeniServis(ServisiAddView s)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Servisi Servis = session.Load<Servisi>(s.Id);
                if (Servis == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji servis sa ovim Id");
                }
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
                if(istorija.Zaposleni==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji radnik sa ovim JMBG");
                }
                istorija.Uloga = i.Uloga;
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji istorija radnika sa ovim Id-em");
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
                if(istorija==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji istorija sa ovim ID-em");
                }
                istorija.Zaposleni = await sess.LoadAsync<Zaposlen>(i.JMBGZaposlenog);
                if(istorija.Zaposleni==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji Zaposleni sa ovim JMBG-om");
                }
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
                                .Select(s => new Istorija_Uloga_ZaposlenihView(s))
                                .ToListAsync();
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
                dodeljivanje.Radnik = Radnik;
                dodeljivanje.Jedinica = Jedinica;
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

        public static async Task   ObrisiDodeljivanje(int Id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                DodeljujeSe z = await s.LoadAsync<DodeljujeSe>(Id);
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji dodeljivanje vozila sa ovim id-em");
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

        public static async Task<IList<DodeljujeSeView>> VratiSvaDodeljivanja()
        {
            List<DodeljujeSeView> Dodeljivanja = new List<DodeljujeSeView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Dodeljivanja =await  s.Query<DodeljujeSe>()
                              .Fetch(s => s.Radnik)
                              .Fetch(s => s.Jedinica)
                              .Select(s=> new DodeljujeSeView(s))
                              .ToListAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return Dodeljivanja;
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

        public static async Task  <IList<VoziloView>> VratiDodeljenaVozilaRadniku(string JMBGPojedinac)
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
                if(saradnja.Sektor==null || saradnja.VandrednaSituacija ==null)
                {
                    throw new KeyNotFoundException("zao nam je jedno od obaveznih polja je neispravno");
                }
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je saradnja sa ovim id-em ne postoji");
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

        public static async Task   IzmeniSaradnju(SaradjujeAddView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Saradjuje saradnja = await sess.LoadAsync<Saradjuje>(s.Id);
                if (saradnja==null)
                {
                    throw new KeyNotFoundException("Zao nam je saradnja sa ovim id-em ne postoji");
                }
                saradnja.Uloga = s.Uloga;
                saradnja.Sektor = await sess.LoadAsync<Sluzba>(s.SektorID);
                saradnja.VandrednaSituacija = await sess.LoadAsync<VanrednaSituacija>(s.VanrednaSituacijaID);
                if (saradnja.Sektor == null ||  saradnja.VandrednaSituacija == null)
                {
                    throw new KeyNotFoundException("Zao nam je neki od podataka nisu tacni");
                }
                await sess.UpdateAsync(saradnja);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SaradjujeView>> VratiSaradnje()
        {
            List<SaradjujeView> Saradnje = new List<SaradjujeView>();
            try
            {
                ISession s = DataLayer.GetSession();
                Saradnje =await  s.Query<Saradjuje>()
                         .Fetch(s => s.VandrednaSituacija)
                         .Fetch(s => s.Sektor)
                         .Select(s => new SaradjujeView(s))
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
                Saradjuje s = await sess.LoadAsync<Saradjuje>(Id);
                if (s == null)
                {
                    throw new KeyNotFoundException("Zao nam je saradnje sa ovim id-em ne postoji");
                }
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
                if (ucestvovanje.Vozilo == null || ucestvovanje.Intervencija == null)
                {
                    throw new KeyNotFoundException("Zao nam je neki od podataka nisu tacni");
                }
                ucestvovanje.Datum_Od = u.Datum_Od;
                ucestvovanje.Datum_Do = u.Datum_Do;
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
                Ucestvovalo ucestvovanje = await s.LoadAsync<Ucestvovalo>(Id);
                if (ucestvovanje == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ucestvovanje sa ovim id-em");
                }
                await s.DeleteAsync(ucestvovanje);
                await s.FlushAsync();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }

        public static async Task IzmeniUcestvovanje(UcestvovaloAddView u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvovalo ucestvovanje = await sess.LoadAsync<Ucestvovalo>(u.ID);
                if (ucestvovanje == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ucestvovanje sa ovim id-em");
                }
                ucestvovanje.Vozilo = await sess.LoadAsync<Vozilo>(u.VoziloReg);
                ucestvovanje.Intervencija = await sess.LoadAsync<Intervencija>(u.IntervencijaID);
                if (ucestvovanje.Vozilo == null|| ucestvovanje.Intervencija==null)
                {
                    throw new KeyNotFoundException("Zao nam je neki od podataka nisu tacni");
                }
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

        public static async Task<IList<UcestvovaloView>> VratiUcestvovanja()
        {
            List<UcestvovaloView> ucestvovalo = new List<UcestvovaloView>();
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
                            .Select(s => new UcestvovaloView(s))
                            .ToListAsync();
              
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return ucestvovalo;
        }
        public static async Task<UcestvovaloView> VratiUcestvovanje(int Id)
        {
            UcestvovaloView ucestv = new UcestvovaloView();
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvovalo u = await sess.LoadAsync<Ucestvovalo>(Id);
                if (u == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ucestvovanje sa ovim id-em");
                }
                ucestv = new UcestvovaloView(u);
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
                                .Fetch(s => s.Intervencija)
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
        public static async Task DodajUcestvuje(UcestvujeView u)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                Ucestvuje ucestvovanje = new Ucestvuje();
                ucestvovanje.IdInterventneJed = await sess.LoadAsync<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = await sess.LoadAsync<VanrednaSituacija>(u.IdVandredneSituacije);
                ucestvovanje.IdIntervencije = await sess.LoadAsync<Intervencija>(u.IdIntervencije);
                if (ucestvovanje.IdInterventneJed == null || ucestvovanje.IdVandredneSituacije == null || ucestvovanje.IdIntervencije == null)
                {
                    throw new KeyNotFoundException("Zao nam je nemate obavezne stavke");
                }
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
        public static async Task   IzmeniUcestvuje(UcestvujeAddView u)
        {
            try
            {
                ISession sess = DataLayer.GetSession(); 
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvuje ucestvovanje = await sess.LoadAsync<Ucestvuje>(u.Id);
                if(ucestvovanje==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji ucestvovanje sa ovim Id-em");
                }
                ucestvovanje.Id = u.Id;
                ucestvovanje.IdInterventneJed = await sess.LoadAsync<InterventnaJedinica>(u.IdInterventneJed);
                ucestvovanje.IdVandredneSituacije = await sess.LoadAsync<VanrednaSituacija>(u.IdVandredneSituacije);
                ucestvovanje.IdIntervencije = await sess.LoadAsync<Intervencija>(u.IdIntervencije);
                if(ucestvovanje.IdInterventneJed==null || ucestvovanje.IdVandredneSituacije==null|| ucestvovanje.IdIntervencije==null)
                {
                    throw new KeyNotFoundException("Zao nam je nemate obavezne stavke"); 
                }
                await sess.UpdateAsync(ucestvovanje);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        
        public static async Task<IList<UcestvujeView>> VratiSvaUcestvovanja()
        {
            List<UcestvujeView> ucestvuj = new List<UcestvujeView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                ucestvuj = await s.Query<Ucestvuje>()
                          .Select(s=> new UcestvujeView(s))
                          .ToListAsync();
                
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }

            return ucestvuj;
        }
        public static async Task<UcestvujeView>VratiUcestvuje(int Id)
        {
            UcestvujeView ucestv = new UcestvujeView();
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Ucestvuje u = await sess.LoadAsync<Ucestvuje>(Id);
                if(u==null)
                {
                    throw new KeyNotFoundException("Zao nam je ali ucestvovanje sa ovim Id ne postoji");
                }
                ucestv = new UcestvujeView(u);
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestv;
        }

        public static async Task<IList<UcestvujeView>> VratiSvaUcestvovanjaUVanrednojSituaciji(int IdVS)
        {
            List<UcestvujeView> ucestvovalo = new List<UcestvujeView>();
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
                    ucestvovalo.Add(new UcestvujeView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;

        }

        public static async Task<IList<UcestvujeView>> VratiSvaUcestvovanjaUIntervenciji(int IdIntervencije)
        {
            List<UcestvujeView> ucestvovalo = new List<UcestvujeView>();
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
                    ucestvovalo.Add(new UcestvujeView(v));
                }
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
            return ucestvovalo;

        }

        public static async Task<IList<UcestvujeView>> VratiSvaUcestvovanjaJedinice(int IdJed)
        {
            List<UcestvujeView> ucestvovalo = new List<UcestvujeView>();
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
                    ucestvovalo.Add(new UcestvujeView(v));
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
        public static async Task   DodajSluzbu(SluzbaView s) 
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba sluzba = new Sluzba();
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik= await sess.LoadAsync<Predstavnik>(s.Predstavnik);
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je sluzba sa ovim Id-em ne postoji");
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

        public static async Task   IzmeniSluzbu(SluzbaView s)
        {
            try
            {
                ISession sess = DataLayer.GetSession();
                if (sess == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzba sluzba = await sess.LoadAsync<Sluzba>(s.Id_Sektora);
                if(sluzba==null)
                {
                    throw new KeyNotFoundException("Zao nam je sluzba sa ovim Id-em ne postoji");
                }
                sluzba.TipSektora = s.TipSektora;
                sluzba.Predstavnik = await sess.LoadAsync<Predstavnik>(s.Predstavnik);
                await sess.UpdateAsync(sluzba);
                await sess.FlushAsync();
                sess.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Zao nam je doslo je do greske!", ec);
            }
        }
        public static async Task<IList<SluzbaView>> VratiSluzbe()
        {
            List<SluzbaView> Sluzbe = new List<SluzbaView>();
            try
            {
                ISession s = DataLayer.GetSession();
                if (s == null)
                {
                    throw new SessionException("Doslo je do greske pri pravljenju sesije");
                }
                Sluzbe =await s.Query<Sluzba>()
                       .Fetch(s => s.Predstavnik)
                       .Select(s => new SluzbaView(s))
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
                if(s==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji sluzba sa ovim Id-em");
                }
                sluzba.Id_Sektora = s.Id_Sektora;
                sluzba.TipSektora = s.TipSektora;
                PredstavnikView p = new PredstavnikView();
                p = await DTOManager.VratiPredstavnika(s.Predstavnik.JMBG);
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
                var Query =  s.Query<Saradjuje>()
                             .Where(o => o.Sektor.Id_Sektora == IdSektor)
                             .Fetch(o => o.Sektor)
                             .ToList();
                Vanredne =  Query.Select(o => new VanrednaSituacijaView(o.VandrednaSituacija))
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
                var izvuciSluzbe = s.Query<Saradjuje>()
                             .Where(o => o.VandrednaSituacija.Id == IdVS)
                             .Fetch(o => o.VandrednaSituacija)
                             .ToList();
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

        #region Ucestvuje
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
                if(softver.Analiticar==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji analititcar sa ovim JMBG-om");
                }
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
                if (z == null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji softver sa vim Id-em");
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
                if(softver==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji softver sa vim Id-em");
                }
                softver.Analiticar = await sess.LoadAsync<Analiticar>(s.JMBG_Analiticar);
                if(softver.Analiticar==null)
                {
                    throw new KeyNotFoundException("Zao nam je ne postoji analititcar sa ovim JMBG-om");
                }
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
