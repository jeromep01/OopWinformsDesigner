using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

using OopDesigner.Interfaces;

using OopWinformsDesigner.Session;
using OopWinformsDesigner.UI;

using System;

namespace OopWinformsDesigner {
    /// <summary>
    /// Definition of the main form of this application.
    /// </summary>
    public partial class MainForm : RibbonForm, IOopDesigner {
        /// <summary>
        /// Gets or sets the layout that will be used to match designer processes.
        /// </summary>
        public PanelControl MainLayout { get; set; } = new PanelControl();

        /// <summary>
        /// Gets or sets the bar manager (used to create both status bar / menus).
        /// </summary>
        public BarManager BarManager { get; set; }

        /// <summary>
        /// Gets or sets the status bar of the application.
        /// </summary>
        public new Bar StatusBar { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Loading of the form
        /// </summary>
        /// <param name="e">Arguments</param>
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            installLayout();
            installRibbonMenu();
            installBarManager();

            registerEvents();

#if DEBUG
            //SessionInfo.Instance.SolutionFile = @"O:\Développements\OopWinformsDesigner\OopWinformsDesigner\OopWinformsDesigner.sln";
            SessionInfo.Instance.SolutionFile = @"O:\Développements\ITLightON\Tests\ITLightON.Winforms.Tester.sln";
#endif
        }

        private void registerEvents() {
            SessionInfo.Instance.NotifyStatusChanged += Instance_NotifyStatusChanged;
        }

        private void Instance_NotifyStatusChanged(object sender, OopDesigner.EventArguments.NotifyStatusChangeEventArgs e) {
            switch (e.Status) {
                case OopDesigner.Enumerations.NotifyStatus.SolutionOpened:
                    UIExtenders.SetStatusText(
                        StatusBar,
                        string.Format(OopTranslation.StatusBar.SolutionSelected, SessionInfo.Instance.SolutionFile));
                    break;
            };
        }

        private void installLayout() {
            UIExtenders.Install(MainLayout);

            Controls.Add(MainLayout);
        }
        private void installRibbonMenu() {
            Ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl().Install();
            var ribbonManager = new DevExpress.XtraBars.Ribbon.RibbonBarManager(Ribbon);

            Ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            Controls.Add(Ribbon);
        }
        private void installBarManager() {
            BarManager = new DevExpress.XtraBars.BarManager(this.components);

            BarManager.Form = this;
            BarManager.BeginUpdate();
            StatusBar = new DevExpress.XtraBars.Bar() {
                BarName = "StatusBar",
                Manager = BarManager,
                DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom,
                CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom,
                DockCol = 0,
                DockRow = 0
            };
            BarManager.Bars.Add(StatusBar.InstallStatusBar());
            BarManager.StatusBar = StatusBar;

            BarManager.StatusBar.OptionsBar.AllowQuickCustomization = false;
            BarManager.StatusBar.OptionsBar.UseWholeRow = true;
            BarManager.StatusBar.OptionsBar.DrawDragBorder = false;
            BarManager.StatusBar.OptionsBar.DrawSizeGrip = true;

            BarManager.EndUpdate();
        }
    }
}
