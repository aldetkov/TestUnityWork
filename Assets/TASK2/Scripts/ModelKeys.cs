namespace CardTask
{
    public class ModelKeys
    {
        public const string tableCollection = "tableCollect";
        public const string userCollection = "userCollect";

        public const string translatedCard = "translateCard";
    }

    public static class StateKeys
    {
        public const string initState = "initState";
        public const string OnDrawState = "onDrawState";
        public const string OnTranslateState = "onTranslateState";
    }

    public static class EventKeys
    {
        public const string OnAddCard = "addCard";
        public const string OnRemoveCard = "removeCard";
        public const string OnTranslateCard = "cardTranslate";

        public const string OnMoveCards = "moveCards";
    }

    public static class ToolsKeys
    {
        public const string btnClickKey = "btnClick";
    }
}
