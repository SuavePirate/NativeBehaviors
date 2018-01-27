# NativeBehaviors
A behaviors implementation for Xamarin Native controls meant to reflect the usefulness of Xamarin.Forms.Behaviors

## Installation

This project is up on NuGet now:

```
Install-Package NativeBehaviors
```

## Usage

These behaviors are meant to reflect the same use as Xamarin.Forms Behaviors, but require a little more work to manage the lifecycle of events since native views don't have a collection of Behaviors as a property.

1. Create a custom Behavior on your native platform. This example will use an iOS `UITextField`

**TextFieldPhoneMaskBehavior.cs**
``` csharp
/// <summary>
/// Text field phone mask behavior.
/// Format of (###) ###-####
/// </summary>
public class TextFieldPhoneMaskBehavior : NativeBehavior<UITextField>
{
    public override string BehaviorName => nameof(TextFieldPhoneMaskBehavior);

    private string _previousText = string.Empty;
    /// <summary>
    /// Attach text changed event
    /// </summary>
    /// <param name="bindable">Bindable.</param>
    protected override void OnAttachedTo(UITextField bindable)
    {
        bindable.EditingChanged += Bindable_TextChanged;
    }

    /// <summary>
    /// Detach event
    /// </summary>
    /// <param name="bindable">Bindable.</param>
    protected override void OnDetachingFrom(UITextField bindable)
    {
        bindable.EditingChanged -= Bindable_TextChanged;
    }

    /// <summary>
    /// Apply mask
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void Bindable_TextChanged(object sender, EventArgs e)
    {
        var textField = sender as UITextField;

        // only apply change if typing forward
        if (textField != null && textField.Text.Length > _previousText.Length)
        {
            if (textField.Text.Length == 1)
            {
                // we have our first number, add the ( behind it
                textField.Text = $"({textField.Text}";
            }
            if (textField.Text.Length == 4)
            {
                // finish the area code
                textField.Text += ") ";
            }
            if (textField.Text.Length == 9)
            {
                // add dash
                textField.Text += "-";
            }
        }
        _previousText = textField.Text;
    }
}
```

2. Attach Behavior in lifecycle

**MyViewController.cs**
``` csharp
using NativeBehaviors; // needed for extension method
...
private TextFieldPhoneMaskBehavior _phoneMaskBehavior;

protected override void ViewWillAppear(bool animated)
{
    ...
    _phoneMaskBehavior = new TextFieldPhoneMaskBehavior();
    myTextField.AttachBehavior(_phoneMaskBehavior);
    ...
}
...
```

3. Detach Behavior in lifecycle

**MainActivity.cs**
``` csharp
using NativeBehaviors; // needed for extension method
...
protected override void ViewDidDisappear()
{
    ...
    myTextField.DetachBehavior(_phoneMaskBehavior);
    ...
}
...
```

Use the `ViewWillAppear` and `ViewDidDisappear` events in your iOS ViewControllers.

## TODO
Add example project and screenshots
