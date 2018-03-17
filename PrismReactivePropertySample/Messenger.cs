using Prism.Events;

namespace PrismReactivePropertySample
{
    public class Messenger : EventAggregator
    {
        private static Messenger _instance;

        public static Messenger Instance => _instance ?? (_instance = new Messenger());
    }
}