using AxGrid.FSM;

[State(nameof(StateThree))]
public class StateThree : AState
{
    #region States

    [Enter]
    private protected override void OnEnter()
    {
        base.OnEnter();
    }
    
    #endregion
}
