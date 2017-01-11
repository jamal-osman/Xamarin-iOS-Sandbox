using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace DevSandbox
{
    public class TextViewsController : DevSandbox.ListOfViewsController
    {
        private static List<UIView> _views = new List<UIView>{
            new UITextView { Text = "Headline", BackgroundColor = UIColor.DarkGray, Font = UIFont.PreferredHeadline },
            new UITextView { Text = "Subheadline", BackgroundColor = UIColor.LightGray, Font = UIFont.PreferredSubheadline },
            new UITextView { Text = "Title 1 - Red", Font = UIFont.PreferredTitle1, TextColor = UIColor.Red },
            new UITextView { Text = "Title 2 - Blue", Font = UIFont.PreferredTitle2, TextColor = UIColor.Blue },
            new UITextView { Text = "Title 3 - Green", Font = UIFont.PreferredTitle3, TextColor = UIColor.Green },
            new UITextView { Text = "Caption 1 - Tinted Red", Font = UIFont.PreferredCaption1, TintColor = UIColor.Red },
            new UITextView { Text = "Caption 2", Font = UIFont.PreferredCaption2 },
            new UITextView { Text = "Body", Font = UIFont.PreferredBody },
            new UITextView { Text = "Footnote", Font = UIFont.PreferredFootnote },
            new UITextView { Text = "Callout", Font = UIFont.PreferredCallout },
            new UITextView {
                AttributedText = new NSAttributedString
                (
                    "Crazy Attributed String - Cohaesus",
                    UIFont.SystemFontOfSize(18,UIFontWeight.Thin),
                    shadow: new NSShadow
                    {
                        ShadowColor = UIColor.Black,
                        ShadowBlurRadius = 10,
                        ShadowOffset = new CGSize(10,10)
                    },
                    strokeColor: UIColor.Purple,
                    strokeWidth: 2,
                    underlineStyle: NSUnderlineStyle.Thick,
                    ligatures: NSLigatureType.All
                )
            },
        };

        public TextViewsController() : base(_views)
        {
        }
    }
}
