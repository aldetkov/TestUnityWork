using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

public abstract class AState : FSMState
{
    #region States

    private protected virtual void OnEnter()
    {
        SetFieldAudioClip();

        SetTextCurrentStateName();

        SetBackgroundColor();

        SetStateFieldColors();
    }

    #endregion

    #region Binds

    [Bind]
    private void OnBtn(string buttonName)
    {
        if (!Enum.TryParse(buttonName, out ButtonFieldName buttonFieldName))
            throw new ArgumentException(nameof(buttonName));

        switch (buttonFieldName)
        {
            case ButtonFieldName.ChangeState: ChangeStateByText(); break;
            default: throw new ArgumentException(nameof(buttonFieldName));
        }
    }

    [Bind]
    private void OnAutoChangeChanged()
    {
        SetAutoChange();
    }

    [Bind]
    private void OnStateToChangeChanged()
    {
        TryAutoChangeState();
    }

    #endregion

    private void ChangeStateByText()
    {
        string text = Model.GetString(TextFieldName.StateToChange.ToString());

        if (this.GetType().Name == text)
            return;

        if (Settings.Fsm.ContainsState(text))
            Parent.Change(text);
    }

    #region SetModel

    private void SetFieldAudioClip()
    {
        Settings.Model.Inc(AudioClipFieldName.ClickSound.ToString());
    }

    private void SetAutoChange()
    {
        TryAutoChangeState();
    }

    private void TryAutoChangeState()
    {
        if (!Model.GetBool(ToggleFieldName.AutoChange.ToString()))
            return;

        ChangeStateByText();
    }

    private void SetBackgroundColor()
    {
        Settings.Model.Set(GraphicFieldName.MainBackgroundImage.ToString(), Random.ColorHSV());
    }

    private void SetTextCurrentStateName()
    {
        string stateName = this.GetType().Name;
        Settings.Model.SetString(TextFieldName.CurrentState.ToString(), stateName);
    }

    private void SetStateFieldColors()
    {
        MainFsm mainFsm = Settings.GlobalModel.Get<MainFsm>(nameof(MainFsm));
        string fieldName = mainFsm.StateFieldColorName;
        List<FSMState> states = mainFsm.CurrentStateList;

        for (int i = 1; i < states.Count; i++)
        {

            if (this.GetType().Name == states[i].GetType().Name)
            {
                Settings.Model.Set(fieldName + i, mainFsm.SelectedColor);
                continue;
            }

            Settings.Model.Set(fieldName + i, mainFsm.DefaultColor);
        }
    }

    #endregion

}