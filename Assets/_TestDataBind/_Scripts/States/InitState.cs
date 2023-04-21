using AxGrid;
using AxGrid.FSM;
using System.Collections.Generic;

[State(nameof(InitState))]
public class InitState : FSMState
{
    #region States

    [Enter]
    private void OnEnter()
    {
        SetStateTextFields();
    }

    [One(0f)]
    private void ChangeState()
    {
        Parent.Change(nameof(ReadyState));
    }

    #endregion

    private void SetStateTextFields()
    {
        MainFsm mainFsm = Settings.GlobalModel.Get<MainFsm>(nameof(MainFsm));
        string fieldName = mainFsm.StateFieldTextName;
        List<FSMState> states = mainFsm.CurrentStateList;

        for (int i = 1; i < states.Count; i++)
            Settings.Model.Set(fieldName + i, states[i].GetType().Name);
    }
}