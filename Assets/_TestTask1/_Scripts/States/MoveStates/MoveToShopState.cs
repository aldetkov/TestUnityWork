using AxGrid.FSM;

[State(nameof(MoveToShopState))]
public class MoveToShopState : AMoveToState
{
    private static readonly MoveToStateName _moveToShopStateName = MoveToStateName.InShopState;
    private static readonly ButtonBind _buttonBind = ButtonBind.BtnShopButtonEnable;
    private static readonly FsmEvent _fsmEvent = FsmEvent.OnStartMoveToShop;

    public MoveToShopState() : base(_moveToShopStateName, _buttonBind, _fsmEvent) { }
}
