using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSobeUStudentskomDomuIzbacivanjeSvihStudenata()
        {
            StudentskiDom sd = new StudentskiDom(100);
            sd.PromjenaSobe(new Soba(101, 2), 2);
            //provjera da li je uspjesna promjena kapaciteta sa 2 na 1
            Assert.AreEqual(sd.Sobe[0].Stanari.Count, 0);
        }

        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSobeUStudentskomDomu()
        {
            StudentskiDom sd = new StudentskiDom(100);
            sd.PromjenaSobe(new Soba(101, 2), 1);
            //provjera da li je uspjesna promjena kapaciteta sa 2 na 1
            Assert.AreEqual(sd.Sobe[0].Kapacitet, 2);
        }

        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSobeUStudentskomDomuIzbacivanjeNekolikoStudenata()
        {
            StudentskiDom sd = new StudentskiDom(1);
            sd.PromjenaSobe(sd.Sobe[0], 3);
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l3 = new LicniPodaci("Kerim", "Hodzic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student k1 = new Student("faris12", "colakovic23", l1, null, s);
            Student k2 = new Student("amer12", "beso2332", l2, null, s);
            Student k3 = new Student("kerim12", "hodzic23", l2, null, s);
            sd.Sobe[0].DodajStanara(k1);
            sd.Sobe[0].DodajStanara(k2);
            sd.Sobe[0].DodajStanara(k3);
            //provjera da li su svi studenti u sobi
            Assert.IsTrue(sd.Sobe[0].DaLiJeStanar(k1));
            Assert.IsTrue(sd.Sobe[0].DaLiJeStanar(k2));
            Assert.IsTrue(sd.Sobe[0].DaLiJeStanar(k3));
            sd.PromjenaSobe(sd.Sobe[0], 2);
            Assert.IsTrue(sd.Sobe[0].DaLiJeStanar(k1));
            Assert.IsTrue(sd.Sobe[0].DaLiJeStanar(k2));
            Assert.IsFalse(sd.Sobe[0].DaLiJeStanar(k3));
        }

        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSamoCiklusa()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Amer", "Beso", "Travnik", "abeso1@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student s1 = new Student("amer12", "beso2332", l1, null, s);
            //indeks prije promjene skolovanja
            String indeksPocetni = s1.Skolovanje.BrojIndeksa;
            s1.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet", 1, 2);
            StringAssert.Equals(s1.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet");
            Assert.AreNotEqual(s1.Skolovanje.BrojIndeksa, indeksPocetni);
            Assert.AreEqual(s1.Skolovanje.CiklusStudija, 2);
            Assert.AreEqual(s1.Skolovanje.GodinaStudija, 1);
        }

        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSamoFakulteta()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Amer", "Beso", "Travnik", "abeso1@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student s1 = new Student("amer12", "beso2332", l1, null, s);
            //indeks prije promjene skolovanja
            String indeksPocetni = s1.Skolovanje.BrojIndeksa;
            s1.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet u Sarajevu", 1, 1);
            StringAssert.Equals(s1.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet u Sarajevu");
            Assert.AreNotEqual(s1.Skolovanje.BrojIndeksa, indeksPocetni);
            Assert.AreEqual(s1.Skolovanje.CiklusStudija, 1);
            Assert.AreEqual(s1.Skolovanje.GodinaStudija, 1);
        }

        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSamoGodine()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Amer", "Beso", "Travnik", "abeso1@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student s1 = new Student("amer12", "beso2332", l1, null, s);
            //indeks prije promjene skolovanja
            String indeksPocetni = s1.Skolovanje.BrojIndeksa;
            s1.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet", 3, 1);
            StringAssert.Equals(s1.Skolovanje.MaticniFakultet, "Elektrotehnički fakultet");
            Assert.AreEqual(s1.Skolovanje.BrojIndeksa, indeksPocetni);//sada ce indeksi biti isti
            Assert.AreEqual(s1.Skolovanje.CiklusStudija, 1);
            Assert.AreEqual(s1.Skolovanje.GodinaStudija, 3);
        }

        [TestMethod]
        //implementacija - Faris Colakovic
        public void TestKorisnikPromjenaBrojaSobe()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student k1 = new Student("faris12", "col12345", l1, null, s);
            Student k2 = new Student("amer12", "bes12345", l2, null, s);
            Soba soba = new Soba(200, 3);
            soba.DodajStanara(k1);
            soba.DodajStanara(k2);
            soba.PromjenaBrojaSobe(300);
            Assert.IsTrue(soba.DaLiJeStanar(k1));
            Assert.AreEqual(soba.DaLiJeStanar(k2), true);

            soba.PromjenaBrojaSobe(200);
            Assert.IsTrue(soba.DaLiJeStanar(k1));
            Assert.AreEqual(soba.DaLiJeStanar(k2), true);
        }

        [TestMethod]
        //implementacija - Faris Colakovic
        public void TestKorisnikPromjenaBrojaSobeSaIzbacivanjem()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l3 = new LicniPodaci("Kerim", "Hodzic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student k1 = new Student("faris12", "colakovic23", l1, null, s);
            Student k2 = new Student("amer12", "beso2332", l2, null, s);
            Student k3 = new Student("kerim12", "hodzic23", l2, null, s);
            Soba soba = new Soba(200, 3);
            soba.DodajStanara(k1);
            soba.DodajStanara(k2);
            soba.DodajStanara(k3);
            soba.PromjenaBrojaSobe(100);
            Assert.IsTrue(soba.DaLiJeStanar(k1));
            Assert.AreEqual(soba.DaLiJeStanar(k2), true);
            Assert.IsFalse(soba.DaLiJeStanar(k3));
        }


        [TestMethod]
        //implementacija - Faris Colakovic
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestKorisnikPromjenaBrojaSobeSaBrojemSobeNeispravnim()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            LicniPodaci l3 = new LicniPodaci("Kerim", "Hodzic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Student k1 = new Student("faris12", "colakovic23", l1, null, s);
            Student k2 = new Student("amer12", "beso2332", l2, null, s);
            Student k3 = new Student("kerim12", "hodzic23", l2, null, s);
            Soba soba = new Soba(200, 3);
            soba.DodajStanara(k1);
            soba.DodajStanara(k2);
            soba.DodajStanara(k3);
            //ne moze broj sobe iznad 500
            soba.PromjenaBrojaSobe(500);
        }


        [TestMethod]
        //implementacija - Faris Colakovic
        public void TestKorisnikPromjenaPasswordaNoException()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Korisnik k = new Student("faris1232", "colakovic231", l, null, s);
            //ovdje ne treba se nista baciti kao izuzetak
            k.PromjenaPassworda("colakovic231", "colakovic12345");
        }

        [TestMethod]
        //implementacija - Faris Colakovic
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestKorisnikPromjenaPasswordaWithException()
        {
            Skolovanje s = new Skolovanje();
            LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            Korisnik k = new Student("faris12", "colakovic23", l, null, s);
            //ovdje treba se nista baciti kao izuzetak jer validacioni string nije dobar
            k.PromjenaPassworda("colakovic1", "colakovic2");
        }

        [TestClass]
        public class UnitTestTreciZadatak
        {
            ///Klasa Korisnik
            [TestMethod]
            //implementacija - Faris Colakovic
            public void TestKorisnikKlaseKadJeSveUredu()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Korisnik k = new Student("faris1232", "colakovic231", l, null, s);
                //ovdje ne treba se nista baciti kao izuzetak
                StringAssert.Equals(k.Username, "faris1232");
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestKorisnikKlaseUsernamePrazan()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Korisnik k = new Student("", "colakovic231", l, null, s);//ovjde treba izuzetak zbog praznog username
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestKorisnikKlasePasswordPrazan()
            {
                Korisnik k;
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                k = new Student("colakovic231", "", l, null, s);//ovjde treba izuzetak zbog praznog username
            }

            //Klasa LicniPodaci
            [TestMethod]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasa()
            {
                Korisnik k;
                Skolovanje s = new Skolovanje();
                DateTime d = DateTime.Now;
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, d);
                k = new Student("colakovic231", "colakovic231", l, null, s);
                StringAssert.Equals(l.Ime, "Faris");
                StringAssert.Equals(l.Prezime, "Colakovic");
                StringAssert.Equals(l.MjestoRodjenja, "Zenica");
                Assert.AreEqual(l.Spol, Spol.Muško);
                StringAssert.Equals(l.Email, "fcolakovic@etf.unsa.ba");
                StringAssert.Equals(l.Slika, "image.jpeg");
                StringAssert.Equals(l.JMBG, "1231231231233");
                Assert.AreEqual(l.DatumRodjenja, d);
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaImeNeispravno()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaPrezimeNeispravno()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaMjestoRodenjaPrazno()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            }


            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaEmailPrazan()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaJMBGPrazan()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "", Spol.Muško, DateTime.Now);
            }

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            //implementacija - Faris Colakovic
            public void TestLicniPodaciKlasaNeispravanDatum()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.MaxValue);
            }


            //klasa Skolovanje
            [TestMethod]
            //Amer Bešo - 68-ST - implementacija
            public void TestSkolovanjeKlasa()
            {
                Skolovanje s = new Skolovanje();
                s.BrojIndeksa = "12345";
                Assert.AreEqual(s.BrojIndeksa, "12345");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            //Amer Bešo - 68-ST - implementacija
            public void TestSkolovanjeKlasaException()
            {
                Skolovanje s = new Skolovanje();
                s.PromjenaGodineStudija(5, 5);
            }

            //klasa Soba
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestSobaKlasaException1()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                LicniPodaci l3 = new LicniPodaci("Kerim", "Hodzic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, null, s);
                Student k2 = new Student("amer12", "beso2332", l2, null, s);
                Student k3 = new Student("kerim12", "hodzic23", l2, null, s);
                Soba soba = new Soba(100, 2);
                soba.DodajStanara(k1);
                soba.DodajStanara(k2);
                soba.DodajStanara(k3);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestSobaKlasaException2()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                LicniPodaci l3 = new LicniPodaci("Kerim", "Hodzic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, null, s);
                Student k2 = new Student("amer12", "beso2332", l2, null, s);
                Student k3 = new Student("kerim12", "hodzic23", l2, null, s);
                Soba soba = new Soba(100, 2);
                soba.DodajStanara(k1);
                soba.DodajStanara(k2);
                soba.IzbaciStudenta(k3);
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestSobaKlasaIzbaciStudenta()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                LicniPodaci l2 = new LicniPodaci("Amer", "Beso", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, null, s);
                Student k2 = new Student("amer12", "beso2332", l2, null, s);
                Soba soba = new Soba(100, 2);
                soba.DodajStanara(k1);
                soba.DodajStanara(k2);
                soba.IzbaciStudenta(k1);
                Assert.IsFalse(soba.DaLiJeStanar(k1));
            }

            //Klasa Student
            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentKlasaAzuriranjeRacuna()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, null, s);
                k1.AzurirajStanjeRacuna(1000);
                Assert.AreEqual(k1.StanjeRacuna, 2000);
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentKlasaLicniPodaci()
            {
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, null, s);
                Assert.AreEqual(l1, k1.Podaci);
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentKlasaPrebivaliste()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                Assert.IsTrue(k1.Prebivaliste.Contains("Boracka br.1"));
            }

            //klasa StudentskiDom
            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentom1()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.RadSaStudentom(k1, 0);
                Assert.IsTrue(sd.Studenti.Contains(k1));
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentom2()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.UpisUDom(k1, 2, true);
                sd.RadSaStudentom(k1, 1);
                Assert.IsFalse(sd.Studenti.Contains(k1));
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentom3()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.RadSaStudentom(k1, 0);
                sd.RadSaStudentom(k1, 2);
                Assert.IsFalse(sd.Studenti.Contains(k1));
            }

            [TestMethod]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaUpisiMeUDom()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                Student k2 = new Student("amer12", "beso12223", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.UpisUDom(k1, 2, false);
                sd.UpisUDom(k2, 1, true);
                Assert.IsTrue(sd.Sobe[0].Stanari.Contains(k1));
            }

            [TestMethod]
            [ExpectedException(typeof(DuplicateWaitObjectException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentomException1()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.RadSaStudentom(k1, 0);
                sd.RadSaStudentom(k1, 0);//ne moze dva puta isti Student
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentomException2()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                Student k2 = new Student("amer1312", "beso123455", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.RadSaStudentom(k2, 1);//nije dodan ovaj Student nikako
            }


            [TestMethod]
            [ExpectedException(typeof(MissingMemberException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaRadSaStudentomException3()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.RadSaStudentom(k1, 2);//nije dodan ovaj Student nikako
            }


            [TestMethod]
            [ExpectedException(typeof(IndexOutOfRangeException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaUpisiMeUDomException1()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                Student k2 = new Student("amer12", "beso12223", l1, l, s);
                Student k3 = new Student("kerim12", "hodizc12223", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.UpisUDom(k1, 2, true);
                sd.UpisUDom(k2, 2, true);
                sd.UpisUDom(k3, 2, true);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestStudentskiDomKlasaUpisiMeUDomException2()
            {
                List<String> l = new List<string>();
                l.Add("Boracka br.1");
                Skolovanje s = new Skolovanje();
                LicniPodaci l1 = new LicniPodaci("Faris", "Colakovic", "Zenica", "fcolakovic@etf.unsa.ba", "image.jpeg", "1231231231233", Spol.Muško, DateTime.Now);
                Student k1 = new Student("faris12", "colakovic23", l1, l, s);
                Student k2 = new Student("amer12", "beso12223", l1, l, s);
                Student k3 = new Student("kerim12", "hodizc12223", l1, l, s);
                StudentskiDom sd = new StudentskiDom(1);
                sd.UpisUDom(k1, 2, true);
                sd.UpisUDom(k2, 2, true);
                sd.UpisUDom(k3, 2, false);
            }

            //klasa paviljon
            [TestMethod]
            [ExpectedException(typeof(NotImplementedException))]
            ///Amer Beso - 68-ST - implementacija
            public void TestPaviljonKlasaException1()
            {
                Paviljon paviljon = new Paviljon();
                paviljon.DajImePaviljona();
            }
        }

    }


}
