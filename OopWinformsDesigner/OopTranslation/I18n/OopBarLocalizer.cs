using DevExpress.XtraBars.Localization;

namespace OopTranslation.I18n {
    /// <summary>
    /// Définition de l'objet de localisation des informations DevExpress remises à niveau pour OOGarden.
    /// </summary>>
    public class OopBarLocalizer : BarLocalizer {
        /// <summary>
        /// Surcharge utilisée pour traduire les informations DevExpress dans OOGarden.
        /// </summary>
        /// <param name="id">Id de la ressource à traduire</param>
        /// <returns>Chaîne traduite par DevExpress à défaut</returns>
        public override string GetLocalizedString(BarString id) {
            switch (id) {
                case BarString.PopupMenuEditor:
                    return I18n.Bar.PopupMenuEditor;
            }
            return base.GetLocalizedString(id);
        }
    }
}
