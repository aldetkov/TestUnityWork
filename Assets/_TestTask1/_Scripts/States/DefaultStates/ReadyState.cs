using AxGrid.FSM;
using AxGrid.Model;
using System;

[State(nameof(ReadyState))]
public class ReadyState : FSMState
{
    #region States

    [Enter]
    private void EnterThis()
    {
        Helper.ChangeViewState();
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
