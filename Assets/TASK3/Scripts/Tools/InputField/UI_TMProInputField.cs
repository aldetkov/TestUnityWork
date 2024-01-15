using AxGrid;
using AxGrid.Base;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class UI_TMProInputField : MonoBehaviourExtBind
{
    [SerializeField] protected string fieldName = "";

    protected TMP_InputField field;

    [OnAwake]
    protected void AwakeThis()
    {
        field = GetComponent<TMP_InputField>();

        if (string.IsNullOrEmpty(fieldName))
        {
            fieldName = name;
            Log.Warn($"InputField name is empty {field.name}");
        }

        field.onValueChanged.AddListener(InvokeFieldChange);
        field.onEndEdit.AddListener(InvokeEndEdit);

        field.onSelect.AddListener(InvokeOnSelect);
        field.onDeselect.AddListener(InvokeOnDeselect);
    }

    protected void InvokeFieldChange(string value)
    {
        Model.SetString($"TField{fieldName}Change", value);
        Settings.Fsm.Invoke("TFieldChange", fieldName, value);
    }

    protected void InvokeEndEdit(string value)
    {
        Model.SetString($"TField{fieldName}End", value);
        Settings.Fsm.Invoke("TFieldEnd", fieldName, value);
    }

    protected void InvokeOnSelect(string value)
    {
        Settings.Invoke("TFieldSelect", fieldName);
    }

    protected void InvokeOnDeselect(string value)
    {
        Settings.Invoke("TFieldDeSelect", fieldName);
    }

    [OnDestroy]
    protected void DestroyThis()
    {
        field.onValueChanged.RemoveListener(InvokeFieldChange);
        field.onEndEdit.RemoveListener(InvokeEndEdit);

        field.onSelect.RemoveListener(InvokeOnSelect);
        field.onDeselect.RemoveListener(InvokeOnDeselect);
    }
}