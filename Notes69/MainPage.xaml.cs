using System.Collections.ObjectModel;

namespace Notes69
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Notatka> notatki = new ObservableCollection<Notatka>();

        public MainPage()
        {
            InitializeComponent();

            // Ustawienie źródła dla ListView
            ListaNotatek.ItemsSource = notatki;
        }

        // Metoda obsługująca kliknięcie przycisku "DODAJ"
        private void DodajNotatke(object sender, EventArgs e)
        {
            // Pobranie tekstu z Entry i dodanie nowej notatki
            if (!string.IsNullOrEmpty(NowaNotatka.Text))
            {
                notatki.Add(new Notatka(NowaNotatka.Text, "Domyślna treść"));
                ListaNotatek.ItemsSource = null;
                ListaNotatek.ItemsSource = notatki;
                NowaNotatka.Text = string.Empty; // Wyczyść pole tekstowe
            }
        }

        // Klasa Notatka, zdefiniowana w tym samym pliku
        private class Notatka
        {
            private static int licznikNotatek = 0;
            private int identyfikator;
            protected string tytul;
            protected string tresc;

            public Notatka(string tytul, string tresc)
            {
                licznikNotatek++;
                identyfikator = licznikNotatek;
                this.tytul = tytul;
                this.tresc = tresc;
            }

            // Nadpisujemy metodę ToString() aby ListView wyświetlało tytuł notatki
            public override string ToString()
            {
                return tytul;
            }

            public string WyswietlNotatke()
            {
                return $"Tytuł: {tytul}\nTreść: {tresc}\n";
            }

            public string WyswietlDiagnostyke()
            {
                return $"Identyfikator: {identyfikator}; Tytuł: {tytul}; Treść: {tresc}";
            }
        }
    }

}
