using UnityEngine;

namespace Game.SelectionMesh
{
    [CreateAssetMenu(fileName = "MeshToDrawSettings", menuName = "MeshToDraw")]
    public class MeshToDraw : ScriptableObject
    {
        public GameObject prefab;
        public Sprite uISelector;
        public string title = "mesh";
    }
}