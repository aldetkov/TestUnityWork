using AxGrid.FSM;
using AxGrid.Model;

[State(nameof(ReadyState))]
public class ReadyState : FSMState
{
    #region States

    [Enter]
    private void EnterThis()
    {
        StateLog.EnterState(Parent);
    }

    [Exit]
    private void ExitThis()
    {
        StateLog.ExitState(Parent);
    }

    #endregion

    #region Binds

    [Bind]
    private void OnDrawButton()
    {
        Parent.Change(nameof(AddCardState));
    }

    [Bind]
    private void OnCardButton()
    {
        Parent.Change(nameof(DropCardState));
    }

    #endregion
}
