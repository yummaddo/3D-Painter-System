using System;
using Game.DatabaseEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.MenuSavePaint
{
    public class SavePaintMenu : AbstractMenu
    {
        public TMP_InputField field;
        public event Action<string> OnTryCreateNewSaveByName;
        public void CreateSave()
        {
            Debugger.Logger("OnTryCreateNewSaveByName", Process.Action);
            OnTryCreateNewSaveByName?.Invoke(field.text);   
            Exit();
        }   
        [field:SerializeField]public override Button ExitButton { get; set; }
        protected override void Exit()
        {
            ExitButton.onClick.Invoke();
        }
    }
}