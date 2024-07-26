using Game.Boot;
using Game.DatabaseEngine;
using Game.DatabaseEngine.SaveData;
using Game.UI.MenuLoadPaint;
using Game.UI.MenuSavePaint;
using Game.Utility;
using PaintCore;
using UnityEngine;
using Zenject;

namespace Game.Pool
{
    public class PoolTextureSelectionService : MonoBehaviour
    {
        [Inject]
        private void Construct(SavePaintMenu savePaintMenu)
        {
            savePaintMenu.OnTryCreateNewSaveByName += SavePaintMenuCreateNewSaveByName;
        }
        [Inject] private DataBase _dataBase;
        [Inject] private PoolTargetElementService _poolTarget;
        [Inject] private LoadPaintMenu _menu;
        [Inject] private PoolTargetElementService _poolTargetElementService;
        [Inject]
        public void Construct(ApplicationGame applicationGame)
        {
            _container = applicationGame.container;
        }
        private MeshContainer _container;
        
        internal async void CratePaintMenuCreateNewSaveByData(SaveDataElement save)
        {
            var mesh = _container.Dictionary[save.selectionMeshToDraw];
            var rect =  await _dataBase.LoadSaveTexture.LoadRenderTextureFromBytesAsync(save.path, save.width, save.height);
            _poolTargetElementService.SelectionMeshCreate(mesh);
            var currentTextureController = _poolTarget.GetCurrentTextureController;
            currentTextureController.meshTexture.Current = rect;
        }

        private void SavePaintMenuCreateNewSaveByName(string saveName)
        {
            var currentMesh = _poolTarget.GetCurrent;
            var currentTextureController = _poolTarget.GetCurrentTextureController;
            
            if (currentMesh == null || currentTextureController == null)
            {
                Debugger.Logger($"Cant save mesh texture currentTextureController={currentMesh} and currentMesh=={currentTextureController}", Process.TrashHold);
                return;
            }
            
            var textureToSave = currentTextureController.meshTexture.Current;
            Debug.Log(textureToSave);
            var height = textureToSave.height;
            var width = textureToSave.width;
            var meshName = currentMesh.title;
            
            Debugger.Logger($"Try to create new Save={saveName} mesh={meshName} textureToSave[h={height},w={width}]", Process.Create);
            
            var save = new SaveDataElement(saveName, meshName,DataBase.DataPath(saveName+".bytes"), width, height);
            _dataBase.SaveProvider.SaveLoad(save);
            Debugger.Logger($"Table Save => SaveResourceData", Process.Info);
            
            _dataBase.LoadSaveTexture.SaveTextureToBytes(textureToSave,save.path);
            Debugger.Logger($"Texture Save => SaveTextureToBytes", Process.Info);
        }
    }
}