using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using System.Collections.Generic;
using UnityEngine;

public class MainFsm : MonoBehaviourExtBind
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;
    [Space]
    [SerializeField] private string _stateFieldTextName;
    [SerializeField] private string _stateFieldColorName;

    public Color DefaultColor => _defaultColor;
    public Color SelectedColor => _selectedColor;
    public string StateFieldTextName => _stateFieldTextName;
    public string StateFieldColorName => _stateFieldColorName;
    public List<FSMState> CurrentStateList { get; private set; }

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        CurrentStateList = new List<FSMState>();

        Settings.Fsm = new();

        InitializeStates();
    }

    [OnStart]
    private void OnStart()
    {
        Settings.GlobalModel.Add(nameof(MainFsm), this);

        Settings.Fsm.Start(nameof(InitState));
    }

    [OnUpdate]
    private void OnUpdateThis()
    {
        Settings.Fsm.Update(Time.deltaTime);
    }

    #endregion

    private void AddState(FSMState fSMState)
    {
        Settings.Fsm.Add(fSMState);
        CurrentStateList.Add(fSMState);
    }

    private void InitializeStates()
    {
        AddState(new InitState());
        AddState(new ReadyState());
        AddState(new StateOne());
        AddState(new StateTwo());
        AddState(new StateThree());
        AddState(new StateFour());
    }

}