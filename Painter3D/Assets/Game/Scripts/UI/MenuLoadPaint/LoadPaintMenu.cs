using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.DatabaseEngine;
using Game.DatabaseEngine.SaveData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.MenuLoadPaint
{
    public class LoadPaintMenu : AbstractMenu
    {
        public GameObject instanceOfSave;
        public Transform root;
        
        [Inject] private DiContainer _container;
        [Inject] private DataBase _dataBase;
        
        private HashSet<GameObject> _saves = new HashSet<GameObject>();
        
        private bool _init;
        [field:SerializeField]public override Button ExitButton { get; set; }
        protected override void Exit()
        {
            ExitButton.onClick.Invoke();
        }
        
        private async void OnEnable()
        {
            _saves = new HashSet<GameObject>();
            if (!_init) await CreateSaveElements();
        }
        private async UniTask CreateSaveElements()
        {
            await UniTask.Yield();
            foreach (var saveDataElement in _dataBase.SaveProvider.SaveGet().tableData)
            {
                await CreateSaveElement(saveDataElement);
                await UniTask.Yield(destroyCancellationToken);
            }
            _init = true;
        }
        private UniTask CreateSaveElement(SaveDataElement saveDataElement)
        {
            var objectSave =  _container.InstantiatePrefab(instanceOfSave, root);
            objectSave.GetComponent<LoadPaintSaveElement>().Initialization(saveDataElement);
            _saves.Add(objectSave);
            return UniTask.CompletedTask;
        }
    }
}