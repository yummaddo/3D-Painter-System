using Game.Paint3D.Core;
using Game.Paint3D.Utility;
using UnityEditor;
using UnityEngine;

namespace Game.Paint3D.Painting
{
	/// <summary>This component automatically destroys the specified GameObject when sent a hit point. Hit points will automatically be sent by any <b>CwHit___</b> component on this GameObject, or its ancestors.</summary>
	[HelpURL(CwCommon.HelpUrlPrefix + "CwDestroyer")]
	[AddComponentMenu(CwCommon.ComponentHitMenuPrefix + "Destroyer")]
	public class CwDestroyer : MonoBehaviour, IHitPoint, IHitLine, IHitQuad
	{
		/// <summary>This GameObject will be destroyed.</summary>
		public GameObject Target { set { target = value; } get { return target; } } [SerializeField] private GameObject target;

		[ContextMenu("Destroy Now")]
		public void DestroyNow()
		{
			Destroy(gameObject);
		}

		public void HandleHitPoint(bool preview, int priority, float pressure, int seed, Vector3 position, Quaternion rotation)
		{
			DestroyNow();
		}

		public void HandleHitLine(bool preview, int priority, float pressure, int seed, Vector3 positionA, Vector3 positionB, Quaternion rotation, bool clip)
		{
			DestroyNow();
		}

		public void HandleHitQuad(bool preview, int priority, float pressure, int seed, Vector3 positionA, Vector3 positionB, Vector3 positionC, Vector3 positionD, Quaternion rotation, bool clip)
		{
			DestroyNow();
		}

#if UNITY_EDITOR
		protected virtual void Reset()
		{
			target = gameObject;
		}
#endif
	}

#if UNITY_EDITOR
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CwDestroyer))]
	public class CwDestroyer_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			CwDestroyer tgt; CwDestroyer[] tgts; GetTargets(out tgt, out tgts);

			BeginError(Any(tgts, t => t.Target == null));
			Draw("target", "This GameObject will be destroyed.");
			EndError();
		}
	}

#endif
}