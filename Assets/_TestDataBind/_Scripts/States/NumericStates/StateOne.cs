using AxGrid.FSM;

[State(nameof(StateOne))]
public class StateOne : AState
{
    #region States

    [Enter]
    private protected override void OnEnter()
    {
        base.OnEnter();
    }

    #endregion
}