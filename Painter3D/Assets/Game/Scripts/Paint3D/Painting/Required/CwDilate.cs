using Game.Paint3D.Utility;
using UnityEngine;

namespace Game.Paint3D.Painting.Required
{
	/// <summary>This class allows you to easily dilate the specified mesh texture.</summary>
	public static class CwDilate
	{
		private static int _CwCoord   = Shader.PropertyToID("_CwCoord");
		private static int _CwTexure  = Shader.PropertyToID("_CwTexure");
		private static int _CwLookup  = Shader.PropertyToID("_CwLookup");
		private static int _CwSteps   = Shader.PropertyToID("_CwSteps");
		private static int _CwOffsets = Shader.PropertyToID("_CwOffsets");
		private static int _CwSize    = Shader.PropertyToID("_CwSize");

		private static Material dilateMaterial;

		private static Vector4[] positive = new Vector4[9];

		public static void Dilate(RenderTexture texture, Mesh mesh, int channel)
		{
			if (dilateMaterial == null)
			{
				dilateMaterial = CwHelper.CreateTempMaterial("Dilate", "Hidden/PaintInEditor/CwDilate");
			}
			
			positive[0] = new Vector4( 0.0f,  0.0f,  0.0f,  0.0f);
			positive[1] = new Vector4( 0.0f,  1.0f,  0.0f,  1.0f);
			positive[2] = new Vector4( 1.0f,  1.0f,  1.0f,  1.0f);
			positive[3] = new Vector4( 1.0f,  0.0f,  1.0f,  0.0f);
			positive[4] = new Vector4( 1.0f, -1.0f,  1.0f, -1.0f);
			positive[5] = new Vector4( 0.0f, -1.0f,  0.0f, -1.0f);
			positive[6] = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);
			positive[7] = new Vector4(-1.0f,  0.0f, -1.0f,  0.0f);
			positive[8] = new Vector4(-1.0f, -1.0f, -1.0f, -1.0f);

			var u = CwHelper.Reciprocal(texture.width );
			var v = CwHelper.Reciprocal(texture.height);

			for (var i = 1; i < 9; i++)
			{
				var o = positive[i];

				o.x *= u;
				o.y *= v;

				positive[i] = o;
			}

			var oldActive = RenderTexture.active;
			var mask      = Game.Paint3D.Core.CwCommon.GetRenderTexture(new RenderTextureDescriptor(texture.width, texture.height, RenderTextureFormat.R8));
			var deltas    = Game.Paint3D.Core.CwCommon.GetRenderTexture(new RenderTextureDescriptor(texture.width, texture.height, RenderTextureFormat.RG16));
			var swap      = Game.Paint3D.Core.CwCommon.GetRenderTexture(texture);

			mask.filterMode = FilterMode.Point;
			deltas.filterMode = FilterMode.Point;

			// Pass 0
			RenderTexture.active = mask;

			dilateMaterial.SetVector(_CwCoord, Game.Paint3D.Core.CwCommon.IndexToVector(channel));

			if (dilateMaterial.SetPass(0) == true)
			{
				Graphics.DrawMeshNow(mesh, Matrix4x4.identity);
			}

			// Pass 1
			dilateMaterial.SetTexture(_CwTexure, mask);
			dilateMaterial.SetInt(_CwSteps, 64);
			dilateMaterial.SetVector(_CwSize, new Vector2(mask.width, mask.height));
			dilateMaterial.SetVectorArray(_CwOffsets, positive);

			Graphics.Blit(null, deltas, dilateMaterial, 1);

			// Pass 2
			dilateMaterial.SetTexture(_CwTexure, texture);
			dilateMaterial.SetTexture(_CwLookup, deltas);

			Graphics.Blit(null, swap, dilateMaterial, 2);

			// Swap
			Graphics.Blit(swap, texture);
			
			Game.Paint3D.Core.CwCommon.ReleaseRenderTexture(mask);
			Game.Paint3D.Core.CwCommon.ReleaseRenderTexture(deltas);
			Game.Paint3D.Core.CwCommon.ReleaseRenderTexture(swap);

			RenderTexture.active = oldActive;
		}
	}
}