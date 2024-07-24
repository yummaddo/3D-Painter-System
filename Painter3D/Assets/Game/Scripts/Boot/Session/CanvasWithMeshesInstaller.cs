using Game.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Boot.Session
{
    public class CanvasWithMeshesInstaller : MonoInstaller
    {
        public GameObject instance;
        public override void InstallBindings()
        {
            Container.Bind<SelectionMeshMenu>().FromComponentOn(instance).AsSingle();
        }
    }
}