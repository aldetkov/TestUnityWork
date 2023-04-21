using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class AudioClipBind : MonoBehaviourExtBind
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private string _fieldName;

    #region Binds

    [Bind("On{_fieldName}Changed")]
    public void OnValueChanged(Vector3 point)
    {
        AudioSource.PlayClipAtPoint(_audioClip, point);
    }

    #endregion
}
