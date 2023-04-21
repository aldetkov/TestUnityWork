using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

public class ColorBinder : MonoBehaviourExtBind
{
    [SerializeField]
    private string _fieldName;

    private Graphic _target;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _target = GetComponent<Graphic>();

        switch (_target)
        {
            case Image image:
                _target = image;
                break;
            case Text text:
                _target = text;
                break;
        }
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
