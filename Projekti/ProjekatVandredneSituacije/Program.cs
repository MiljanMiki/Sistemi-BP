using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0;
using ProjekatVandredneSituacije.Forme2._0.Dodeljivanja;
using ProjekatVandredneSituacije.Forme2._0.Ekspertiza;
using ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica;
using ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije;
using ProjekatVandredneSituacije.Forme2._0.IstorijaIntervencija;
using ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila;
using ProjekatVandredneSituacije.Forme2._0.Oprema;
using ProjekatVandredneSituacije.Forme2._0.Saradnja;
using ProjekatVandredneSituacije.Forme2._0.Sertifikat;
using ProjekatVandredneSituacije.Forme2._0.Sluzba;
using ProjekatVandredneSituacije.Forme2._0.Softver;
using ProjekatVandredneSituacije.Forme2._0.Specijalizacija;
using ProjekatVandredneSituacije.Forme2._0.Ucestvuje;
using ProjekatVandredneSituacije.Forme2._0.VanrednaSituacija;
using ProjekatVandredneSituacije.Forme2._0.Vozila;
using ProjekatVandredneSituacije.Forme2._0.ZaposleniForma;

namespace ProjekatVanredneSituacije
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForma());
        }
    }
}