using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using RxUI8InvokeCommand.Core.ViewModels;
using UIKit;

namespace RxUI8InvokeCommand.iOS
{
    public partial class ViewController : ReactiveViewController<TestViewModel>
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = new TestViewModel();

            this.WhenActivated(d =>
            {
                InvokeButton.Events().TouchUpInside
                            .Log(this, nameof(InvokeButton))
                            .Select(_ => Unit.Default)
                            .InvokeCommand(this, view => view.ViewModel.GenerateNewGuid)
                            .DisposeWith(d);

                ExecuteButton.Events().TouchUpInside
                             .Log(this, nameof(ExecuteButton))
                             .SelectMany(_ => ViewModel.GenerateNewGuid.Execute())
                             .Subscribe()
                             .DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.GenerateNewGuid, view => view.BindButton)
                    .DisposeWith(d);

                this.OneWayBind(ViewModel, vm => vm.NewGuid, view => view.GuidLabel.Text)
                    .DisposeWith(d);

                this.WhenAnyObservable(view => view.ViewModel.GenerateNewGuid.CanExecute)
                    .Take(1)
                    .Where(canExecute => canExecute)
                    .Log(this, nameof(ViewModel.GenerateNewGuid.CanExecute))
                    .Select(_ => Unit.Default)
                    .InvokeCommand(this, view => view.ViewModel.GenerateNewGuid)
                    .DisposeWith(d);

                // This doesn't make a difference, but to avoid the POCO message
                /*
                ViewModel.GenerateNewGuid.CanExecute
                         .Take(1)
                         .Where(canExecute => canExecute)
                         .Log(this, nameof(ViewModel.GenerateNewGuid.CanExecute))
                         .Select(_ => Unit.Default)
                         .InvokeCommand(this, view => view.ViewModel.GenerateNewGuid)
                         .DisposeWith(d);
                         */
            });
        }
    }
}
