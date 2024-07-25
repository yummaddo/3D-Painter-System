using System;
using Game.SelectionMesh;
using UnityEngine;
using Zenject;

namespace Game.Pool
{
    public class PoolTargetElementService : MonoBehaviour
    {
        public Transform root;
        public event Action<SelectionMeshToDraw> OnClearLastPaintTarget;
        public event Action<SelectionMeshToDraw> OnCreationNewPaintTarget;
        
        private SelectionMeshMenu _selectionMeshMenu;
        private GameObject _targeting = null;
        private SelectionMeshToDraw _targetingDataInformation = null;
        
        [Inject] 
        public void Construct(SelectionMeshMenu menu)
        {
            _selectionMeshMenu = menu;
            _selectionMeshMenu.OnButtonClickBySelection += SelectionMeshMenuOnButtonClickBySelection;
        }
        private void SelectionMeshMenuOnButtonClickBySelection(SelectionMeshButton obj)
        {
            if (_targeting == null || _targetingDataInformation == null)
                CreationNewPaintTarget(obj.selectionMeshToDraw);
            else
            {
                ClearLastPaintTarget();
                CreationNewPaintTarget(obj.selectionMeshToDraw);
            }
        }

        private void ClearLastPaintTarget()
        {
            OnClearLastPaintTarget?.Invoke(_targetingDataInformation);
            Destroy(_targeting);
            _targetingDataInformation = null;
        }
        

        private void CreationNewPaintTarget(SelectionMeshToDraw obj)
        {
            OnCreationNewPaintTarget?.Invoke(obj);
            _targeting = Instantiate(obj.prefab, root);
            _targetingDataInformation = obj;
        }
    }
}