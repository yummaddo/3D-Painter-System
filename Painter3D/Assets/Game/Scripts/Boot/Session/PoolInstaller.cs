using Game.Pool;
using UnityEngine;
using Zenject;

namespace Game.Boot.Session
{
    public class PoolInstaller : MonoInstaller
    {
        public PoolTargetElementService poolTargetElementService;
        public PoolTextureSelectionService poolTextureSelectionService;
        public override void InstallBindings()
        {
            Container.Bind<PoolTargetElementService>().FromInstance(poolTargetElementService).AsSingle();
            Container.Bind<PoolTextureSelectionService>().FromInstance(poolTextureSelectionService).AsSingle();
        }
    }
}