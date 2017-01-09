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
                    new ListEntry<PlaygroundViewController> { DisplayText = "Playground", SubText = "Standard Controls" },
                    new ListEntry<UIViewController> { DisplayText = "Collection View", SubText = "More flexible than the table views" },
                    new ListEntry<UIViewController> { DisplayText = "Pull To Refresh", SubText = "UI pattern for updating"  },
                }
            };

            View.Add(ListView);
        }
    }
}
