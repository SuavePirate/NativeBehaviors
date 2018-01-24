using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;

namespace NativeBehaviors
{
    /// <summary>
    /// Extensions for Android behaviors to attach and detach within lifecycles
    /// </summary>
    public static class AndroidBehaviorExtensions
    {
        /// <summary>
        /// Attachs the behavior.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="behavior">Behavior.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void AttachBehavior<T>(this T bindable, NativeBehavior<T> behavior) where T : View
        {
            behavior?.Attach(bindable);
        }

        /// <summary>
        /// Attachs the behavior.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="behavior">Behavior.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void DetachBehavior<T>(this T bindable, NativeBehavior<T> behavior) where T : View
        {
            behavior?.Detach(bindable);
        }
    }
}
