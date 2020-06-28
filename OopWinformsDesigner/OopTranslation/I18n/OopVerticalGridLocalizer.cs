using DevExpress.XtraVerticalGrid.Localization;

namespace OopTranslation.I18n
{
    /// <summary>
    /// Définition de l'objet de localisation des informations DevExpress remises à niveau pour OOGarden.
    /// </summary>>
    public class OopVerticalGridLocalizer : VGridLocalizer
    {
        /// <summary>
        /// Surcharge utilisée pour traduire les informations DevExpress dans OOGarden.
        /// </summary>
        /// <param name="id">Id de la ressource à traduire</param>
        /// <returns>Chaîne traduite par DevExpress à défaut</returns>
        public override string GetLocalizedString(VGridStringId id)
        {
            return base.GetLocalizedString(id);
        }
    }
}
