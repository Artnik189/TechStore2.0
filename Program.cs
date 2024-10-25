namespace Techstore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Monitore test = new Monitore();
            Oberfläche.InitiiereOberfläche(); //hier habe ich versucht die Methode in der Klasse anzusprechen, war aber nicht sicher ob ich das statisch oder nicht machen soll
        }
    }




    public class Oberfläche // Klasse, in der alle Methoden für die Oberfläche abgespeichert werden
    {
        int eingabe = 0;
        public static int InitiiereOberfläche(int eingabe) // Initiiert die anfängliche Usereingabe
        {
           
            // Hier müsste dann später der Split mit Kunde/Admin kommen
            Console.WriteLine("Willkommen im Techstore!\nBitte geben Sie an, was Sie tun möchten:");
            Console.WriteLine("Geben Sie eine der folgenden Zahlen ein für:\n\n1: Artikelübersicht\n2: Warenkorb anschauen\n");
            eingabe = FilterNichtIntWerte(eingabe);

            switch (eingabe) //Filtert eingaben, die nicht 1 oder 2 sind
            {
                case 1:
                    Artikelübersicht(eingabe);
                    break;
                case 2:
                    Console.WriteLine("Hier kommt irgendwann Ihr Warenkorb :)");
                    break;
                default: Console.WriteLine("Bitte geben Sie einen gültigen Wert ein!");
                    break;

            }
            return eingabe;
        }

        private static int FilterNichtIntWerte(int eingabe) // Methode zur Filterung von nicht int Eingaben des Nutzers
        {
            try
            {
                int.TryParse(Console.ReadLine(), out eingabe);
            }
            catch (FormatException)
            {
                Console.WriteLine("Bitte geben Sie einen gültigen Wert ein!");
            }

            return eingabe;
        }

        public void Artikelübersicht(int eingabe) // Methode, die aufgerufen werden soll, wenn der Nutzer sich für die Artikelübersicht entscheidet
        {
            Console.WriteLine("Hier sehen Sie eine Übersicht aller Artikelkategorien:\n");
            Console.WriteLine("1. Monitore\n2. Grafikkarten\n3. Handys\n4. Kopfhörer");
            Console.WriteLine("Welche Artikelübersicht möchten Sie öffnen? Geben Sie die entsprechende Zahl ein:");
            eingabe = FilterNichtIntWerte(eingabe);
            switch (eingabe)
            {
                case 1: MonitorÜbersicht();
            }

        }

        public void MonitorÜbersicht() // hier sollte dann die Methode kommen, die die einzelnen Objekte in einer Liste aufruft mit den Eigenschaften bestand, bezeichnung, preis und artikelnummer
        {

        }








        // ARTIKELKLASSEN
        abstract class Artikel // Klasse zur Angabe der Eigenschaften, die alle Produkte besitzen
        {
            public int _bestand;
            public string _bezeichnung;
            public double _preis;
            public string _artikelnummer;

            public Artikel(int bestand, string bezeichnung, double preis, string artikelnummer)
            {


                int _bestand = bestand;
                string _bezeichnung = bezeichnung;
                double _preis = preis;
                string _artikelnummer = artikelnummer;


            }
        }

        abstract class Untergruppe : Artikel //Klasse für die Eigenschaften, die zwischen den Unterklassen variieren
        {


            public Untergruppe(string zuständigerMitarbeiter, string lagerort, int bestand, string bezeichnung, double preis, string artikelnummer) : base(bestand, bezeichnung, preis, artikelnummer)
            {
                string _zuständigerMitarbeiter = zuständigerMitarbeiter;
                string _lagerort = lagerort;
            }

        }

        class Monitore : Untergruppe //Klasse für die Untergruppe Monitore (Grafikkarten, Handys und Kopfhörer folgen dem selben Schema)
        {
            public Monitore(string bildschirmgröße, string refreshrate, string anwendungsgebiet, string zuständigerMitarbeiter, string lagerort, int bestand, string bezeichnung, double preis, string artikelnummer) :
                base(zuständigerMitarbeiter, lagerort, bestand, bezeichnung, preis, artikelnummer) // leider bisschen lang und unübersichtlich geworden
            {
                // Definition der objektrelevanten Variablen
                string _bildschirmgröße = bildschirmgröße;
                string _refreshrate = refreshrate;
                string _anwendungsgebiet = anwendungsgebiet;

            }
            public List<Monitore> listMoni { get; set; } = new List<Monitore>(); // Liste mit den Monitoren im Angebot

            public static void InitiiereMonitore() //Hier werden die Daten für die Monitore eingetragen und können dann initiiert werden
            {
                new Monitore("27'", "60 Hz", "Office", "Frau Meier", "Bereich M", 15, "Monitor 27 Zoll", 199.99, "1000000");
                new Monitore("32'", "120 Hz", "Grafikbearbeitung", "Frau Meier", "Bereich M", 7, "Monitor 32 Zoll", 399.99, "1000001");
                new Monitore("34'", "240 Hz", "Gaming", "Frau Meier", "Bereich M", 12, "Monitor 34 Zoll", 699.99, "1000003");


            }


            class Grafikkarten : Untergruppe //Klasse für die Untergruppe Grafikkarten
            {
                public Grafikkarten(string maße, string leistungsaufnahme, string anwendungsgebiet, string zuständigerMitarbeiter, string lagerort, int bestand, string bezeichnung, double preis, string artikelnummer) :
                     base(zuständigerMitarbeiter, lagerort, bestand, bezeichnung, preis, artikelnummer)
                {
                    // Definition der objektrelevanten Variablen
                    string _maße = maße;
                    string _leistungsaufnahme = leistungsaufnahme;
                    string _anwendungsgebiet = anwendungsgebiet;
                }
                private List<Grafikkarten> listGraf = new List<Grafikkarten>();
            }

            class Handys : Untergruppe //Klasse für die Untergruppe Handys
            {
                public Handys(string speicher, string displaygröße, string zuständigerMitarbeiter, string lagerort, int bestand, string bezeichnung, double preis, string artikelnummer) :
                     base(zuständigerMitarbeiter, lagerort, bestand, bezeichnung, preis, artikelnummer)
                {
                    string _speicher = speicher;
                    string _displaygröße = displaygröße;
                }
                private List<Handys> listHand = new List<Handys>();
            }

            class Kopfhörer : Untergruppe //Klasse für die Untergruppe Kophörer
            {
                public Kopfhörer(string marke, string art, string audiofokus, string zuständigerMitarbeiter, string lagerort, int bestand, string bezeichnung, double preis, string artikelnummer) :
                     base(zuständigerMitarbeiter, lagerort, bestand, bezeichnung, preis, artikelnummer)
                {
                    string _marke = marke;
                    string _art = art;
                    string _audiofokus = audiofokus;
                }

                private List<Kopfhörer> listKopf = new List<Kopfhörer>();
            }



            // Die Überreste von Frankensteins Monster für eine gemeinsame Liste

            //public class Datenbank:Artikel 
            //{
            //    public List<Artikel> listArt { get; set; } = new List<Artikel>();

            //    public void FülleDatenbank(List<Monitore> listMoni)
            //    {

            //        foreach (var artik in listMoni)
            //        {
            //            listArt.Add(new Monitore {artik._bestand, artik.bezeichnung, artik.preis, artik.artikelnummer })
            //        }

            //}

            //}
        }
    }
