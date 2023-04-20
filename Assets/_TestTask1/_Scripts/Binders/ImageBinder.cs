using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBinder : MonoBehaviourExtBind
{
    private Image _image;

    [SerializeField]
    private string _fieldName;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _image = GetComponent<Image>();
    }

    #endregion

    #region Binds

    [Bind("On{_fieldName}Changed")]
    public void OnValueChanged(Color color)
    {
        _image.color = color;
    }

    #endregion
}
