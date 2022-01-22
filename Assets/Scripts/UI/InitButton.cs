using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InitButton : MonoBehaviour
    {
        private GameObject _lastSelected;

        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(_lastSelected);
            }
            else
            {
                _lastSelected = EventSystem.current.currentSelectedGameObject;
            }
        }
    }
}
