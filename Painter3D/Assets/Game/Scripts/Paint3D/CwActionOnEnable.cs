using Game.Paint3D.Core;
using Game.Paint3D.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Paint3D
{
	/// <summary>This component invokes the <b>Action</b> event when this component is enabled.</summary>
	[HelpURL(CwCommon.HelpUrlPrefix + "CwActionOnEnable")]
	[AddComponentMenu(CwCommon.ComponentMenuPrefix + "Action OnEnable")]
	public class CwActionOnEnable : MonoBehaviour
	{
		/// <summary>The event that will be invoked.</summary>
		public UnityEvent Action { get { if (action == null) action = new UnityEvent(); return action; } } [SerializeField] public UnityEvent action;

		protected virtual void OnEnable()
		{
			if (action != null)
			{
				action.Invoke();
			}
		}
	}

#if UNITY_EDITOR
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CwActionOnEnable))]
	public class CwActionOnEnable_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			CwActionOnEnable tgt; CwActionOnEnable[] tgts; GetTargets(out tgt, out tgts);

			Draw("action");
		}
	}

#endif
}