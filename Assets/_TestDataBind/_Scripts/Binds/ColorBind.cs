using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

public class ColorBind : MonoBehaviourExtBind
{
    [SerializeField] private string _fieldName;

    private Graphic _target;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _target = GetComponent<Graphic>();
    }

    #endregion

    #region Binds

    [Bind("On{_fieldName}Changed")]
    public void OnValueChanged(Color color)
    {
        _target.color = color;
    }

    #endregion
}