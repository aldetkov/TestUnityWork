using AxGrid.FSM;

[State(nameof(StateTwo))]
public class StateTwo : AState
{
    #region States

    [Enter]
    private protected override void OnEnter()
    {
        base.OnEnter();
    }

    #endregion
}