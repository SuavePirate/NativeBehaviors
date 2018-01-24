using System;
using UIKit;

namespace NativeBehaviors
{
    /// <summary>
    /// Extensions for iOS behaviors to attach and detach within lifecycles
    /// </summary>
    public static class iOSBehaviorExtensions
    {
        /// <summary>
        /// Attachs the behavior.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="behavior">Behavior.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void AttachBehavior<T>(this T bindable, NativeBehavior<T> behavior) where T : UIView
        {
            behavior?.Attach(bindable);
        }

        /// <summary>
        /// Attachs the behavior.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="behavior">Behavior.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void DetachBehavior<T>(this T bindable, NativeBehavior<T> behavior) where T : UIView
        {
            behavior?.Detach(bindable);
        }
    }
}
