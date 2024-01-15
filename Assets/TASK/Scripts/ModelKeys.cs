namespace TaskWorker
{
    public static class ModelKeys
    {
        public const string workerDirection = "workerDirection";
        public const string targetState = "targetState";
        public const string cash = "cash";
        public const string stateView = "stateView";

        public const string placeKey = "placeKey";
    }
    public static class StateKeys
    {
        public const string homeState = "homeState";
        public const string workState = "workState";
        public const string storeState = "storeState";
        public const string onWayState = "onWayState";
        public const string initState = "initState";
    }

    public static class EventKeys
    {
        public const string workerToStartPos = "workerToStartPos";
        public const string workerNextPlace = "workerNextPlace";

        public const string colorChange = "colorKey";
    }
}