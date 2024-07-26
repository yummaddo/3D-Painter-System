using System;
using Game.Boot;
using Game.DatabaseEngine;
using Game.DatabaseEngine.SaveData;
using Game.Pool;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.MenuLoadPaint
{
    public class LoadPaintSaveElement : MonoBehaviour
    {
        private SaveDataElement _elementLink;
        public Text text;
        [Inject] private PoolTextureSelectionService _poolTextureSelectionService;
        public void Initialization(SaveDataElement dataElement)
        {
            _elementLink = dataElement;
            text.text = $"{dataElement.selectionMeshToDraw}:{dataElement.name}";
        }
        public void LoadNewMeshModel()
        {
            _poolTextureSelectionService.CratePaintMenuCreateNewSaveByData(_elementLink);
        }


    }
}