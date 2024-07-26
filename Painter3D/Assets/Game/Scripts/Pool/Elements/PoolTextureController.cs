using PaintCore;
using PaintIn3D;
using UnityEngine;
using Zenject;

namespace Game.Pool.Elements
{
    public class PoolTextureController : MonoBehaviour
    {
        [Inject] private PoolTargetElementService _serviceCreation;
        [Inject] private PoolTextureSelectionService _serviceSelectionTexture;
        [SerializeField] internal CwPaintableMeshTexture meshTexture;
        [SerializeField] internal CwPaintableMesh mesh;
        [SerializeField] internal CwMaterialCloner materialCloner;

        public void OnTextureActivation()
        {
            
        }
    }
}