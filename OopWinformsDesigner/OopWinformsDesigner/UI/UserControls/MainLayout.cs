using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;

using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;

using OopDesigner.EventArguments;

using OopWinformsDesigner.Services;
using OopWinformsDesigner.Session;

using System;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OopWinformsDesigner.UI.UserControls {
    /// <summary>
    /// Definition of the main layout used for this application
    /// </summary>
    public partial class MainLayout : XtraUserControl {
        private ServiceContainer serviceContainer = null;
        private OopMenuCommandService menuService = null;
        private IDesignerHost host;
        private Form rootLayout;
        private IRootDesigner rootDesigner;

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

            installDesigner();
            registerEvents();
        }

        private void installDesigner() {
            serviceContainer = new ServiceContainer();
            serviceContainer.AddService(typeof(INameCreationService), new OopNameCreationService());
            serviceContainer.AddService(typeof(IUIService), new UIService(this));
            host = new DesignerHost(serviceContainer);

            menuService = new OopMenuCommandService();
            serviceContainer.AddService(typeof(IMenuCommandService), menuService);

            // Start the designer host off with a Form to design
            rootLayout = (Form)host.CreateComponent(typeof(Form));
            rootLayout.Text = "Form1";

            // Get the root designer for the form and add its design view to this form
            rootDesigner = (IRootDesigner)host.GetDesigner(rootLayout);
            var view = (Control)rootDesigner.GetView(ViewTechnology.WindowsForms);
            view.Dock = DockStyle.Fill;
            panelDesignerHost.Controls.Add(view);

            // Subscribe to the selectionchanged event and activate the designer
            ISelectionService s = (ISelectionService)serviceContainer.GetService(typeof(ISelectionService));
            s.SelectionChanged += DesignerHost_SelectionChanged;
            host.Activate();
        }

        private void DesignerHost_SelectionChanged(object sender, EventArgs e) {
            var o = sender;

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
                            // Lecture du projet depuis FubuCsproj ?

                            var project = Project.FromFile(x.AbsolutePath, new Microsoft.Build.Definition.ProjectOptions {

                            });
                        }

                    });
                    break;
            };
        }
    }
}
