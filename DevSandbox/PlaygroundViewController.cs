using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace DevSandbox
{
    public class PlaygroundViewController : UIViewController
    {
        public UIScrollView ScrollContainer { get; set; }
        public UIView ContentView { get; set; } 
        public LinkedList<UIView> RowViews { get; set; } = new LinkedList<UIView>(
                new List<UIView>{
                    new UITextView
                    {
                        Text = "Text Views (This is a Headline)",
                        BackgroundColor = UIColor.DarkGray,
                        Font = UIFont.PreferredHeadline,
                    },
                    new UITextView
                    {
                        Text = "Subheadline",
                        BackgroundColor = UIColor.DarkGray,
                        Font = UIFont.PreferredSubheadline
},
                    new UITextView
                    {
                        Text = "Title 1",
                        Font = UIFont.PreferredTitle1,
                    },
                    new UITextView
                    {
                        Text = "Title 2",
                        Font = UIFont.PreferredTitle2,
                    },
                    new UITextView
                    {
                        Text = "Title 3",
                        Font = UIFont.PreferredTitle3,
                    },
                    new UITextView
                    {
                        Text = "Caption 1",
                        Font = UIFont.PreferredCaption1,
                    },
                    new UITextView
                    {
                        Text = "Caption 2",
                        Font = UIFont.PreferredCaption2,
                    }
                }
            );

        public PlaygroundViewController()
        {
            ContentView = new UIView();
            ContentView.BackgroundColor = UIColor.FromRGB(60, 0, 0);
            ContentView.TranslatesAutoresizingMaskIntoConstraints = false;

            ScrollContainer = new UIScrollView();
            ScrollContainer.BackgroundColor = UIColor.FromRGB(0, 60, 0);
            ScrollContainer.TranslatesAutoresizingMaskIntoConstraints = false;

            View.BackgroundColor = UIColor.White;
            //View.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ContentView.AddSubviews(RowViews.ToArray());

            ScrollContainer.Add(ContentView);

            View.Add(ScrollContainer);


            var node = RowViews.First;
            while (node.Next != null)
            {
                NSObject refItem = node.Previous?.Value ?? ContentView;
                var refAttribute = node.Previous == null ? NSLayoutAttribute.Top : NSLayoutAttribute.Bottom;
                UIView subview = node.Value;
                subview.TranslatesAutoresizingMaskIntoConstraints = false;

                //subview.TopAnchor.ConstraintEqualTo(refView.TopAnchor, 5).Active = true;
                //subview.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 5).Active = true;
                //subview.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, 5).Active = true;
                //subview.HeightAnchor.ConstraintEqualTo(80);

                ContentView.AddConstraints(new NSLayoutConstraint[] {
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Top,NSLayoutRelation.Equal,  refItem, refAttribute,1,20),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Leading,1,10),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, ContentView ,NSLayoutAttribute.Trailing,1,-10),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                });

                node = node.Next;
            }

            ScrollContainer.AddConstraints(new NSLayoutConstraint[] {
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Top,NSLayoutRelation.Equal, ScrollContainer, NSLayoutAttribute.Top,1,0),
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Bottom,NSLayoutRelation.Equal, ScrollContainer ,NSLayoutAttribute.Bottom,1,0),
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, ScrollContainer, NSLayoutAttribute.Leading,1,0),
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, ScrollContainer ,NSLayoutAttribute.Trailing,1,0),
            });

            View.AddConstraints(new NSLayoutConstraint[] {
                NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Top,NSLayoutRelation.Equal, TopLayoutGuide, NSLayoutAttribute.Top,1,0),
                NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Bottom,NSLayoutRelation.Equal, BottomLayoutGuide, NSLayoutAttribute.Bottom,1,0),
                NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading,1,0),
                NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, View ,NSLayoutAttribute.Trailing,1,0),
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Width,NSLayoutRelation.Equal, View, NSLayoutAttribute.Width,1,0),
                NSLayoutConstraint.Create(ContentView,NSLayoutAttribute.Height,NSLayoutRelation.Equal, View, NSLayoutAttribute.Height,1,0),
            });
        }
    }
}
