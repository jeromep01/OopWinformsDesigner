using System;
using System.Diagnostics;

namespace OopDesigner.Extensions {
    /// <summary>
    /// Definition of a class checking whether the system is in Design-time use.
    /// </summary>
    public static class DesignUtils {
        private static bool? isInDesignMode;

        /// <summary>
        /// Indicates if the currently running environment even under Visual Studio is Design or not. Warning, does not work in Release !
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough]
        public static bool IsInDesignMode() {
#if DEBUG
            if (!isInDesignMode.HasValue || System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime) {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) {
                    isInDesignMode = true;
                }
#pragma warning disable S1871 // Two branches in the same conditional structure should not have exactly the same implementation
                else if (Process.GetCurrentProcess().ProcessName.Equals("DEVENV", StringComparison.InvariantCultureIgnoreCase)) {
                    isInDesignMode = true;
                }
#pragma warning restore S1871 // Two branches in the same conditional structure should not have exactly the same implementation
                else {
                    isInDesignMode = false;
                }
            }

#else
            isInDesignMode = false;
#endif
            return isInDesignMode.Value;
        }
    }
}
