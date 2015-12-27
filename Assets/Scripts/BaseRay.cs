#region

using System;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class BaseRay : MonoBehaviour
    {
        protected Vector3 _currentA;
        protected Vector3 _currentB;
        protected Vector3 _endA;
        protected Vector3 _endB;
        protected float _lastMove;
        protected LineRenderer LRenderer;
        public LayerMask Mask;
        public float Speed = 0.5f;
        public float Tolerance = 1f;

        private void Init()
        {
            LRenderer = GetComponent<LineRenderer>();
            LRenderer.SetVertexCount(2);
            LRenderer.SetPosition(0, _currentA);
            LRenderer.SetPosition(1, _currentB);
        }

        public void Update()
        {
            CheckForGoal();
            CheckForHit();
            Move();
        }

        private void CheckForHit()
        {
            var hit = Physics2D.Raycast(_currentA, (_currentB - _currentA).normalized,
                Vector3.Distance(_currentA, _currentB),
                Mask);

            if (hit.collider != null)
                HeroHit();
        }

        protected virtual void HeroHit()
        {
          
        }

        private void CheckForGoal()
        {
            if (Vector3.Distance(_currentA, _endA) < 0.2f)
                Die();
        }

        private void Move()
        {
            _currentA = Vector3.MoveTowards(_currentA, _endA, Speed);
            _currentB = Vector3.MoveTowards(_currentB, _endB, Speed);
            LRenderer.SetPosition(0, _currentA);
            LRenderer.SetPosition(1, _currentB);
        }

        public static BaseRay Instantiate(RayType type, Vector3 position, Vector3 startPointA, Vector3 startPointB,
            Vector3 endPointA, Vector3 endPointB)
        {
            GameObject go;
            BaseRay ray = null;
            switch (type)
            {
                case RayType.Evil:
                    go = Instantiate(Prefabs.ctrl.EvilRay, position, Quaternion.identity) as GameObject;
                    ray = go.GetComponent<EvilRay>();
                    break;
                case RayType.Friendly:
                    go = Instantiate(Prefabs.ctrl.FriendlyRay, position, Quaternion.identity) as GameObject;
                    ray = go.GetComponent<EvilRay>();
                    break;
            }

            ray.SetPoints(startPointA, endPointA, startPointB, endPointB);

            if (ray == null)
                throw new Exception("Invalid RayType");
            return ray;
        }

        public void SetPoints(Vector3 sA, Vector3 eA, Vector3 sB, Vector3 eB)
        {
            _currentA = sA;
            _endA = eA;
            _currentB = sB;
            _endB = eB;
            Init();
        }

        public static BaseRay Instantiate(RayType type, Vector3 position, Vector3 start, Vector3 end)
        {
            return Instantiate(type, position, position, position, start, end);
        }

        protected void Die()
        {
            Destroy(gameObject);
        }
    }
}