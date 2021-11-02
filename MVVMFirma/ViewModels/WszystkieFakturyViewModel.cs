using System.Collections.ObjectModel;
using System.Linq;
using MVVMFirma.Model.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;

namespace MVVMFirma.ViewModels
{
    // 11-3 Tworzy listę faktur w oparciu o FakturaForAllView
    public class WszystkieFakturyViewModel: WszystkieViewModel<FakturaForAllView>
    {
        #region Consktuctor
        public WszystkieFakturyViewModel()
            : base("Faktury")
        {
        }
        #endregion

        #region Helpers
        public override void load()
        {
            // Do listy przekazuję z bazy danych wszystkie faktury używając dostępu do bazy danych poprzez fakturyEntities
            List = new ObservableCollection<FakturaForAllView>
                // Tworzymy obiekt od razu go inicjalizując za pomocą inicjalizatora
                (
                    from faktura in fakturyEntities.Faktura
                    where faktura.CzyAktywny == true
                    select new FakturaForAllView
                    {
                        IdFaktury = faktura.IdFaktury,
                        Numer = faktura.Numer,
                        DataWystawienia = faktura.DataWystawienia,
                        KontrahentNazwa = faktura.Kontrahent.Nazwa,
                        KontrahentNip = faktura.Kontrahent.Nip,
                        KontrahentAdres = 
                            faktura.Kontrahent.Adres.Miejscowosc
                            +", ul."
                            +faktura.Kontrahent.Adres.Ulica
                            +", "
                            +faktura.Kontrahent.Adres.NrDomu
                            +"/"
                            +faktura.Kontrahent.Adres.NrLokalu,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        SposobPlatnosciNazwa = faktura.SposobPlatnosci.Nazwa
                    }
                );
        }
        #endregion
    }
}
