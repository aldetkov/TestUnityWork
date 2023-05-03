using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

public class TextFieldAnimateHandler : MonoBehaviourExtBind
{
    [OnAwake]
    private void AwakeThis()
    {
        SetStartScale();
    }

    [Bind("TextFieldOut")]
    private void SetStartScale()
    {
        transform.localScale = new UnityEngine.Vector2(0, transform.localScale.y);
    }

    [Bind("TextFieldIn")]
    private void AnimateField()
    {
        Path.EasingLinear(0.3f, 0, 1, (f) => transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one, f));
    }
}
