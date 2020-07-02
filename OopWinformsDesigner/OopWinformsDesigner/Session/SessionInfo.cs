using OopDesigner.Enumerations;
using OopDesigner.EventArguments;
using OopDesigner.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace OopWinformsDesigner.Session {
    /// <summary>
    /// Definition of the session information about the current usage of the application.
    /// </summary>
    public class SessionInfo : INotifyPropertyChanged {
        private static SessionInfo instance = null;
        private SessionInfo() {
            Designers = new List<Type>();
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
        /// Definition of the event where to be registered on to indicate that an object shared among many other places has changed.
        /// </summary>
        public event EventHandler<SharedObjectChangeEventArgs> SharedObjectChanged;

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
                if (!DesignUtils.IsInDesignMode()) {
                    NotifyStatusChanged?.Invoke(this, new NotifyStatusChangeEventArgs(NotifyStatus.SolutionOpened));
                }
            }
        }

        /// <summary>
        /// Definition of the function that will raise the event <see cref="SharedObjectChanged"/>.
        /// </summary>
        /// <param name="objectType"><see cref="SharedObjectTypes"/></param>
        /// <param name="objectReference"><see cref="Object"/></param>
        public void NotifySharedObjectChanges(SharedObjectTypes objectType, object objectReference) {
            SharedObjectChanged?.Invoke(this, new SharedObjectChangeEventArgs(objectType, objectReference));
        }

        /// <summary>
        /// This function indicates that a property has been changed
        /// </summary>
        /// <param name="propertyName">Name of the property that has chnaged</param>
        public void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or sets the list of all designer objects.
        /// </summary>
        public IList<Type> Designers { get; set; }
    }
}
