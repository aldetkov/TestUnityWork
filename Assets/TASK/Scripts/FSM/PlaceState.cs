using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System;

namespace TaskWorker
{
    public abstract class PlaceState : FSMState
    {
        protected Action OnPlaceAction;

        protected string bgColorKey;

        protected string placeButton;

        protected PlaceState()
        {
            Init();
        }

        protected abstract void Init();

        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, Settings.Fsm.CurrentStateName);

            Model.EventManager.Invoke(EventKeys.colorChange, bgColorKey);

            Model.Set(placeButton, false);
        }

        [Loop(1f)]
        private void WorkerPlaceAction()
        {
            OnPlaceAction?.Invoke();
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set(placeButton, true);
        }

        [Bind("OnBtn")]
        private void NextPlace(string btnName)
        {
            Model.Set(ModelKeys.targetState, btnName);

            Parent.Change(StateKeys.onWayState);
        }
    }
}
