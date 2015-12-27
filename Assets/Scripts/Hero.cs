#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Assets.Scripts
{
    public class Hero : MonoBehaviour
    {
        public static Hero Ctrl;
        public float CurrentAngle;
        public Scrollbar MovementBar;
        public float Score;
        public float Speed = 0.5f;

        public void Awake()
        {
            if (Ctrl == null)
                Ctrl = this;
            else if (Ctrl != this)
                Destroy(this);
        }

        public void Start()
        {
            RefreshPosition();
        }

        // Update is called once per frame
        public void LateUpdate()
        {
            RefreshPosition();
        }

        private void RefreshPosition()
        {
            CurrentAngle += MovementPanel.Ctrl.Value*Speed;
            if (CurrentAngle <= 0)
            {
                CurrentAngle = 360 - CurrentAngle;
            }
            var position = Trail.Ctrl.GetPositionForAngle(CurrentAngle);
            transform.position = position;
        }

        public void Damage()
        {
            Ctrl.Score -= 2;
        }

        public void ChangeScore(float value)
        {
            Score += value;
        }
    }
}