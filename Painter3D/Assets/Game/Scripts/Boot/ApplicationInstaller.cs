using Game.DatabaseEngine;
using UnityEngine;
using Zenject;

namespace Game.Boot
{
    public class ApplicationInstaller: MonoInstaller
    {
        public GameObject instanceApplicationGame;
        public GameObject instanceDataBase;
        
        public override void InstallBindings()
        {
            Container.Bind<ApplicationGame>().FromComponentOn(instanceApplicationGame).AsSingle();
            Container.Bind<DataBase>().FromComponentOn(instanceDataBase).AsSingle();
        } 
    }
}