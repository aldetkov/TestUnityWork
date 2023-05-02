using AxGrid;
using AxGrid.Model;
using UnityEngine;

namespace CardTask
{
    public class UICardButton : UIButtonBindInteractable
    {
        [SerializeField] private CardObject _currentCardObject;

        protected override void InvokeEvent()
        {
            Settings.Model.Set(ModelKeys.translatedCard, _currentCardObject.CurrentCard);

            base.InvokeEvent();
        }
    }
}
