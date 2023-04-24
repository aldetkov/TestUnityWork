using AxGrid.FSM;

[State(nameof(ReadyState))]
public class ReadyState : AState
{
    #region States

    [Enter]
    private protected override void OnEnter()
    {
        base.OnEnter();
    }

    #endregion
}
