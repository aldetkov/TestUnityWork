using AxGrid.FSM;
using UnityEngine;

namespace CardTask
{
    [State(StateKeys.OnDrawState)]
    public class OnDrawState : AbstractState
    {
        private string[] _cardsList = new string[] {"red", "green", "blue"};

        [Enter]
        private void OnEnterThis()
        {
            Card newRandomCard = new Card(_cardsList[new System.Random().Next(0, _cardsList.Length)], ModelKeys.userCollection);

            Model.AddListObject(ModelKeys.userCollection, newRandomCard);
        }
    }
}
