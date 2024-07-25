﻿using Game.Paint3D.Utility;
using UnityEditor;
using UnityEngine;

namespace Game.Paint3D.Core
{
	/// <summary>This component allows you to manually associate a <b>Texture</b> with a hash code so it can be de/serialized.</summary>
	[DefaultExecutionOrder(-200)]
	[HelpURL(CwCommon.HelpUrlPrefix + "CwTextureHash")]
	[AddComponentMenu(CwCommon.ComponentMenuPrefix + "Texture Hash")]
	public class CwTextureHash : MonoBehaviour
	{
		/// <summary>The texture that will be hashed.</summary>
		public Texture Texture { set { texture = value; } get { return texture; } } [SerializeField] private Texture texture;

		/// <summary>The hash code for the texture.</summary>
		public CwHash Hash { set { hash = value; CwSerialization.TryRegister(texture, hash); } get { return hash; } } [SerializeField] private CwHash hash;

		protected virtual void OnEnable()
		{
			CwSerialization.TryRegister(texture, hash);
		}

		protected virtual void OnDestroy()
		{
			CwSerialization.TryRegister(texture, default(CwHash));
		}
	}

#if UNITY_EDITOR
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CwTextureHash))]
	public class CwTextureHash_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			CwTextureHash tgt; CwTextureHash[] tgts; GetTargets(out tgt, out tgts);

			Draw("texture", "The texture that will be hashed.");
			Draw("hash", "The hash code for the texture.");
		}
	}

#endif
}