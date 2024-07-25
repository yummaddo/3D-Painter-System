using Game.Paint3D.Common;
using Game.Paint3D.Utility;
using UnityEditor;
using UnityEngine;

namespace Game.Paint3D.Core
{
	/// <summary>This component sends pointer information to any <b>CwHitScreen</b> component, allowing you to paint with a touchscreen.</summary>
	[RequireComponent(typeof(CwHitScreenBase))]
	[HelpURL(CwCommon.HelpUrlPrefix + "CwPointerTouch")]
	[AddComponentMenu(CwCommon.ComponentHitMenuPrefix + "Pointer Touch")]
	public class CwPointerTouch : CwPointer
	{
		/// <summary>If you want the paint to appear above the finger, then you can set this number to something positive.</summary>
		public float Offset { set { offset = value; } get { return offset; } } [SerializeField] private float offset;

		protected virtual void Update()
		{
			CwInputManager.Finger finger;

			for (var i = 0; i < CwInput.GetTouchCount(); i++)
			{
				int     index;
				Vector2 position;
				float   pressure;
				bool    set;

				CwInput.GetTouch(i, out index, out position, out pressure, out set);

				position.y += offset * CwInputManager.ScaleFactor;

				var down = GetFinger(index, position, pressure, set, out finger);

				cachedHitScreenBase.HandleFingerUpdate(finger, down, set == false);

				if (set == false)
				{
					TryNullFinger(index);
				}
			}
		}
	}

#if UNITY_EDITOR
	[CanEditMultipleObjects]
	[CustomEditor(typeof(CwPointerTouch))]
	public class CwPointerTouch_Editor : CwEditor
	{
		protected override void OnInspector()
		{
			CwPointerTouch tgt; CwPointerTouch[] tgts; GetTargets(out tgt, out tgts);

			Draw("offset");
		}
	}

#endif
}