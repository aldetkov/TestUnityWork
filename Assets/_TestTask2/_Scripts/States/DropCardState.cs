using AxGrid;
using AxGrid.FSM;

[State(nameof(DropCardState))]
public class DropCardState : FSMState
{

    #region States

    [Enter]
    private void EnterThis()
    {
        StateLog.EnterState(Parent);
        RemoveCard();
    }

    [One(0f)]
    private void ChangeState()
    {
        StateLog.CurrentState(Parent);
        Parent.Change(nameof(ReadyState));
    }

    [Exit]
    private void Exit()
    {
        StateLog.ExitState(Parent);
    }

    #endregion

    private void RemoveCard()
    {
        CardCollection<Card> handleCardCollection = Settings.Model.Get<CardCollection<Card>>(CardCollectionName.HandleCardCollection.ToString());
        CardPrefab cardPrefab = Settings.Model.Get<CardPrefab>(Prefab.CardPrefab.ToString());

        Card card = handleCardCollection.GetCardByCardPrefab(cardPrefab);
        handleCardCollection.Remove(card);

        CardCollection<Card> dropCardCollection = Settings.Model.Get<CardCollection<Card>>(CardCollectionName.DropCardCollection.ToString());
        dropCardCollection.Add(card);
    }
}
