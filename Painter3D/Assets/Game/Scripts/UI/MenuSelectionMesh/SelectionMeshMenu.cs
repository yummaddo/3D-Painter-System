using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MenuSelectionMesh
{
    public class SelectionMeshMenu : AbstractMenu
    {
        public event Action<SelectionMeshButton> OnButtonClickBySelection;
        public event Action<SelectionMeshButton> OnButtonSelectorRegister;
        private List<SelectionMeshButton> _meshButtons = new List<SelectionMeshButton>();
        
        internal void ButtonClickedBySelector(SelectionMeshButton selectionMeshButton)
        {
            OnButtonClickBySelection?.Invoke(selectionMeshButton);
            Exit();
        }
        internal void ButtonSelectorRegistration(SelectionMeshButton selectionMeshButton)
        {
            _meshButtons.Add(selectionMeshButton);
            OnButtonSelectorRegister?.Invoke(selectionMeshButton);
        }

        [field:SerializeField]public override Button ExitButton { get; set; }
        protected override void Exit()
        {
            ExitButton.onClick.Invoke();
        }
    }
}