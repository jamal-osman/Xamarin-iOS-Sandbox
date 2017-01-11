using System;
using System.Collections.Generic;
using UIKit;
namespace DevSandbox
{
    public class ListViewController : UIViewController
    {
        public UITableView ListView { get; set; }

        public ListViewController()
        {
            ListView = new UITableView();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ListView = new UITableView();
            ListView.Frame = View.Frame;
            ListView.AutoresizingMask = UIViewAutoresizing.All;
            ListView.TranslatesAutoresizingMaskIntoConstraints = true;
            ListView.Source = new ListSource
            {
                Entries = {
                    new ListEntry<TextViewsController> { DisplayText = "Text views", SubText = "See some of the default fonts" },
                    new ListEntry<AutoLayoutController> { DisplayText = "Auto Layout", SubText = "Positioning examples" },
                    new ListEntry<GesturesController> { DisplayText = "Gestures", SubText = "Examples of gestures for user interaction" },
                }
            };

            View.Add(ListView);
        }
    }
}
