using AxGrid;
using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

public class ToogleBind : MonoBehaviourExtBind
{
    private Toggle _toggle;

    [SerializeField] private string _textFieldName;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnValueChanged);
    }

    [OnStart]
    private void OnStartThis()
    {
        Model.Set(_textFieldName, _toggle.isOn);
    }

    #endregion

    #region Binds

    public void OnValueChanged(bool toggleBool)
    {
        Model.Set(_textFieldName, toggleBool);
        Settings.Fsm.Invoke($"On{_textFieldName}Changed", toggleBool);
    }

    #endregion
}
