using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System;

public class AInState : FSMState
{
    private readonly ButtonBind _currentButtonBind;

    public AInState(ButtonBind currentButtonBind)
    {
        _currentButtonBind = currentButtonBind;
    }

    #region States

    [Enter]
    private protected virtual void EnterThis()
    {
        Settings.Model.Set(_currentButtonBind.ToString(), false);
        Helper.ChangeViewState();
    }

    [Exit]
    private protected virtual void ExitThis()
    {
        Settings.Model.Set(_currentButtonBind.ToString(), true);
        Settings.Model.SetString(EventFiled.ChangedCoins.ToString(), "");
    }

    #endregion

    #region Binds

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

    #endregion
}