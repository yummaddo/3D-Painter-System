using UnityEngine;

namespace Game.Utility
{
    [CreateAssetMenu(fileName = "MeshContainer", menuName = "MeshContainer")]
    public class MeshContainer : ScriptableObject
    {
        public string nameOfContainer = nameof(MeshContainer);
        public MeshToDrawDictionary Dictionary;
    }
}