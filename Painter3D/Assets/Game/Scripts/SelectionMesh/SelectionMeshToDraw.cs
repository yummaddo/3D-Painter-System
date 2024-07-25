using UnityEngine;

namespace Game.SelectionMesh
{
    [CreateAssetMenu(fileName = "MeshToDrawSettings", menuName = "MeshToDraw")]
    public class SelectionMeshToDraw : ScriptableObject
    {
        public GameObject prefab;
        public Sprite uISelector;
        public string title = "mesh";
        
    }
}