using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace CardTask
{
    public class UIButtonBindInteractable : UIButtonClickInvoker
    {
        [SerializeField] private bool defaultEnable = true;
		
        private string BtnEnableField => $"Btn{buttonName}Enable";
		
        [OnStart]
        [Bind("OnBtn{buttonName}EnableChanged")]
        private void OnItemEnable()
        {
            if (button.interactable != Model.GetBool(BtnEnableField, defaultEnable))
                button.interactable = Model.GetBool(BtnEnableField, defaultEnable);
        }
    }
}