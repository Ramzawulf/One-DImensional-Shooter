#region

using UnityEngine;
using UnityEngine.EventSystems;

#endregion

namespace Assets
{
    public class MovementPanel : MonoBehaviour
    {
        public static MovementPanel Ctrl;
        public float Value;

        public void Awake()
        {
            if (Ctrl == null)
                Ctrl = this;
            else if (Ctrl != this)
                Destroy(this);
        }

        public void Update()
        {
            CheckMousePosition();
        }

        private void CheckMousePosition()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                var currVal = Screen.width*0.5f - Input.mousePosition.x;
                Value = currVal/(Screen.width*0.5f);
                print("Value: " + Value);
            }
            else
            {
                Value = 0;
            }
        }
    }
}