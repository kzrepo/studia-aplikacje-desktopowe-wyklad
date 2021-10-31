using MVVMFirma.Helper;
using MVVMFirma.Model.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    // 07-3 w ViewModel tworzymy klasę odpowiedzialną za pobieranie danych z bazy i bindowanie ich do View
    public class WszystkieTowaryViewModel : WorkspaceViewModel
    {
        #region Fields
        // 07-4 Tworzymy obiekt klasy FakturyEntities, który powstał w Modelu podczas podłączania się do bazy danych
        private readonly FakturyEntities fakturyEntities;
        // 07-5 Klasa BaseCommand znajduje się w Helper i odpowiada za tworzenie komendy, do której możemy podłączyć funkcję
        private BaseCommand _LoadCommand;
        // 07-6 Tu będą przechowywane wszystkie towary pobrane z bazy danych
        private ObservableCollection<Towar> _List;
        #endregion

        #region Properties
        // 07-7 Inicjalizujemy komendę z odpowiednią funkcją do uruchomienia.
        public ICommand LoadCommand
        {
            // Jeśli komenda jest niezainicjalizowana to ją inicjalizuję i podłączam pod komendę funkcję load()
            get
            {
                if(_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        // 07-8 Tworzymy listę towarów, które zostały pobrane z bazy
        public ObservableCollection<Towar> List
        {
            // Jeśli lista jest pusta to uruchamiam funkcję load(), która pobierze dane z bazy
            get
            {
                if(_List == null)
                    load();
                return _List;
            }
            set
            {
                _List = value;
                // Odmalowuje okno ponownie
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region MyRegion
        public WszystkieTowaryViewModel()
        {
            // Ustawienie nazwy zakładki
            base.DisplayName = "Towary";
            // 07-9 Tworzę obiekt bazy danych
            this.fakturyEntities = new FakturyEntities();
        }
        #endregion
        #region Helpers
        // 07-10 Funkcja load() wczytuje obiekty z bazy danych
        private void load()
        {
            // Do listy przekazuję z bazy danych wszystkie towary używając dostępu do bazy danych poprzez fakturyEntities
            List = new ObservableCollection<Towar>
            // Tworzymy obiekt od razu go inicjalizując za pomocą inicjalizatora
            (
                // Niestety w ten sposób zwracamy wszystkie pola z bazy, a my chcemy pobrać tylko te potrzebne
                // To nie jest jeszcze zapytanie LINQ, korzystamy z obiektu utworzonego w konstruktorze tej klasy
                fakturyEntities.Towar
            );
        }
        

        #endregion
    }
}