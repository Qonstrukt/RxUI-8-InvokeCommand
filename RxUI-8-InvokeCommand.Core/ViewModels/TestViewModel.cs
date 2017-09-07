using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace RxUI8InvokeCommand.Core.ViewModels
{
    public class TestViewModel : ReactiveObject
    {
        ObservableAsPropertyHelper<string> _newGuid;
        public string NewGuid { get { return _newGuid.Value; } }

        public readonly ReactiveCommand<Unit, string> GenerateNewGuid;


        public TestViewModel()
        {
            var canGenerateNewGuid = Observable.Return(true);
            GenerateNewGuid = ReactiveCommand.CreateFromObservable(() => GetNewGuidObservable(), canGenerateNewGuid);
            GenerateNewGuid.ToProperty(this, vm => vm.NewGuid, out _newGuid, null, false, RxApp.MainThreadScheduler);
        }

        IObservable<string> GetNewGuidObservable()
        {
            return Observable.Timer(TimeSpan.FromSeconds(2))
                             .Select(_ => Guid.NewGuid().ToString());
        }
    }
}
