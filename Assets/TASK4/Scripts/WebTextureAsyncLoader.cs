using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebTextureAsyncLoader : MonoBehaviour
{
    private string urlGet = "https://drive.google.com/uc?export=download&id=14E7ZYQtQFf57SMbvpvseHf4IVB9YYwWh";

    public Image rendereR;

    public WebTextureAsyncLoader(string urlGet, Image rendereR)
    {
        this.urlGet = urlGet;
        this.rendereR = rendereR;
    }

    private void Start()
    {
        DownloadImageAsync(urlGet);
    }

    public async void DownloadImageAsync(string url)
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);

        var operation = req.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (!req.isDone)
        {
            Debug.Log($"{req.error}: {req.downloadHandler.text}");
        }

        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(req);

            rendereR.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}
