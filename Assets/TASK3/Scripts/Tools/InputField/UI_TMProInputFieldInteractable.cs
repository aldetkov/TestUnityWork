using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class UI_TMProInputFieldInteractable : UI_TMProInputField
{
    [SerializeField] protected bool defaultEnable = true;

    protected string EnableField => $"TField{fieldName}Enable";

    [OnStart]
    [Bind("OnTField{fieldName}EnableChanged")]
    protected void OnItemEnable()
    {
        if (field.gameObject.activeSelf != Model.GetBool(EnableField, defaultEnable))
            field.gameObject.SetActive(Model.GetBool(EnableField, defaultEnable));
    }
}
