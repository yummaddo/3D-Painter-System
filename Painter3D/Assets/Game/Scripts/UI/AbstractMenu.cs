using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public abstract class AbstractMenu : MonoBehaviour
    {
        public abstract Button ExitButton { get; set; }
        protected abstract void Exit();
    }
}