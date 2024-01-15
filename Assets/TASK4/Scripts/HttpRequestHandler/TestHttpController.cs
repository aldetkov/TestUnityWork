using UnityEngine;

public class TestHttpController : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var url = "";

        var httpClient = new HttpClient(new JsonSerializationOption());
        var result = await httpClient.Get<User>(url);
    }
}
