using DevExpress.XtraEditors;

using net.r_eg.MvsSln;
using net.r_eg.MvsSln.Extensions;

using OopDesigner.EventArguments;
using OopDesigner.Interfaces;

using OopWinformsDesigner.Services;
using OopWinformsDesigner.Session;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OopWinformsDesigner.UI.UserControls {
    /// <summary>
    /// Definition of the main layout used for this application
    /// </summary>
    public partial class MainLayout : XtraUserControl, IOopDesigner {
        private ServiceContainer serviceContainer = null;
        private OopMenuCommandService menuService = null;
        private IDesignerHost host;
        private Form rootLayout;
        private IRootDesigner rootDesigner;
        private ISelectionService selectionService;

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

            treeDesigners.Columns.AddField(nameof(Type.Assembly));
            treeDesigners.Columns.AddField(nameof(Type.Namespace));
            treeDesigners.Columns.AddField(nameof(Type.Name));
            installDesigner();
            registerEvents();
            addDataBindings();
        }

        private void addDataBindings() {
            treeDesigners.DataSource = SessionInfo.Instance.Designers;
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
            selectionService = (ISelectionService)serviceContainer.GetService(typeof(ISelectionService));
            selectionService.SelectionChanged += DesignerHost_SelectionChanged;
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
                    var s = new Sln(SessionInfo.Instance.SolutionFile, SlnItems.EnvWithProjects);
                    foreach (var prj in s.Result.ProjectItems) {
                        if (prj.EpType == net.r_eg.MvsSln.Core.ProjectType.CsSdk) {
                            // This is the new format.
                            var o = s.Result.Env.GetOrLoadProject(prj);

                            if (o.IsBuildEnabled) {

                            }
                            var msBuildStartupDirectory = o.AllEvaluatedProperties.FirstOrDefault(x => x.Name == "MSBuildStartupDirectory");
                            var outputType = o.AllEvaluatedProperties.LastOrDefault(x => x.Name == "OutputType");
                            if (msBuildStartupDirectory != null && outputType != null) {
                                var extension = GetExtensionFromOutputType(outputType.EvaluatedValue);
                                var asmFile = string.Join(@"\", msBuildStartupDirectory.EvaluatedValue, prj.name + extension);
                                var assembly = Assembly.LoadFile(asmFile);
                                if (assembly != null) {
                                    loadTypes(assembly).ForEach(type => SessionInfo.Instance.Designers.Add(type));
                                }
                            }
                        }
                    }
                    // On every types added, we generate a list bindable.
                    break;
            };
        }

        private IEnumerable<Type> loadTypes(Assembly assembly) {
            // We must exclude abstract types as the Designer must create concrete class of them !
            return assembly.GetTypes().Where(x => x.IsPublic && !x.IsAbstract &&
            x.GetInterfaces().Any(i => i == typeof(IOopDesigner)));
        }

        private object GetExtensionFromOutputType(string evaluatedValue) {
            if (evaluatedValue == "Library")
                return ".dll";

            return ".exe";
        }
    }
}
