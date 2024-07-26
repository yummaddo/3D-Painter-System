using System;
using Game.DatabaseEngine;
using Game.DatabaseEngine.SaveData;
using Game.Pool;
using Game.UI.MenuColorSelector;
using PaintIn3D;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.MenuBrashSelector
{
    public class BrashSelectorMenu : AbstractMenu
    {
        public event Action<float> OnOpacityBrashChange;
        public event Action<float> OnHardnessBrashChange;
        public event Action<float> OnSizeBrashChange;
        public event Action<Color> OnColorBrashChange;
        private BrashSettingData _temp;
        private DataBase _dataBase;
        
        [Inject]
        private void Construct(ColorSelectorMenu colorSelectorMenu)
        {
            colorSelectorMenu.OnNewColorSelect += ChangeColor;
            _temp = new BrashSettingData();
        }

        [Inject]
        private void Construct(DataBase dataBase)
        {
            _dataBase = dataBase;
            _dataBase.tableSave.OnRepositoryInit += InjectDataSetting;
        }

        private void InjectDataSetting()
        {
            _temp = _dataBase.tableSave.GetBrashSettingSaves();
            sphereBrash.Radius = _temp.dataBrash.size;
            sphereBrash.Hardness = _temp.dataBrash.hardness;
            sphereBrash.Opacity = _temp.dataBrash.opacity;
            sphereBrash.Color = _temp.dataBrash.color;
        }

        [field: SerializeField] public override Button ExitButton { get; set; }

        protected override void Exit()
        {
            ExitButton.onClick.Invoke();
        }

        public CwPaintSphere sphereBrash;

        public void ChangeValue(BrashSettingType type, float value)
        {
            switch (type)
            {
                case BrashSettingType.Hardness:
                    ChangeHardness(value);
                    break;
                case BrashSettingType.Opacity:
                    ChangeOpacity(value);
                    break;
                case BrashSettingType.Size:
                    ChangeSize(value);
                    break;
            }

            _dataBase.tableSave.Save(_temp);
        }

        public float GetValue(BrashSettingType type)
        {
            switch (type)
            {
                case BrashSettingType.Hardness:
                    return _temp.dataBrash.hardness;
                case BrashSettingType.Opacity:
                    return _temp.dataBrash.opacity;
                case BrashSettingType.Size:
                    return _temp.dataBrash.size;
            }
            return 0;
        }

        private void ChangeColor(Color value)
        {
            Debug.Log(value);
            sphereBrash.Color = value;
            _temp.dataBrash.color = value;
            OnColorBrashChange?.Invoke(value);
            _dataBase.tableSave.Save(_temp);
        }

        private void ChangeOpacity(float value)
        {
            Debug.Log(value);
            sphereBrash.Opacity = value;
            _temp.dataBrash.opacity = value;
            OnOpacityBrashChange?.Invoke(value);
            _dataBase.tableSave.Save(_temp);
        }

        private void ChangeHardness(float value)
        {
            Debug.Log(value);
            sphereBrash.Hardness = value;
            _temp.dataBrash.hardness = value;
            OnHardnessBrashChange?.Invoke(value);
            _dataBase.tableSave.Save(_temp);
        }

        private void ChangeSize(float value)
        {
            Debug.Log(value);
            sphereBrash.Radius = value;
            _temp.dataBrash.size = value;
            OnSizeBrashChange?.Invoke(value);
            _dataBase.tableSave.Save(_temp);
        }
    }
}