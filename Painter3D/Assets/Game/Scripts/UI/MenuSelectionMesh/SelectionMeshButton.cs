﻿using Game.Pool;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.SelectionMesh
{
    public class SelectionMeshButton : MonoBehaviour
    {
        public Button button;
        public MeshToDraw meshToDraw;
        private SelectionMeshMenu _selectionMeshMenu;
        [Inject] 
        public void Construct(SelectionMeshMenu menu)
        {
            _selectionMeshMenu = menu;
            _selectionMeshMenu.ButtonSelectorRegistration(this);
        }
        public void ClickCallback()
        {
            _selectionMeshMenu.ButtonClickedBySelector(this);
        }
    }
}