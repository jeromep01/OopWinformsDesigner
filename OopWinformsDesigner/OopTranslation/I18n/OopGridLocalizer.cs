using DevExpress.XtraGrid.Localization;

namespace OopTranslation.I18n {
    /// <summary>
    /// Définition de l'objet de localisation des informations DevExpress remises à niveau pour OOGarden.
    /// </summary>>
    public class OopGridLocalizer : GridLocalizer {
        /// <summary>
        /// Surcharge utilisée pour traduire les informations DevExpress dans OOGarden.
        /// </summary>
        /// <param name="id">Id de la ressource à traduire</param>
        /// <returns>Chaîne traduite par DevExpress à défaut</returns>
        public override string GetLocalizedString(GridStringId id) {
            switch (id) {
                case GridStringId.GridGroupPanelText:
                    return GridControl.GridGroupPanelText;
                case GridStringId.FindNullPrompt:
                    return GridControl.FindNullPrompt;
                case GridStringId.FindControlFindButton:
                    return GridControl.FindControlFindButton;
            }
            return base.GetLocalizedString(id);
        }
    }
}
