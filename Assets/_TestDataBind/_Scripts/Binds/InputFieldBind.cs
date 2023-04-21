using AxGrid.Base;
using UnityEngine;
using TMPro;
using AxGrid;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldBind : MonoBehaviourExtBind
{
    [SerializeField] private string _textFieldName;
    [SerializeField] private bool _onValueChanged;

    private TMP_InputField _inputFieldTMP;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _inputFieldTMP = GetComponent<TMP_InputField>();

        if (_onValueChanged)
        {
            _inputFieldTMP.onValueChanged.AddListener(OnValueChanged);
            return;
        }

        _inputFieldTMP.onEndEdit.AddListener(OnValueChanged);
    }

    #endregion

    #region Binds

    public void OnValueChanged(string text)
    {
        Model.SetString(_textFieldName, text);
        Settings.Fsm.Invoke($"On{_textFieldName}Changed", text);
    }

    #endregion
}
