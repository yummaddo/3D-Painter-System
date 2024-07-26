using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.DatabaseEngine.Abstraction
{
    public interface ISaveLoadTexture
    {
        public void SaveTextureToBytes(RenderTexture renderTexture, string fileAbsolutePath);
        public UniTask<Texture2D> LoadTextureFromBytesAsync(string fileAbsolutePath, int width, int height);
        public UniTask<RenderTexture> LoadRenderTextureFromBytesAsync(string fileAbsolutePath, int width, int height);
    }
}