using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;

using Microsoft.Build.Construction;

using OopDesigner.EventArguments;

using OopWinformsDesigner.Session;

using System;

namespace OopWinformsDesigner.UI.UserControls {
    /// <summary>
    /// Definition of the main layout used for this application
    /// </summary>
    public partial class MainLayout : XtraUserControl {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainLayout() {
            InitializeComponent();
        }

        /// <summary>
        /// Loading of the control
        /// </summary>
        /// <param name="e">Arguments of the event</param>
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            registerEvents();
        }

        private void registerEvents() {
            SessionInfo.Instance.NotifyStatusChanged += Instance_NotifyStatusChanged;
        }

        private void Instance_NotifyStatusChanged(object sender, NotifyStatusChangeEventArgs e) {
            switch (e.Status) {
                case OopDesigner.Enumerations.NotifyStatus.SolutionOpened:
                    // Loads the project / solution.
                    var solutionFile = SolutionFile.Parse(SessionInfo.Instance.SolutionFile);

                    solutionFile.ProjectsInOrder.ForEach(x => {

                        if (x.ProjectType == SolutionProjectType.KnownToBeMSBuildFormat) {

                        }

                    });
                    break;
            };
        }
    }
}
