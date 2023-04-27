using AxGrid.FSM;

namespace TaskWorker
{
    [State(StateKeys.storeState)]
    public class StoreState : PlaceState
    {
        protected override void Init()
        {
            bgColorKey = "storeColor";

            placeButton = "storeButton";

            OnPlaceAction += () => Model.Dec(ModelKeys.cash, 1);
        }
    }
}
