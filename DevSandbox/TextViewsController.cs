using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace DevSandbox
{
    public class TextViewsController : DevSandbox.ListOfViewsController
    {
        private static List<UIView> _views = new List<UIView>{
                    new UITextView { Text = "Headline", BackgroundColor = UIColor.DarkGray, Font = UIFont.PreferredHeadline },
                    new UITextView { Text = "Subheadline", BackgroundColor = UIColor.DarkGray, Font = UIFont.PreferredSubheadline },
                    new UITextView { Text = "Title 1", Font = UIFont.PreferredTitle1 },
                    new UITextView { Text = "Title 2", Font = UIFont.PreferredTitle2 },
                    new UITextView { Text = "Title 3", Font = UIFont.PreferredTitle3 },
                    new UITextView { Text = "Caption 1", Font = UIFont.PreferredCaption1 },
                    new UITextView { Text = "Caption 2", Font = UIFont.PreferredCaption2 },
                    new UITextView { Text = "Body", Font = UIFont.PreferredBody },
                    new UITextView { Text = "Footnote", Font = UIFont.PreferredFootnote },
                    new UITextView { Text = "Callout", Font = UIFont.PreferredCallout },
            //new UITextView { AttributedText = new NSAttributedString("", new UIStringAttributes) },
                    
                    
        };

        public TextViewsController() : base(_views)
        {
        }
    }
}
