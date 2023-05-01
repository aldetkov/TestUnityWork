namespace CardTask
{
    public class ModelKeys
    {
        public const string tableCollection = "tableCollect";
        public const string userCollection = "userCollect";
        public const string nextCard = "nextCard";
        public const string translatedCard = "translateCard";
    }

    public static class StateKeys
    {
        public const string initState = "initState";
        public const string OnDrawState = "onDrawState";
        public const string translateState = "onTranslateState";
    }

    public static class EventKeys
    {
        public const string OnInitCollections = "initCollections";

        public const string OnAddCard = "addCard";
        public const string OnGetNewCard = "newCard";

        public const string OnCardTranslate = "cardTranslate";
        public const string OnSetTranslatedCard = "setCardTranslate";

        public const string OnMoveCards = "moveCards";
        public const string OnCardClick = "cardClick";
    }

    public static class ToolsKeys
    {
        public const string btnClickKey = "btnClick";
    }
}
