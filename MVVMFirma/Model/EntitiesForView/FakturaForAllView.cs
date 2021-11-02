using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Model.EntitiesForView
{
    // 11-2 Obiekty klas będą rekordami zawierającymi informacje o fakturach
    // Klasa ta pozwoli na wyświetlanie zamiast kluczy obcych konkretnych danych faktury
    public class FakturaForAllView
    {
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        // to pole jest zamiast klucza obcego
        public string KontrahentNazwa { get; set; }
        public string KontrahentNip { get; set; }
        // to pole jest zamiast klucza obcego
        public string KontrahentAdres { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        // to pole jest zamiast klucza obcego 
        public string SposobPlatnosciNazwa { get; set; }
    }
}
