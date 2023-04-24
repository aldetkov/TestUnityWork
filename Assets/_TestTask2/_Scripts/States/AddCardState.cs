using AxGrid;
using AxGrid.FSM;

[State(nameof(AddCardState))]
public class AddCardState : FSMState
{
    private readonly int _maxIndex = 99;

    #region States

    [Enter]
    private void EnterThis()
    {
        StateLog.EnterState(Parent);
        AddCard();
    }

    [One(0f)]
    private void ChangeState()
    {
        Parent.Change(nameof(ReadyState));
    }

    [Exit]
    private void Exit()
    {
        StateLog.ExitState(Parent);
    }

    #endregion

    private void AddCard()
    {
        CardCollection<Card> handleCardCollection = Settings.Model.Get<CardCollection<Card>>(CardCollectionName.HandleCardCollection.ToString());
        handleCardCollection.Add(new Card(_maxIndex));
    }
}

