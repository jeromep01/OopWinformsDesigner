using DevExpress.Data.Localization;
using DevExpress.Dialogs.Core.Localization;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraVerticalGrid.Localization;

namespace OopTranslation.I18n {
    /// <summary>
    /// Définition de l'installeur statique des traductions des éléments visuels DevExpress
    /// Pour l'utiliser il suffit d'appeler I18nInstaller.Install() dans l'application principale et le tour est joué.
    /// </summary>
    public static class I18nInstaller {
        /// <summary>
        /// Fonction d'installation des traductions des éléments visuels.
        /// Cette fonction va instancier toutes les classes qu'elles soient utilisées ou non.
        /// </summary>
        public static void Install() {
            Localizer.Active = new OopEditorsLocalizer();
            DialogsLocalizer.Active = new OopDialogsLocalizer();
            GridLocalizer.Active = new OopGridLocalizer();
            VGridLocalizer.Active = new OopVerticalGridLocalizer();
            CommonLocalizer.Active = new OopCommonLocalizer();
            BarLocalizer.Active = new OopBarLocalizer();
        }
    }
}
