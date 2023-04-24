using AxGrid.FSM;

[State(nameof(StateFour))]
public class StateFour : AState
{
    #region States

    [Enter]
    private protected override void OnEnter()
    {
        base.OnEnter();
    }

    #endregion
}
