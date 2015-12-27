#region

using System;
using Assets.Scripts;
using UnityEngine;

#endregion

namespace Assets
{
    [RequireComponent(typeof (LineRenderer))]
    public class Trail : MonoBehaviour
    {
        public static Trail Ctrl;
        private LineRenderer _lRenderer;
        public int NumberOfPoints = 7;
        public GridPoint[] Points;
        public float Radius = 2;
        public float RotationSpeed = 0.1f;

        public TrailSegment GetSegmentAt(int index)
        {
            if (index < NumberOfPoints && index >= 0)
                return new TrailSegment(Points[index].Position, Points[(index + 1)%NumberOfPoints].Position);
            throw new Exception("Segment out of range");
        }

        public void Awake()
        {
            if (Ctrl == null)
                Ctrl = this;
            else if (Ctrl != this)
                Destroy(this);
            Init();
        }

        private void Init()
        {
            Points = new GridPoint[NumberOfPoints];
            _lRenderer = GetComponent<LineRenderer>();
            var angle = Mathf.Deg2Rad*(360/NumberOfPoints);
            float x = 0;
            float y = 0;

            for (var i = 0; i < NumberOfPoints; i++)
            {
                x = Mathf.Sin(angle*i)*Radius;
                y = Mathf.Cos(angle*i)*Radius;
                Points[i] = new GridPoint(transform.position + new Vector3(x, y, 0), angle*i);
            }

            Refresh();
        }

        private void Refresh()
        {
            _lRenderer.SetVertexCount(NumberOfPoints + 1);
            for (var i = 0; i < NumberOfPoints; i++)
            {
                _lRenderer.SetPosition(i, Points[i].Position);
            }
            if (Points.Length > 0)
                _lRenderer.SetPosition(Points.Length, Points[0].Position);
        }

        // Use this for initialization
        public void Start()
        {
        }

        // Update is called once per frame
        public void Update()
        {
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            //ToDo: Create rotation
            //transform.Rotate(Vector3.forward * RotationSpeed);
        }

        public Vector3 GetPositionForAngle(float angle)
        {
            var s = 0;
            var e = Points.Length - 1;
            angle = (float)(angle % (2 * Math.PI));
            for (var i = 0; i < Points.Length; i++)
            {
                if (Points[i].Angle <= angle)
                    s = i;
            }

            for (var i = 0; i < Points.Length; i++)
            {
                if (!(Points[i].Angle >= angle)) continue;
                e = i;
                break;
            }

            if (s == e)
            {
                if (s == 0)
                    return Points[0].Position;
                e = 0;
            }


            var start = Points[s];
            var end = Points[e];
            float ratio = 0;
            if (s == Points.Length - 1 && e == 0)
            {
                ratio = (angle - start.Angle)/(2*Mathf.PI - start.Angle);
            }
            else
            {
                ratio = (angle - start.Angle)/(end.Angle - start.Angle);
            }
            return Vector3.Lerp(start.Position, end.Position, ratio);
        }
    }
}