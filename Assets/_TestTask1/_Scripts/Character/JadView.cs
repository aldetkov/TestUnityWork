using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class JadView : MonoBehaviourExtBind
{
    [SerializeField] private float _timeSlowAnimation = 2.5f;

    private static readonly int _walkHash = Animator.StringToHash("Walk");

    private SpriteRenderer _spriteRenderer;

    private readonly Vector2 _centerPoint = new(0f, -4f);
    private readonly float _maxDistance = 5f;

    #region Mono

    [OnAwake]
    private void AwakeThis()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #endregion

    #region Binds

    [Bind]
    private void OnMovePoint(Vector2 target)
    {
        MoveToPoint(target);
    }
    #endregion

    private void MoveToPoint(Vector2 target)
    {
        InitializeMoveTo(target);

        if (target.y == transform.position.y || target.x == transform.position.x)
        {
            MoveLinearTo(target, transform.position);
            return;
        }

        MoveAlongArcTo(target, transform.position);
    }

    #region MoveAnimation

    private void MoveLinearTo(Vector2 target, Vector2 currentPos)
    {
        Path.EasingLinear(GetTimeAnimation(target), 0f, 1f, value =>
        {
            transform.position = Vector3.Lerp(currentPos, target, value);
        })
         .Action(() =>
         {
             OnPointTarget();
         });
    }

    private void MoveAlongArcTo(Vector2 target, Vector2 currentPos)
    {
        float timeAnimation = GetTimeAnimation(_centerPoint);

        Path.EasingLinear(timeAnimation, 0f, 1f, value =>
        {
            transform.position = Vector3.Lerp(currentPos, _centerPoint, value);
        })
        .Action(() =>
        {
            MoveLinearTo(target, transform.position);
        });
    }

    #endregion

    #region MoveStates

    private void InitializeMoveTo(Vector2 target)
    {
        _spriteRenderer.enabled = true;
        Animator.SetBool(_walkHash, true);
        Path = new CPath();
        SetRotation(target);
    }

    private void OnPointTarget()
    {
        Animator.SetBool(_walkHash, false);
        _spriteRenderer.enabled = false;
        Settings.Fsm.Invoke(FsmEvent.OnTargetPoint.ToString());
    }

    #endregion

    #region Calucaltion

    private float GetTimeAnimation(Vector2 target)
    {
        return (Vector3.Distance(transform.position, target) / _maxDistance) * _timeSlowAnimation;
    }

    private void SetRotation(Vector3 target)
    {
        float angleY = (target.x == 0f) ? ((transform.position.x > 0f) ? 180f : 0f) : ((target.x > 0f) ? 0f : 180f);
        transform.eulerAngles = new Vector3(0f, angleY, 0f);
    }

    #endregion
}