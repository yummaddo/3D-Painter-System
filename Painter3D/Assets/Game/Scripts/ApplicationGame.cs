using Game.Utility;
using UnityEngine;

namespace Game
{
    public class ApplicationGame : MonoBehaviour
    {
        public MeshContainer container;
        private static ApplicationGame _instance;
        internal static ApplicationGame Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = new GameObject().AddComponent<ApplicationGame>();
                    _instance.name = _instance.GetType().ToString();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
        }
    }
}