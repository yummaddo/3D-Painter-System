using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts
{
    public class SelectionMeshMenu : MonoBehaviour
    {
        public event Action<SelectionMeshButton> OnButtonClickBySelection;
        public event Action<SelectionMeshButton> OnButtonSelectorRegister;
        private List<SelectionMeshButton> _meshButtons = new List<SelectionMeshButton>();
        
        internal void ButtonClickedBySelector(SelectionMeshButton selectionMeshButton)
        {
            OnButtonClickBySelection?.Invoke(selectionMeshButton);
        }
        internal void ButtonSelectorRegistration(SelectionMeshButton selectionMeshButton)
        {
            _meshButtons.Add(selectionMeshButton);
            OnButtonSelectorRegister?.Invoke(selectionMeshButton);
        }

        private void Awake()
        {
            
        }
    }
}