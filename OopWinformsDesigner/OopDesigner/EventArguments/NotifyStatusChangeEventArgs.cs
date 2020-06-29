using OopDesigner.Enumerations;

using System;

namespace OopDesigner.EventArguments {
    /// <summary>
    /// Definition of an event argument to use to change the status of any change.
    /// </summary>
    public class NotifyStatusChangeEventArgs : EventArgs {
        /// <summary>
        /// Gets or sets the current status of this notification.
        /// </summary>
        public NotifyStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message / description.
        /// </summary>
        public string Message { get; set; }
    }
}
