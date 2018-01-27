# NativeBehaviors
A behaviors implementation for Xamarin Native controls meant to reflect the usefulness of Xamarin.Forms.Behaviors

## Installation

This project is up on NuGet now:

```
Install-Package NativeBehaviors
```

## Usage

These behaviors are meant to reflect the same use as Xamarin.Forms Behaviors, but require a little more work to manage the lifecycle of events since native views don't have a collection of Behaviors as a property.

1. Create a custom Behavior on your native platform. This example will use an Android `EditText`

**EditTextMonthYearMaskBehavior.cs**
``` csharp
/// <summary>
/// EditText month date mask behavior. Masks with a slash between characters
/// Either MM/YY or MM/YYYY
/// </summary>
public class EditTextMonthYearMaskBehavior : Behavior<EditText>
{
    public override string BehaviorName { get { return nameof(EditTextMonthYearMaskBehavior); } }
    /// <summary>
    /// Attaches when the page is first created.
    /// </summary>
    ///<param name="bindable">input entry</param>
    protected override void OnAttachedTo(EditText bindable)
    {
        bindable.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(bindable);
    }

    /// <summary>
    /// Detaches when the page is destroyed.
    /// </summary>
    ///<param name="bindable">input entry</param>
    protected override void OnDetachingFrom(EditText bindable)
    {
        bindable.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(bindable);
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
    {
        var entry = sender as EditText;
        if (!string.IsNullOrWhiteSpace(args.Text) && entry != null)
        {
            // only add behavior if we are moving forward
            if (args.BeforeCount < args.AfterCount) return;
            
            var value = args.Text;

            if (value.Length == 2)
            {
                entry.Text += "/";
            }
        }
    }
}
```

2. Attach Behavior in lifecycle

**MainActivity.cs**
``` csharp
using NativeBehaviors; // needed for extension method
...
private EditTextMonthYearMaskBehavior _monthYearBehavior;

protected override void OnCreate(Bundle savedInstanceState)
{
    ...
    _monthYearBehavior = new EditTextMonthYearMaskBehavior();
    myEditText.AttachBehavior(_monthYearBehavior);
    ...
}
...
```

3. Detach Behavior in lifecycle

**MainActivity.cs**
``` csharp
using NativeBehaviors; // needed for extension method
...
protected override void OnDestroy()
{
    ...
    myEditText.DetachBehavior(_monthYearBehavior);
    ...
}
...
```

Use the `ViewWillAppeaer` and `ViewDidDisappear` events in your iOS ViewControllers.

## TODO
Add example project and screenshots
