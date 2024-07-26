using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "MeshContainer", menuName = "MeshContainer")]
    public class MeshContainer : ScriptableObject
    {
        public string nameOfContainer = nameof(MeshContainer);
        public MeshToDrawDictionary Dictionary;
    }
}