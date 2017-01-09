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
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //View.LayoutMargins = new UIEdgeInsets(10, 10, 10, 10);
            View.BackgroundColor = UIColor.White;
            View.ClipsToBounds = true;


            ScrollContainer = new UIScrollView(View.Frame);
            ScrollContainer.BackgroundColor = UIColor.White;
            ScrollContainer.TranslatesAutoresizingMaskIntoConstraints = false;

            var views = new LinkedList<UIView>(
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

            View.AddSubviews(views.ToArray());

            var node = views.First;
            while (node.Next != null)
            {
                NSObject refItem = node.Previous?.Value ?? new NSObject(TopLayoutGuide.Handle);
                var refAttribute = node.Previous == null ? NSLayoutAttribute.Top : NSLayoutAttribute.Bottom;
                UIView subview = node.Value;
                subview.TranslatesAutoresizingMaskIntoConstraints = false;

                //subview.TopAnchor.ConstraintEqualTo(refView.TopAnchor, 5).Active = true;
                //subview.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 5).Active = true;
                //subview.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, 5).Active = true;
                //subview.HeightAnchor.ConstraintEqualTo(80);

                View.AddConstraints(new NSLayoutConstraint[] {
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Top,NSLayoutRelation.Equal,  refItem, refAttribute,1,20),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading,1,10),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, View ,NSLayoutAttribute.Trailing,1,-10),
                    NSLayoutConstraint.Create(subview,NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                });

                node = node.Next;
            }

            //View.Add(ScrollContainer);
            //View.AddConstraints(new NSLayoutConstraint[] {
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Top,NSLayoutRelation.Equal, View, NSLayoutAttribute.Top,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Bottom,NSLayoutRelation.Equal, View ,NSLayoutAttribute.Bottom,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Leading,NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading,1,0),
            //    NSLayoutConstraint.Create(ScrollContainer,NSLayoutAttribute.Trailing,NSLayoutRelation.Equal, View ,NSLayoutAttribute.Trailing,1,0),
            //});

            //ScrollContainer.BackgroundColor = UIColor.White;
            //View.Add(ScrollContainer);
            
        }
    }
}
