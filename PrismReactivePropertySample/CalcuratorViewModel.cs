using System.Reactive.Linq;
using Prism.Events;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismReactivePropertySample
{
    public class CalcuratorViewModel
    {
        private CalcuratorModel _model;

        [DoubleValidation]
        public ReactiveProperty<string> X { get; }
        [DoubleValidation]
        public ReactiveProperty<string> Y { get; }

        public ReactiveCommand SendSum { get; }

        public CalcuratorViewModel()
        {
            _model = new CalcuratorModel(0.0, 0.0);
            X = _model.ToReactivePropertyAsSynchronized(
                m => m.X,
                x => x.ToString(),
                s => double.Parse(s),
                ReactivePropertyMode.DistinctUntilChanged
                | ReactivePropertyMode.RaiseLatestValueOnSubscribe,
                true).SetValidateAttribute(() => X);
            Y = _model.ToReactivePropertyAsSynchronized(
                m => m.Y,
                y => y.ToString(),
                s => double.Parse(s),
                ReactivePropertyMode.DistinctUntilChanged
                | ReactivePropertyMode.RaiseLatestValueOnSubscribe,
                true).SetValidateAttribute(() => Y);
            SendSum = X.ObserveHasErrors.CombineLatest(
                Y.ObserveHasErrors, (x, y) => !x && !y)
                .ToReactiveCommand();
            SendSum.Subscribe(
                () => Messenger.Instance
                    .GetEvent<PubSubEvent<double>>().Publish(_model.Sum()));
        }
    }
}