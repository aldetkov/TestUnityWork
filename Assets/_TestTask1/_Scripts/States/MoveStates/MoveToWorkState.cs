using AxGrid.FSM;

[State(nameof(MoveToWorkState))]
public class MoveToWorkState : AMoveToState
{
    private static readonly MoveToStateName _moveToWorkStateName = MoveToStateName.InWorkState;
    private static readonly ButtonBind _buttonBind = ButtonBind.BtnWorkButtonEnable;
    private static readonly FsmEvent _fsmEvent = FsmEvent.OnStartMoveToWork;

    public MoveToWorkState() : base(_moveToWorkStateName, _buttonBind, _fsmEvent) { }
}
