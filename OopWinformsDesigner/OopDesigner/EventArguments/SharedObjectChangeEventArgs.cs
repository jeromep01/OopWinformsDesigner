using OopDesigner.Enumerations;

namespace OopDesigner.EventArguments {
    /// <summary>
    /// Definition of the arguments of an event that is fired when an object has changed
    /// </summary>
    public class SharedObjectChangeEventArgs {
        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        public SharedObjectTypes ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the reference of the object.
        /// </summary>
        public object Object { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectType"><see cref="ObjectType"/></param>
        /// <param name="objectReference"><see cref="Object"/></param>
        public SharedObjectChangeEventArgs(SharedObjectTypes objectType, object objectReference) {
            ObjectType = objectType;
            Object = objectReference;
        }
    }
}
