using Game.SelectionMesh;
using Game.UI.MenuBrashSelector;
using Game.UI.MenuColorSelector;
using Game.UI.MenuLoadPaint;
using Game.UI.MenuSavePaint;
using UnityEngine;
using Zenject;

namespace Game.Boot.Session
{
    public class MenuInstaller : MonoInstaller
    {
        public SelectionMeshMenu selectionMeshMenu;
        public SavePaintMenu savePaintMenu;
        public LoadPaintMenu loadPaintManu;
        public ColorSelectorMenu colorSelectorMenu;
        public BrashSelectorMenu brashSelectorMenu;
        public override void InstallBindings()
        {
            Container.Bind<SelectionMeshMenu>().FromInstance(selectionMeshMenu).AsSingle();
            Container.Bind<SavePaintMenu>().FromInstance(savePaintMenu).AsSingle();
            Container.Bind<LoadPaintMenu>().FromInstance(loadPaintManu).AsSingle();
            Container.Bind<ColorSelectorMenu>().FromInstance(colorSelectorMenu).AsSingle();
            Container.Bind<BrashSelectorMenu>().FromInstance(brashSelectorMenu).AsSingle();
        }
    }
}