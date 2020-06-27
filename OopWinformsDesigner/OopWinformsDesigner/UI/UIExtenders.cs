using DevExpress.Skins;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraVerticalGrid;

using OopWinformsDesigner.Session;
using OopWinformsDesigner.UI.UserControls;

using System.Drawing;

namespace OopWinformsDesigner.UI
{
    /// <summary>
    /// Definition of the glossary containing the references to the components to use once they are instantiated.
    /// </summary>
    public static class UIExtenders
    {
        /// <summary>
        /// This function extends the installation of the layout control.
        /// This is just the same thing that made the default Windows Forms Designer.
        /// </summary>
        /// <param name="panelControl">Reference to the layout control installed</param>
        /// <returns>Self instance of the layout control but fully configured</returns>
        public static PanelControl Install(this PanelControl panelControl)
        {
            panelControl.BeginInit();

            panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(new MainLayout().Install());
            panelControl.EndInit();
            return panelControl;
        }

        /// <summary>
        /// This function extends the installation of the layout panel.
        /// </summary>
        /// <param name="mainLayout">Main layout of the flow</param>
        /// <returns>Self instance of the layout</returns>
        public static MainLayout Install(this MainLayout mainLayout)
        {
            var splitContainer = new SplitContainerControl();

            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(new PropertyGridControl());
            splitContainer.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.AddControl(splitContainer);
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            return mainLayout;
        }

        /// <summary>
        /// This function extends the installation of the layout control.
        /// This is just the same thing that made the default Windows Forms Designer.
        /// </summary>
        /// <param name="layoutControl">Reference to the layout control installed</param>
        /// <returns>Self instance of the layout control but fully configured</returns>
        public static LayoutControl Install(this LayoutControl layoutControl)
        {
            layoutControl.BeginUpdate();

            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // This layout is drawn there, with many sides.
            layoutControl.AddGroup();
            layoutControl.AddGroup();
            layoutControl.EndUpdate();
            return layoutControl;
        }

        /// <summary>
        /// This function extends the installation of the ribbon control with adding all required elements.
        /// </summary>
        /// <param name="ribbonControl">Reference to the ribbon control initialized</param>
        /// <returns>Self instance of the ribbon control but fully configured</returns>
        public static RibbonControl Install(this RibbonControl ribbonControl)
        {
            ribbonControl.ButtonGroupsLayout = ButtonGroupsLayout.ThreeRows;
            var pageSolution = new RibbonPage(OopTranslation.Ribbon.RibbonPageSolutionsProjects);
            var groupProjectsAndSolutionsLoadSolution = new RibbonPageGroup(OopTranslation.Ribbon.RibbonPageSolutionsProjectsGroupLoadSolution);
            groupProjectsAndSolutionsLoadSolution.ItemsLayout = RibbonPageGroupItemsLayout.OneRow;
            var buttonOpenSolution = new BarButtonItem
            {
                Caption = OopTranslation.Ribbon.RibbonButtonLoadSolution,
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                Glyph = Properties.Resources.OpenSolution,
                LargeGlyph = Properties.Resources.OpenSolution,
                LargeWidth = 64
            };
            buttonOpenSolution.ItemClick += (sender, e) =>
            {
                using (var ofn = new XtraOpenFileDialog()
                {
                    CheckPathExists = true,
                    CheckFileExists = true,
                    DefaultExt = "*.sln"
                })
                {
                    if (ofn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        XtraMessageBox.Show("Path:" + ofn.FileName);
                    }
                }
            };
            groupProjectsAndSolutionsLoadSolution.ItemLinks.Add(buttonOpenSolution);

            var groupProjectsAndSolutionsLoadProject = new RibbonPageGroup(OopTranslation.Ribbon.RibbonPageSolutionsProjectsGroupLoadProject);
            groupProjectsAndSolutionsLoadProject.ItemsLayout = RibbonPageGroupItemsLayout.OneRow;
            pageSolution.Groups.Add(groupProjectsAndSolutionsLoadSolution);
            pageSolution.Groups.Add(groupProjectsAndSolutionsLoadProject);
            ribbonControl.Pages.Add(pageSolution);
            if (SessionInfo.Instance.IsSolutionOrProjectLoaded)
            {
                // Add alternate groups (pages).
            }
            return ribbonControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusBar">Reference to the status bar installed</param>
        /// <returns>Self instance of the layout control but fully configured</returns>
        public static Bar InstallStatusBar(this Bar statusBar)
        {
            statusBar.AddItem(new DevExpress.XtraBars.BarStaticItem
            {
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                ImageToTextAlignment = DevExpress.XtraBars.BarItemImageToTextAlignment.BeforeText,
                Caption = OopTranslation.StatusBar.Awaiting,
                Glyph = Properties.Resources.Message_Information,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
            });
            var skinsComboEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            };
            SkinManager.Default.GetRuntimeSkins().ForEach(sm => skinsComboEdit.Items.Add(sm.SkinName));
            statusBar.AddItem(new DevExpress.XtraBars.BarEditItem
            {
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                Caption = OopTranslation.StatusBar.SkinSelect,
                Edit = skinsComboEdit,
                Glyph = Properties.Resources.Palette,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
            });

            return statusBar;
        }
    }
}
