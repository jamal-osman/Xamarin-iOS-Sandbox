using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UIKit;

namespace DevSandbox
{
    public class ListEntry
    {
        public string DisplayText { get; set; }
        public string SubText { get; set; }
        public virtual UIViewController ViewController { get { return new UIViewController(); } }
    }

    public class ListEntry<T> : ListEntry where T : UIViewController, new()
    {
        public override UIViewController ViewController { get { return new T(); } }
    }
}
