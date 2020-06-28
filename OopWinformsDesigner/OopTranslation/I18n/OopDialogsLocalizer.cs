using DevExpress.Dialogs.Core.Localization;

namespace OopTranslation.I18n {
    /// <summary>
    /// Définition de l'objet de localisation des informations DevExpress remises à niveau pour OOGarden.
    /// </summary>>
    public class OopDialogsLocalizer : DevExpress.Dialogs.Core.Localization.DialogsLocalizer {
        /// <summary>
        /// Surcharge utilisée pour traduire les informations DevExpress dans OOGarden.
        /// </summary>
        /// <param name="id">Id de la ressource à traduire</param>
        /// <returns>Chaîne traduite par DevExpress à défaut</returns>
        public override string GetLocalizedString(DialogsStringId id) {
            switch (id) {
                case DialogsStringId.OpenFileDialogOkButtonText:
                    return IoFileDialogs.OpenFileDialogOkButtonText;
                case DialogsStringId.NewFolderButtonText:
                    return IoFileDialogs.NewFolderButtonText;
                case DialogsStringId.CancelButtonText:
                    return IoFileDialogs.CancelButtonText;
                case DialogsStringId.FileNameLabelText:
                    return IoFileDialogs.FileNameLabelText;

                #region Grille de données du détail des fichiers disponibles
                case DialogsStringId.DetailsView_NameColumnCaption:
                    return IoFileDialogs.DetailsView_NameColumnCaption;
                case DialogsStringId.DetailsView_SizeColumnCaption:
                    return IoFileDialogs.DetailsView_SizeColumnCaption;
                case DialogsStringId.DetailsView_DateModifiedColumnCaption:
                    return IoFileDialogs.DetailsView_DateModifiedColumnCaption;
                case DialogsStringId.DetailsView_TypeColumnCaption:
                    return IoFileDialogs.DetailsView_TypeColumnCaption;
                #endregion

                #region Menu contextuel pour les différents modes d'affichage des tableaux
                case DialogsStringId.ExtraLargeViewMode:
                    return IoFileDialogs.ExtraLargeViewMode;
                case DialogsStringId.LargeViewMode:
                    return IoFileDialogs.LargeViewMode;
                case DialogsStringId.MediumViewMode:
                    return IoFileDialogs.MediumViewMode;
                case DialogsStringId.SmallViewMode:
                    return IoFileDialogs.SmallViewMode;
                case DialogsStringId.ListViewMode:
                    return IoFileDialogs.ListViewMode;
                case DialogsStringId.DetailsViewMode:
                    return IoFileDialogs.DetailsViewMode;
                case DialogsStringId.TilesViewMode:
                    return IoFileDialogs.TilesViewMode;
                case DialogsStringId.ContentViewMode:
                    return IoFileDialogs.ContentViewMode;
                #endregion

                #region Menu contextuel
                case DialogsStringId.ContextMenuAddNetworkPlaceCommandText:
                    return IoFileDialogs.ContextMenuAddNetworkPlaceCommandText;
                case DialogsStringId.ContextMenuCollapseCommandText:
                    return IoFileDialogs.ContextMenuCollapseCommandText;
                case DialogsStringId.ContextMenuConnectNetworkDriveCommandText:
                    return IoFileDialogs.ContextMenuConnectNetworkDriveCommandText;
                case DialogsStringId.ContextMenuCopyCommandText:
                    return IoFileDialogs.ContextMenuCopyCommandText;
                case DialogsStringId.ContextMenuCutCommandText:
                    return IoFileDialogs.ContextMenuCutCommandText;
                case DialogsStringId.ContextMenuDeleteCommandText:
                    return IoFileDialogs.ContextMenuDeleteCommandText;
                case DialogsStringId.ContextMenuDisconnectNetworkDriveCommandText:
                    return IoFileDialogs.ContextMenuDisconnectNetworkDriveCommandText;
                case DialogsStringId.ContextMenuDisplaySettingsCommandText:
                    return IoFileDialogs.ContextMenuDisplaySettingsCommandText;
                case DialogsStringId.ContextMenuEditCommandText:
                    return IoFileDialogs.ContextMenuEditCommandText;
                case DialogsStringId.ContextMenuEjectCommandText:
                    return IoFileDialogs.ContextMenuEjectCommandText;
                case DialogsStringId.ContextMenuExpandCommandText:
                    return IoFileDialogs.ContextMenuExpandCommandText;
                case DialogsStringId.ContextMenuExtractCommandText:
                    return IoFileDialogs.ContextMenuExtractCommandText;
                case DialogsStringId.ContextMenuFormatCommandText:
                    return IoFileDialogs.ContextMenuFormatCommandText;
                case DialogsStringId.ContextMenuLinkCommandText:
                    return IoFileDialogs.ContextMenuLinkCommandText;
                case DialogsStringId.ContextMenuManageCommandText:
                    return IoFileDialogs.ContextMenuManageCommandText;
                case DialogsStringId.ContextMenuOpenAsCommandText:
                    return IoFileDialogs.ContextMenuOpenAsCommandText;
                case DialogsStringId.ContextMenuOpenCommandText:
                    return IoFileDialogs.ContextMenuOpenCommandText;
                    #endregion
            };

            return base.GetLocalizedString(id);
        }
    }
}
