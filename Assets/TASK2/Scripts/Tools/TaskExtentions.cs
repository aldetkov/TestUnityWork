using AxGrid.Model;
using UnityEngine;

namespace CardTask
{
    public static class TaskExtentions 
    {
        public static void AddListObject<T>(this DynamicModel model, string listKey, T addedObject)
        {
            model.GetList<T>(listKey).Add(addedObject);

            model.EventManager.Invoke(EventKeys.OnAddCard, model.GetList<T>(listKey));
        }

        public static void RemoveListObject<T>(this DynamicModel model, string listKey, T removedObject)
        {
            model.GetList<T>(listKey).Remove(removedObject);

            model.EventManager.Invoke(EventKeys.OnRemoveCard, removedObject);
        }

        public static void TranslateListObject<T>(this DynamicModel model, string listFromKey, string listToKey, T translatedObject)
        {
            model.GetList<T>(listToKey).Add(translatedObject);

            model.GetList<T>(listFromKey).Remove(translatedObject);
        }
    }
}
