using System;
using Game.Pool.Elements;
using Game.UI.MenuSavePaint;
using Game.UI.MenuSelectionMesh;
using UnityEngine;
using Zenject;

namespace Game.Pool
{
    public class PoolTargetElementService : MonoBehaviour
    {
        public Transform root;
        [Inject] private DiContainer _container;
        public event Action<MeshToDraw> OnClearLastPaintTarget;
        public event Action<MeshToDraw> OnCreationNewPaintTarget;
        
        public MeshToDraw GetCurrent => _targetingDataInformation;
        public PoolTextureController GetCurrentTextureController => _targetingDataTextureController;
        
        private SelectionMeshMenu _selectionMeshMenu;
        private GameObject _targeting = null;
        
        private MeshToDraw _targetingDataInformation = null;
        private PoolTextureController _targetingDataTextureController = null;

        [Inject] 
        public void Construct(SelectionMeshMenu menu)
        {
            _selectionMeshMenu = menu;
            _selectionMeshMenu.OnButtonClickBySelection += SelectionMeshMenuOnButtonClickBySelection;
        }
        
        private void SelectionMeshMenuOnButtonClickBySelection(SelectionMeshButton obj)
        {
            SelectionMeshCreate(obj.meshToDraw);
        }
        internal void SelectionMeshCreate(MeshToDraw obj)
        {
            if (_targeting == null || _targetingDataInformation == null)
            {
                CreationNewPaintTarget(obj);
            }
            else
            {
                ClearLastPaintTarget();
                CreationNewPaintTarget(obj);
            }
        }
        
        private void ClearLastPaintTarget()
        {
            OnClearLastPaintTarget?.Invoke(_targetingDataInformation);
            Destroy(_targeting);
            _targetingDataInformation = null;
            _targetingDataTextureController = null;
        }
        private void CreationNewPaintTarget(MeshToDraw obj)
        {
            OnCreationNewPaintTarget?.Invoke(obj);
            _targeting = _container.InstantiatePrefab(obj.prefab, root);
            _targetingDataInformation = obj;
            _targetingDataTextureController = _targeting.GetComponent<PoolTextureController>();
        }
    }
}