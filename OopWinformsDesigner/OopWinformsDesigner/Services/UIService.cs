using DevExpress.XtraEditors;

using OopWinformsDesigner.UI.UserControls;

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OopWinformsDesigner.Services {
    /// <summary>
    /// Definition of the basics of our Designer Host model
    /// </summary>
    public class UIService : IUIService {
        MainLayout mainForm = null;
        Hashtable styles = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainForm">Reference to the main form</param>
        public UIService(MainLayout mainForm) {
            this.mainForm = mainForm;

            styles = new Hashtable();
            styles.Add("DialogFont", new Font("Tahoma", 8.25F, FontStyle.Regular));
            styles.Add("HighlightColor", Color.FromArgb(255, 251, 233));
        }

        /// <summary>
        /// Indicates whether a component can show an editor
        /// </summary>
        /// <param name="component">Reference to the component to check</param>
        /// <returns>True|False</returns>
        public bool CanShowComponentEditor(object component) {
            return false;
        }

        public System.Windows.Forms.IWin32Window GetDialogOwnerWindow() {
            return mainForm;
        }

        public void SetUIDirty() {
            // Do nothing
        }

        public bool ShowComponentEditor(object component, System.Windows.Forms.IWin32Window parent) {
            return false;
        }

        public System.Windows.Forms.DialogResult ShowDialog(System.Windows.Forms.Form form) {
            return form.ShowDialog(mainForm);
        }

        public void ShowError(System.Exception ex, string message) {
            XtraMessageBox.Show(mainForm, "Piped error: " + message + Environment.NewLine + Environment.NewLine + ex.ToString());
        }

        public void ShowError(System.Exception ex) {
            XtraMessageBox.Show(mainForm, "Piped error: " + ex.ToString());
        }

        public void ShowError(string message) {
            XtraMessageBox.Show(mainForm, "Piped error: " + message);
        }

        public System.Windows.Forms.DialogResult ShowMessage(string message, string caption, System.Windows.Forms.MessageBoxButtons buttons) {
            return XtraMessageBox.Show(mainForm, message, caption, buttons, MessageBoxIcon.Information);
        }

        public void ShowMessage(string message, string caption) {
            XtraMessageBox.Show(mainForm, message, caption);
        }

        public void ShowMessage(string message) {
            XtraMessageBox.Show(mainForm, message);
        }

        public bool ShowToolWindow(System.Guid toolWindow) {
            return false;
        }

        public System.Collections.IDictionary Styles {
            get {
                return styles;
            }
        }
    }
}
