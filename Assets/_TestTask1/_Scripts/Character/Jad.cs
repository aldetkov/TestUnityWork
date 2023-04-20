using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class Jad : MonoBehaviourExtBind
{
    private readonly Vector2 _homePoint = new(-5f, -4f);
    private readonly Vector2 _shopPoint = new(5f, -4f);
    private readonly Vector2 _workPoint = Vector3.zero;

    #region Binds

    [Bind]
    private void OnStartMoveToWork()
    {
        Settings.Invoke(JadEvents.OnMovePoint.ToString(), _workPoint);
    }

    [Bind]
    private void OnStartMoveToHome()
    {
        Settings.Invoke(JadEvents.OnMovePoint.ToString(), _homePoint);
    }

    [Bind]
    private void OnStartMoveToShop()
    {
        Settings.Invoke(JadEvents.OnMovePoint.ToString(), _shopPoint);
    }

    #endregion
}