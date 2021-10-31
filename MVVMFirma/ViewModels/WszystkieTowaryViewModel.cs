using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Model.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    // 10-8 WszystkieTowaryViewModel mogą teraz dziedziczyć z WszystkieViewModel, które dziedziczy z WorkspaceViewModel
    // od typu generyczne, który jest TowarForView
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowarForView>
    {
        #region Consktuctor
        public WszystkieTowaryViewModel()
        : base("Towary")
        {
        }
        #endregion

        #region Helpers
        // 07-10 Funkcja load() wczytuje obiekty z bazy danych
        public override void load()
        {
            // Do listy przekazuję z bazy danych wszystkie towary używając dostępu do bazy danych poprzez fakturyEntities
            List = new ObservableCollection<TowarForView>
                // Tworzymy obiekt od razu go inicjalizując za pomocą inicjalizatora
                (
                    // 09-2 LINQ => odpowiednik C# (obiektowy) SQL
                    from towar in fakturyEntities.Towar
                    where towar.CzyAktywny == true
                    select new TowarForView
                    {
                        IdTowaru = towar.IdTowaru,
                        Kod = towar.Kod,
                        Nazwa = towar.Nazwa,
                        StawkaVatSprzedazy = towar.StawkaVatSprzedazy,
                        Cena = towar.Cena
                    }
            );
        }
        #endregion
    }
}