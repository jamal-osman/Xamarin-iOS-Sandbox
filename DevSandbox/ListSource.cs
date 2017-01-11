using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace DevSandbox
{
    public class ListSource : UITableViewSource
    {
        public List<ListEntry> Entries { get; set; } = new List<ListEntry>();
        const string CellIdentifier = "ListEntry";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier)
                                ?? new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
            var entry = Entries[indexPath.Row];
            cell.TextLabel.Text = entry.DisplayText;
            cell.DetailTextLabel.Text = entry.SubText;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var entry = Entries[indexPath.Row];
            AppDelegate.Current.NavigationController.PushViewController(entry.ViewController, true);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Entries.Count;
        }
    }
}
