﻿using DevExpress.XtraEditors.Controls;

namespace OopTranslation.I18n
{
    /// <summary>
    /// Définition de l'objet de localisation des informations DevExpress remises à niveau pour OOGarden.
    /// </summary>
    public class OopEditorsLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {
        /// <summary>
        /// Surcharge utilisée pour traduire les informations DevExpress dans OOGarden.
        /// </summary>
        /// <param name="id">Id de la ressource à traduire</param>
        /// <returns>Chaîne traduite par DevExpress à défaut</returns>
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.XtraMessageBoxYesButtonText:
                    return I18n.MessageBox.YesButtonText;
                case StringId.XtraMessageBoxNoButtonText:
                    return I18n.MessageBox.NoButtonText;
            };

            return base.GetLocalizedString(id);
        }
    }
}
