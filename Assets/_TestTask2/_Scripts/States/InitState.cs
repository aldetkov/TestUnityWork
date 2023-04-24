using AxGrid.FSM;

[State(nameof(InitState))]
public class InitState : FSMState
{
    private readonly int _collectionStartSize = 32;

    #region States

    [Enter]
    private void EnterThis()
    {
        InitializeCardCollection(_collectionStartSize, CardCollectionName.HandleCardCollection, CardCollectionEventName.HandleCardCollectionEvent);
        InitializeCardCollection(_collectionStartSize, CardCollectionName.DropCardCollection, CardCollectionEventName.DropCardCollectionEvent);

        StateLog.EnterState(Parent);
    }

    [One(0f)]
    private void ChangeState()
    {
        Parent.Change(nameof(ReadyState));
    }

    [Exit]
    private void ExitThis()
    {
        StateLog.ExitState(Parent);
    }

    #endregion

    private void InitializeCardCollection(int collectionSize, CardCollectionName cardCollectionName, CardCollectionEventName cardCollectionEventName)
    {
        _ = new CardCollection<Card>(collectionSize, cardCollectionName, cardCollectionEventName);
    }
}
