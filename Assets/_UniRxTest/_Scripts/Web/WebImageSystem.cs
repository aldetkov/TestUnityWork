using UnityEngine;
using UniRx;
using System;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid;

public class WebImageSystem : MonoBehaviourExtBind
{
    private const string IMAGE_FIELD = "WebImage";
    private const string IMAGE_URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaWuvN6y8M_CveRi17h9Wm0zuTnwTd_WerzfngSJc&s";

    #region Binds

    [Obsolete]
    [Bind]
    private void OnGetImageClick()
    {
        Request();
    }

    #endregion

    #region Web

    [Obsolete]
    public IObservable<byte[]> Request(string url)
    {
        return ObservableWWW.GetAndGetBytes(url)
            .Timeout(TimeSpan.FromSeconds(5))
            .DoOnError(error =>
            {
                Debug.LogError($"Retry: {error.Message}");
            });
    }

    [Obsolete]
    private void Request()
    {
        Request(IMAGE_URL).ObserveOnMainThread().Subscribe(response =>
        {
            Settings.Model.Set(IMAGE_FIELD, CreateSprite(response));
        }, err =>
        {
            Debug.Log(err);
        });
    }

    #endregion

    private Sprite CreateSprite(byte[] response)
    {
        Texture2D texture = new(1, 1);
        texture.LoadImage(response);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}
