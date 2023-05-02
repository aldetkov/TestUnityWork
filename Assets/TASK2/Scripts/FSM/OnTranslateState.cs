using AxGrid.FSM;

namespace CardTask
{
    [State(StateKeys.OnTranslateState)]
    public class OnTranslateState : AbstractState
    {
        private const string objectDirection = ModelKeys.tableCollection;
        [Enter]
        private void OnEnterThis()
        {
            var translatedCard = Model.Get<Card>(ModelKeys.translatedCard);

            Model.TranslateListObject(translatedCard.parentListName, objectDirection, translatedCard);

            translatedCard.parentListName = objectDirection;

            Model.EventManager.Invoke(EventKeys.OnTranslateCard, translatedCard);
        }
    }
}
