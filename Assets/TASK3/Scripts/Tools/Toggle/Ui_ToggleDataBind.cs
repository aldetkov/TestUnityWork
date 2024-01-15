using AxGrid;
using AxGrid.Base;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Ui_ToggleDataBind : MonoBehaviourExtBind
{
    [SerializeField] protected string toggleName = "";

    protected Toggle toggle;

    [OnAwake]
    private void AwakeThis()
    {
        toggle = GetComponent<Toggle>();
        if (string.IsNullOrEmpty(toggleName))
        {
            toggleName = name;
            Log.Warn($"Button name is empty {toggle.name}");
        }

        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    protected void OnValueChanged(bool value)
    {
        Settings.Fsm.Invoke("toggleValue", toggleName);
        Model.EventManager.Invoke($"On{toggleName}Change", value);
    }

    [OnDestroy]
    private void DestroyThis()
    {
        toggle.onValueChanged.RemoveListener(OnValueChanged);
    }
}
