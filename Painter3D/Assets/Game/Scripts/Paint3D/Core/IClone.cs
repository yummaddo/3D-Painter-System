using UnityEngine;

namespace Game.Paint3D.Core
{
	/// <summary>This interface allows you to define classes that can clone paint points (e.g. mirror).</summary>
	public interface IClone
	{
		void Transform(ref Matrix4x4 posMatrix, ref Matrix4x4 rotMatrix, ref Matrix4x4 rotMatrix2);
	}
}