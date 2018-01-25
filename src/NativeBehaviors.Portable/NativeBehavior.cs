using System;
namespace NativeBehaviors
{
    /// <summary>
    /// Native behavior. Built to follow a same pattern as the Xamarin.Forms Behavior
    /// </summary>
    public abstract class NativeBehavior<T> where T : class
    {
        public void Attach(T bindable)
        {
            if (bindable != null)
                OnAttachedTo(bindable);
        }

        public void Detach(T bindable)
        {
            if (bindable != null)
                OnDetachingFrom(bindable);
        }

        /// <summary>
        /// The name of the behavior
        /// </summary>
        /// <value>The name of the behavior.</value>
        public abstract string BehaviorName { get; }

        /// <summary>
        /// Attach events on attachment to view
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected abstract void OnAttachedTo(T bindable);

        /// <summary>
        /// Detach events on detaching from view
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected abstract void OnDetachingFrom(T bindable);
    }
}
