using System;
using System.Globalization;
using Game.UI.MenuBrashSelector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Pool
{
    public class ColorSelectorBrashSelection : MonoBehaviour
    {
        [Inject] private BrashSelectorMenu _menu;
        public Slider slider;
        public BrashSettingType type;
        public TextMeshProUGUI textMeshProUGUIValue;
        public void OnValueChange()
        {
            textMeshProUGUIValue.text = slider.value.ToString("F2");
            _menu.ChangeValue(type, slider.value);
        }
        private void OnEnable()
        {
            SetAll(_menu.GetValue(type));
        }
        private void SetAll(float value)
        {
            slider.value = value;
            textMeshProUGUIValue.text = slider.value.ToString("F2");
        }
    }
}