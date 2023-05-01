using AxGrid.FSM;
using AxGrid.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardTask
{
    [State(StateKeys.translateState)]
    public class OnTranslateState : FSMState
    {
        [Enter]
        private void OnEnterThis()
        {
            var translatedCard = Model.Get<Card>(ModelKeys.translatedCard);

            Model.GetList<Card>(ModelKeys.userCollection).Remove(translatedCard);

            Model.GetList<Card>(ModelKeys.tableCollection).Add(translatedCard);

            Model.EventManager.Invoke(EventKeys.OnCardTranslate, translatedCard);
        }

        [Bind(ToolsKeys.btnClickKey)]
        private void OnButtonClick(string name)
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
