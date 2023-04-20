using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System;

public class AMoveToState : FSMState
{
    private readonly MoveToStateName _moveToStateName;
    private readonly ButtonBind _buttonBind;
    private readonly FsmEvent _fsmEvent;

    public AMoveToState(MoveToStateName moveToStateName, ButtonBind currentButtonBind, FsmEvent fsmEvent)
    {
        _moveToStateName = moveToStateName;
        _buttonBind = currentButtonBind;
        _fsmEvent = fsmEvent;
    }

    #region States

    [Enter]
    private void EnterThis()
    {
        Settings.Invoke(_fsmEvent.ToString());
        Settings.Model.Set(_buttonBind.ToString(), false);
        Helper.ChangeViewState();
    }

    [Exit]
    private void ExitThis()
    {
        Settings.Model.Set(_buttonBind.ToString(), true);
    }

    #endregion

    [Bind]
    private void OnBtn(string buttonName)
    {
        if (!Enum.TryParse(buttonName, out ButtonBind buttonBind))
            throw new ArgumentException(nameof(buttonName));

        switch (buttonBind)
        {
            case ButtonBind.HomeButton: Parent.Change(nameof(MoveToHomeState)); break;
            case ButtonBind.WorkButton: Parent.Change(nameof(MoveToWorkState)); break;
            case ButtonBind.ShopButton: Parent.Change(nameof(MoveToShopState)); break;
        }
    }

    [Bind]
    private void OnTargetPoint()
    {
        switch (_moveToStateName)
        {
            case MoveToStateName.InHomeState: Parent.Change(nameof(InHomeState)); break;
            case MoveToStateName.InWorkState: Parent.Change(nameof(InWorkState)); break;
            case MoveToStateName.InShopState: Parent.Change(nameof(InShopState)); break;
            default: throw new ArgumentNullException();
        }
    }
}
