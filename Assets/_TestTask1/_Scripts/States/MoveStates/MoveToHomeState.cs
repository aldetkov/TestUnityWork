using AxGrid.FSM;

[State(nameof(MoveToHomeState))]
public class MoveToHomeState : AMoveToState
{
    private static readonly MoveToStateName _moveToHomeState = MoveToStateName.InHomeState;
    private static readonly ButtonBind _buttonBind = ButtonBind.BtnHomeButtonEnable;
    private static readonly FsmEvent _fsmEvent = FsmEvent.OnStartMoveToHome;

    public MoveToHomeState() : base(_moveToHomeState, _buttonBind, _fsmEvent) { }
}
