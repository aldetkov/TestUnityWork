using AxGrid;
using AxGrid.Base;
using UnityEngine;

namespace TaskWorker
{
    public class WorkerPlace : MonoBehaviourExtBind
    {
        [SerializeField] private string placeKey;

        [OnStart]
        private void SetPlaceKeyAction()
        {
            Model.EventManager.AddAction($"On{placeKey}Click", SetPositionInModel);
        }
        private void SetPositionInModel()
        {
            Settings.Model.Set(ModelKeys.placeKey, transform.position);
        }
    }
}
