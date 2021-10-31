namespace MVVMFirma.Model.EntitiesForView
{
    // 09-1 Obiekty będą przechowywały dane pobrane za pomocą LINQ z bazy danych
    public class TowarForView
    {
        public int IdTowaru { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public decimal? StawkaVatSprzedazy { get; set; }
        public decimal? Cena { get; set; }
    }
}