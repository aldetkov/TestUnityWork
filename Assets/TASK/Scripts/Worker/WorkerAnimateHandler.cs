using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

namespace TaskWorker
{
    public class WorkerAnimateHandler : MonoBehaviourExtBind
    {
        [SerializeField] private Transform _worker;

        public float WorkerPathDuration = 1;

        [Bind(EventKeys.workerToStartPos)]
        private void SetWorkerOnStartPosition()
        {
            _worker.position = Vector3.zero;
        }

        [Bind(EventKeys.workerNextPlace)]
        private void GetNewDirection()
        {
            var targetPosition = (Vector3)Settings.Model.Get(ModelKeys.placeKey);

            PathToNextPlace(targetPosition);
        }

        private void PathToNextPlace(Vector2 target)
        {
            Path.
                EasingLinear(WorkerPathDuration, 0, 1, (f) => _worker.position = Vector3.MoveTowards(_worker.position, target, f*2))
            .Action(() => Settings.Fsm.Change(Model.GetString(ModelKeys.targetState))); 
        }
    }
}
