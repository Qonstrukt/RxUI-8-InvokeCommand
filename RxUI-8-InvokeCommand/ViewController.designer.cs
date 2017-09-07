// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RxUI8InvokeCommand.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BindButton { get; set; }

		[Outlet]
		UIKit.UIButton ExecuteButton { get; set; }

		[Outlet]
		UIKit.UILabel GuidLabel { get; set; }

		[Outlet]
		UIKit.UIButton InvokeButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GuidLabel != null) {
				GuidLabel.Dispose ();
				GuidLabel = null;
			}

			if (InvokeButton != null) {
				InvokeButton.Dispose ();
				InvokeButton = null;
			}

			if (ExecuteButton != null) {
				ExecuteButton.Dispose ();
				ExecuteButton = null;
			}

			if (BindButton != null) {
				BindButton.Dispose ();
				BindButton = null;
			}
		}
	}
}
