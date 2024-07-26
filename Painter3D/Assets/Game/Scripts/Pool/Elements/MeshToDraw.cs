using UnityEngine;

namespace Game.Pool.Elements
{
    [CreateAssetMenu(fileName = "MeshToDrawSettings", menuName = "MeshToDraw")]
    public class MeshToDraw : ScriptableObject
    {
        public GameObject prefab;
        public Sprite uISelector;
        public string title = "mesh";
    }
}