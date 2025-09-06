using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using ProjekatVandredneSituacije.Entiteti;
using System.Windows.Forms;
using ProjekatVandredneSituacije;

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

                VandrednaSituacija vandredna = s.Load<VandrednaSituacija>(id);

                s.Delete(vandredna);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }
        public static VandrednaSituacijaBasic vratiVandrednu(int id)
        {
            VandrednaSituacija v = new VandrednaSituacija();
            try
            {
                ISession s = DataLayer.GetSession();

                VandrednaSituacija vs = s.Load<VandrednaSituacija>(id);

                v.Id = vs.Id;
                v.Datum_Od = vs.Datum_Od;
                v.Datum_Do = vs.Datum_Do;
                v.Tip=vs.Tip
                v.Broj_Ugrozenih_Osoba = vs.Broj_Ugrozenih_Osoba;
                v.Opstina = vs.Opstina;
                v.Opis = vs.Opis;
                v.Prijava = vs.Prijava;
                    


                
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return o;

        }
        public static List<OdeljenjeBasic> GetOdInfos(int prodavnicaId)
        {
            List<OdeljenjeBasic> odInfos = new List<OdeljenjeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Odeljenje> odeljenja = from o in s.Query<Odeljenje>()
                                                   where o.PripadaProdavnici.Id == prodavnicaId
                                                   select o;

                foreach (Odeljenje o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeBasic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.ProdajeSeProizvod.Count));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static List<OdeljenjeDo5Pregled> vratiOdeljenjaDo5Prodavnice(int prodavnicaId)
        {
            List<OdeljenjeDo5Pregled> odInfos = new List<OdeljenjeDo5Pregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<OdeljenjeDo5> odeljenja = from o in s.Query<OdeljenjeDo5>()
                                                      where o.PripadaProdavnici.Id == prodavnicaId
                                                      select o;

                foreach (OdeljenjeDo5 o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeDo5Pregled(o.Id, o.Lokacija, o.BrojKasa, o.InfoPult));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void izmeniOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeDo5 o = s.Load<OdeljenjeDo5>(odeljenje.OdeljenjeId);

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;



                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }


        public static void sacuvajOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeDo5 o = new Prodavnica.Entiteti.OdeljenjeDo5();

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(odeljenje.Prodavnica.Id);
                o.PripadaProdavnici = p;


                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
}
#region 



#region Analiticar

public static void obrisiAnaliticara(int id)
{
    try
    {
        ISession s = DataLayer.GetSession();

        Zaposlen z = s.Load<Analiticar>(id);

        s.Delete(Zaposlen);
        s.Flush();



        s.Close();

    }
    catch (Exception ec)
    {
        //handle exceptions
    }


}
public static ZaposlenBasic vratiAnaliticara(int id)
{
    OdeljenjeDo5Basic o = new OdeljenjeDo5Basic();
    try
    {
        ISession s = DataLayer.GetSession();

        OdeljenjeDo5 odeljenje = s.Load<OdeljenjeDo5>(id);

        o.OdeljenjeId = odeljenje.Id;
        o.Lokacija = odeljenje.Lokacija;
        o.BrojKasa = odeljenje.BrojKasa;
        o.infoPult = odeljenje.InfoPult;




        s.Close();

    }
    catch (Exception ec)
    {
        //handle exceptions
    }

    return o;

}
public static List<OdeljenjeBasic> GetOdInfos(int prodavnicaId)
{
    List<OdeljenjeBasic> odInfos = new List<OdeljenjeBasic>();
    try
    {
        ISession s = DataLayer.GetSession();

        IEnumerable<Odeljenje> odeljenja = from o in s.Query<Odeljenje>()
                                           where o.PripadaProdavnici.Id == prodavnicaId
                                           select o;

        foreach (Odeljenje o in odeljenja)
        {
            odInfos.Add(new OdeljenjeBasic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.ProdajeSeProizvod.Count));
        }

        s.Close();

    }
    catch (Exception ec)
    {
        //handle exceptions
    }

    return odInfos;
}
public static List<OdeljenjeDo5Pregled> vratiOdeljenjaDo5Prodavnice(int prodavnicaId)
{
    List<OdeljenjeDo5Pregled> odInfos = new List<OdeljenjeDo5Pregled>();
    try
    {
        ISession s = DataLayer.GetSession();

        IEnumerable<OdeljenjeDo5> odeljenja = from o in s.Query<OdeljenjeDo5>()
                                              where o.PripadaProdavnici.Id == prodavnicaId
                                              select o;

        foreach (OdeljenjeDo5 o in odeljenja)
        {
            odInfos.Add(new OdeljenjeDo5Pregled(o.Id, o.Lokacija, o.BrojKasa, o.InfoPult));
        }

        s.Close();

    }
    catch (Exception ec)
    {
        //handle exceptions
    }

    return odInfos;
}
public static void izmeniOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
{
    try
    {
        ISession s = DataLayer.GetSession();

        Prodavnica.Entiteti.OdeljenjeDo5 o = s.Load<OdeljenjeDo5>(odeljenje.OdeljenjeId);

        o.Lokacija = odeljenje.Lokacija;
        o.BrojKasa = odeljenje.BrojKasa;
        o.InfoPult = odeljenje.infoPult;



        s.SaveOrUpdate(o);

        s.Flush();

        s.Close();
    }
    catch (Exception ec)
    {
        //handle exceptions
    }
}


public static void sacuvajOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
{
    try
    {
        ISession s = DataLayer.GetSession();

        Prodavnica.Entiteti.OdeljenjeDo5 o = new Prodavnica.Entiteti.OdeljenjeDo5();

        o.Lokacija = .Lokacija;
        o.BrojKasa = odeljenje.BrojKasa;
        o.InfoPult = odeljenje.infoPult;
        Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(odeljenje.Prodavnica.Id);
        o.PripadaProdavnici = p;


        s.Save(o);

        s.Flush();

        s.Close();
    }
    catch (Exception ec)
    {
        //handle exceptions
    }
}
    #endregion Zaposlen


    }
}
