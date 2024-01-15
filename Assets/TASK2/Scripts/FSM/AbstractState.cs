using AxGrid.FSM;
using AxGrid.Model;

namespace CardTask
{
    public class AbstractState : FSMState
    {
        protected const int MaxUserCollectSize = 6;
        protected const int MaxTableCollectSize = 7;

        protected const string DrawButtonName = "drawButton";
        protected const string CardButtonName = "cardButton";

        [Bind(ToolsKeys.btnClickKey)]
        private void OnButtonClick(string name)
        {
            Model.EventManager.Invoke("OnClickPlay");

            switch (name)
            {
                case CardButtonName:
                    Parent.Change(StateKeys.OnTranslateState);
                    break;
                case DrawButtonName:
                    Parent.Change(StateKeys.OnDrawState);
                    break;
            }

            OnUpdateValues();
        }

        protected void OnUpdateValues()
        {
            var userCollectCount = Model.GetList<Card>(ModelKeys.userCollection).Count;

            var tableCollectCount = Model.GetList<Card>(ModelKeys.tableCollection).Count;

            SetButtonsInterectable(userCollectCount, tableCollectCount);

            UpdateTexts(userCollectCount, tableCollectCount);
        }
        protected void SetButtonsInterectable(int userCount, int tableCount)
        {
            Model.Set($"Btn{DrawButtonName}Enable", userCount < MaxUserCollectSize);

            Model.Set($"Btn{CardButtonName}Enable", tableCount < MaxTableCollectSize);
        }

        protected void UpdateTexts(int userCount, int tableCount)
        {
            Model.Set("userCollectCount", userCount);

            Model.Set("tableCollectCount", tableCount);
        }
    }
}
