# Xamarin iOS

This document contains some notes on my current findings in exploring the Xamarin iOS API

## Setting up a project

When your app starts it finds the default **UIViewController** and fires it up. You can change the default **UIViewController** by overriding the **FinishedLaunching()** method in **AppDelegate** and setting up the apps **Window**. 

```csharp
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds); // make the app take the whole screen
            Window.RootViewController = new MyViewController(); // Set the root view controller for the app
            Window.MakeKeyAndVisible(); // Put the app on screen

            return true;
        }
```

This will fire up the app with the **UIViewController** that you specify as the **RootViewController**. Further initialisation can be done in the **UIViewController's** constructor and **ViewDidLoad()** method. In ListViewController, I setup a list using a **UITableView**.

## View Controllers

iOS layout is based on the MVC pattern and therefore your app and your **UIView** will have a **UIViewController** inbetween.

Your App -> View Controller -> View -> Device Screen

This is why we had to set up the **RootViewController** earlier. n


```csharp
        public ListViewController()
        {
            ListView = new UITableView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ListView = new UITableView();
            ListView.Frame = View.Frame;
            
            ...

            View.Add(ListView);
        }
```

The view controller has a **View** property which is the root **UIView** for that page, you can add lots of Views to this view

## Layout

Layout in iOS is a little tricky, the newer (and right) way of doing it is to use Auto Layout, its very powerful and the de-facto method for the iOS Storyboard Designer in Xamarin Studio and XCode. It is a relative layout system that bases positions of views on other views *related to them* (they call them **UIViews**). If you are using the designer a lot of these complexities are hidden, but we're learning so we want to look under the hood.

So what is a **UIView**?

#### UIViews

Views are the visual elements that appear in apps, they can show things and respond to system events like taps and gestures. they can contain _subviews_, in which case the view you add them two is called the _superview_. Unlike other layout system, any view, including the base UIView, can have multiple subviews.

Examples of **UIVIews** include **UITextView, UILabel, ULStackView, UITableView** etc.

It should be noted that simply adding subviews to a view will not make them display as you expect, there are a couple more steps.

#### The values vs constraints

In order for iOS to layout your views, it needs to know 4 things (values), each of the x and y co-ordinates, the width, and the height. It's possible to build apps by providing these explicitly for all views, but then they don't scale well.

instead of providing them explicitly, we provide iOS with a set of constraints which it can work it out. An example of a constraint is.

* The left side of view2 should be 8pt from the right side of view1 horizontally
* The right side of view2 should be 8px from the right edge of the screen

Notice that with those two constraints iOS can work out the implicit width (fill the gap between view1 and the right edge of the screen).

These constraints are expressed as a formula

#### The constraint formula

The formula for a constraint looks like this:

```swift
 view1.left = 1 * view2.right + 8
 ```

This constraint means that view1's left side will be positioned 8 points right of the right side of view2 _horizontally_. this is effectively the constraining x value. there are many different attributes that can be constrained, including 
* left and right (or leading/trailing to support right-to-left)
* top and bottom
* left margin, right margin, top margin, bottom margin
* width and height
* centerX and centerY

etc...

The formula can be expressed more generically as:

```csharp
item1.attribute1 = (multiplier) * item2.attribute2 + (constant)
```

sometimes there is no item2 / attribute2 or constant, but this is generally the case.

#### Constraints in code

There are a couple of ways of adding constraints in code, both of which can be seen in ListOfViewsController.cs.

The first way:

```csharp
myView1.AddConstraint(NSLayoutConstraint.Create(myView1,NSLayoutAttribute.Left,NSLayoutRelation.Equal, myView2, NSLayoutAttribute.Right,1,0))
```

The second (shorter) way:

```csharp
myView2.LeftAnchor.ConstraintEqualTo(myView1.RightAnchor).Active = true;
```