using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

namespace CardTask
{
    [State(StateKeys.OnDrawState)]
    public class OnDrawState : FSMState
    {
        private string[] _cardsList = new string[] {"red", "green", "blue"};

        [Enter]
        private void OnEnterThis()
        {
            Card newRandomCard = new Card(_cardsList[new System.Random().Next(0, _cardsList.Length)]);

            Model.GetList<Card>(ModelKeys.userCollection).Add(newRandomCard);

            Model.EventManager.Invoke(EventKeys.OnAddCard, Model.GetList<Card>(ModelKeys.userCollection));
        }

        [Bind(ToolsKeys.btnClickKey)]
        private void OnButtonClick()
        {
            Parent.Change(StateKeys.OnDrawState);
        }

        [Bind(EventKeys.OnCardClick)]
        private void OnCardClick()
        {
            Parent.Change(StateKeys.translateState);
        }
    }
}
