using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBind : MonoBehaviourExtBind
{
    [SerializeField] private string _fieldName;

    private Image _image;

    #region Mono

    [OnAwake]
    private void OnAwakeThis()
    {
        _image = GetComponent<Image>();
    }

    #endregion

    #region Binds

    [Bind("On{_fieldName}Changed")]
    public void OnValueChanged(Sprite sprite)
    {
        Debug.Log("weq");
        _image.sprite = sprite;
    }

    #endregion
}
