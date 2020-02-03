﻿using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

using OopWinformsDesigner.UI;

using System;

namespace OopWinformsDesigner
{
    public partial class MainForm : RibbonForm
    {
        /// <summary>
        /// Gets or sets the layout that will be used to match designer processes.
        /// </summary>
        public PanelControl MainLayout { get; set; }

        /// <summary>
        /// Gets or sets the bar manager (used to create both status bar / menus).
        /// </summary>
        public BarManager BarManager { get; set; }

        /// <summary>
        /// Gets or sets the status bar of the application.
        /// </summary>
        public new Bar StatusBar { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            installLayout();
            installRibbonMenu();
            installBarManager();
        }

        private void installLayout()
        {
            MainLayout = new PanelControl().Install();

            Controls.Add(MainLayout);
        }
        private void installRibbonMenu()
        {
            Ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl().Install();
            var ribbonManager = new DevExpress.XtraBars.Ribbon.RibbonBarManager(Ribbon);

            Ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            Controls.Add(Ribbon);
        }
        private void installBarManager()
        {
            BarManager = new DevExpress.XtraBars.BarManager(this.components);

            BarManager.Form = this;
            BarManager.BeginUpdate();
            StatusBar = new DevExpress.XtraBars.Bar()
            {
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
