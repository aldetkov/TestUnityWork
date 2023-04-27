using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;
using UnityEngine.UI;

public class UIBackGroundHandler : MonoBehaviourExtBind
{
    [SerializeField] private BgColor[] _allColors;

    [SerializeField] private Image Bg;

    [SerializeField] private float _colorChangeDuration = 1;

    [OnAwake]
    private void OnAwakeThis()
    {
        foreach (var bgColor in _allColors)
        {
            Model.Set(bgColor.colorKey, bgColor.color);
        }
    }

    [Bind(EventKeys.colorChange)]
    private void OnChangeColor(string targetState)
    {
        var targetColor = (Color)Model.Get(targetState);

        Path.EasingLinear(_colorChangeDuration, 0, 1, (f) => Bg.color = Color.Lerp(Bg.color, targetColor, f / 2));
    }
}

[System.Serializable]
public struct BgColor
{
    public Color color;

    public string colorKey;
}