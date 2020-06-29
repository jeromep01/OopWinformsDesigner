using OopDesigner.Enumerations;
using OopDesigner.EventArguments;

using System;
using System.ComponentModel;
using System.IO;

namespace OopWinformsDesigner.Session {
    /// <summary>
    /// Definition of the session information about the current usage of the application.
    /// </summary>
    public class SessionInfo : INotifyPropertyChanged {
        private static SessionInfo instance = null;
        private SessionInfo() {
        }

        /// <summary>
        /// Gets the singleton instance of the current session.
        /// </summary>
        public static SessionInfo Instance {
            get {
                if (instance == null) {
                    instance = new SessionInfo();
                    Directory.CreateDirectory(@"Database");
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets whether the solution/project has been loaded in this session.
        /// </summary>
        public bool IsSolutionOrProjectLoaded {
            get {
                return !string.IsNullOrEmpty(SolutionFile) && File.Exists(SolutionFile);
            }
        }

        /// <summary>
        /// Definition of the event where to be registered on to indicate that a state has changed.
        /// </summary>
        public event EventHandler<NotifyStatusChangeEventArgs> NotifyStatusChanged;

        /// <summary>
        /// Definition of the event indicating that a property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string _solutionFile;
        /// <summary>
        /// Gets or sets the solution file loaded.
        /// </summary>
        public string SolutionFile {
            get {
                return _solutionFile;
            }
            set {
                _solutionFile = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SolutionFile)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSolutionOrProjectLoaded)));
                NotifyStatusChanged?.Invoke(this, new NotifyStatusChangeEventArgs(NotifyStatus.SolutionOpened));
            }
        }
    }
}
