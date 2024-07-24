using UnityEngine;

namespace Game
{
    public class DrawOnObject : MonoBehaviour
    {
        public Camera cam;
        public Texture2D drawTexture;
        public float brushSize = 0.1f;
        public Color drawColor = Color.red;
        private Renderer rend;
        private Texture2D mainTexture;
        private Vector2 uv;

        void Start()
        {
            rend = GetComponent<Renderer>();

            // Create a new Texture2D with the same dimensions as the main texture
            Texture2D originalTexture = rend.material.mainTexture as Texture2D;
            mainTexture = new Texture2D(originalTexture.width, originalTexture.height, TextureFormat.RGBA32, false);

            // Copy the pixels from the original texture to the new texture
            mainTexture.SetPixels(originalTexture.GetPixels());
            mainTexture.Apply();

            // Set the new texture as the main texture
            rend.material.mainTexture = mainTexture;
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform)
                    {
                        uv = hit.textureCoord;
                        uv.x *= mainTexture.width;
                        uv.y *= mainTexture.height;
                        Draw((int)uv.x, (int)uv.y);
                    }
                }
            }
        }

        void Draw(int x, int y)
        {
            int startX = Mathf.Clamp(x - (int)(brushSize * mainTexture.width) / 2, 0, mainTexture.width);
            int startY = Mathf.Clamp(y - (int)(brushSize * mainTexture.height) / 2, 0, mainTexture.height);
            int endX = Mathf.Clamp(x + (int)(brushSize * mainTexture.width) / 2, 0, mainTexture.width);
            int endY = Mathf.Clamp(y + (int)(brushSize * mainTexture.height) / 2, 0, mainTexture.height);

            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    mainTexture.SetPixel(i, j, drawColor);
                }
            }

            mainTexture.Apply();
        }
    }
}