using AxGrid;
using System;
using Random = UnityEngine.Random;

public static class Helper
{
    public static void ChangeViewState()
    {
        Settings.Model.SetString(EventFiled.CurrentState.ToString(), Settings.Fsm.CurrentStateName);
        Settings.Model.Set(EventFiled.BackgroundImage.ToString(), Random.ColorHSV());
    }
}
