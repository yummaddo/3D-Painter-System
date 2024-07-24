using Game.Pool;
using UnityEngine;
using Zenject;

namespace Game.Boot.Session
{
    public class PoolInstaller : MonoInstaller
    {
        public GameObject instance;
        public override void InstallBindings()
        {
            Container.Bind<PoolTargetElementService>().FromComponentOn(instance).AsSingle();
        }
    }
}