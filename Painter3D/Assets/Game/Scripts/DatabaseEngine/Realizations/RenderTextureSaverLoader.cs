using System.IO;
using Cysharp.Threading.Tasks;
using Game.DatabaseEngine.Abstraction;
using UnityEngine;

namespace Game.DatabaseEngine.Realizations
{
    public class RenderTextureSaverLoader : ISaveLoadTexture
    {
        public RenderTextureSaverLoader() { }
        public void SaveTextureToBytes(RenderTexture renderTexture, string fileAbsolutePath)
        {
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = renderTexture;

            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = currentRT;

            byte[] bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(fileAbsolutePath, bytes);
            Debug.Log("Texture saved as bytes to " + fileAbsolutePath);
        }

        public async UniTask<Texture2D> LoadTextureFromBytesAsync(string fileAbsolutePath, int width, int height)
        {
            if (File.Exists(fileAbsolutePath))
            {
                byte[] bytes = await UniTask.Run(() => File.ReadAllBytes(fileAbsolutePath));
                Texture2D texture = new Texture2D(width, height);
                texture.LoadImage(bytes); // Automatically resizes the texture dimensions
                Debug.Log("Texture loaded from bytes at " + fileAbsolutePath);
                return texture;
            }
            else
            {
                Debug.LogError("File not found at " + fileAbsolutePath);
                return null;
            }
        }

        public async UniTask<RenderTexture> LoadRenderTextureFromBytesAsync(string fileAbsolutePath, int width, int height)
        {
            Texture2D texture2D = await LoadTextureFromBytesAsync(fileAbsolutePath, width, height);
            if (texture2D != null)
            {
                RenderTexture renderTexture = new RenderTexture(width, height, 24);
                Graphics.Blit(texture2D, renderTexture);
                Debug.Log("RenderTexture created from bytes");
                return renderTexture;
            }
            else
            {
                Debug.LogError("Failed to create RenderTexture from bytes");
                return null;
            }
        }
    }
}