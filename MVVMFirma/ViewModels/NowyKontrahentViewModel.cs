﻿namespace MVVMFirma.ViewModels
{
    public class NowyKontrahentViewModel:WorkspaceViewModel//wszystkie zakladki musza dziedziczyc po workspaceviewmodel
    {
        #region Konstruktor
        public NowyKontrahentViewModel()
        {
            base.DisplayName = "Kontrahent";//nazwa zakładki
        }
        #endregion
    }
}
