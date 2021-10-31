using MVVMFirma.Helper;
using MVVMFirma.Model.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    // 10-1 Po tej klasie będą dziedziczyły wszystkie ViewModel zgodne ze scenariuszem wszystkie
    // 10-2 Klasa działa na typie generycznym <T> pod który w przypadku wyświetlania Towarów podstawiane są towary
    // w przypadku podstawiania zamówień podstawiane są zamówienie
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public FakturyEntities fakturyEntities { get;}
        private BaseCommand _LoadCommand;
        // 10-3 Listy będą zawierały różne elementy towary czy zamówienia i _List musi być typu generycznego
        private ObservableCollection<T> _List;
        #endregion

        #region Properties
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
        // 10-4 Lista jest generyczna
        public ObservableCollection<T> List
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

        #region Constructor
        // 10-5 Konstruktor będzie otrzymywał jako parametr nazwę zakładki
        public WszystkieViewModel(String displayName)
        {
            // Ustawienie nazwy zakładki
            base.DisplayName = displayName;
            // 10-6 Tworzę obiekt bazy danych
            this.fakturyEntities = new FakturyEntities();
        }
        #endregion

        #region Helpers
        // 10-7 Klasa WszystkieViewModel jest abstrakcyjna, ponieważ zawiera co najmniej jedną funkcję abstrakcyjną
        public abstract void load();
        #endregion
    }
}
