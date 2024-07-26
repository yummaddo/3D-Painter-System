using System;
using HSVPicker;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MenuColorSelector
{
    public class ColorSelectorMenu : AbstractMenu
    {
        public ColorPicker colorPicker;
        public event Action<Color> OnNewColorSelect;
        public void ColorChange(Color newColor)
        {
            OnNewColorSelect?.Invoke(newColor);
        }
        [field:SerializeField]public override Button ExitButton { get; set; }
        protected override void Exit()
        {
            ExitButton.onClick.Invoke();
        }
    }
}