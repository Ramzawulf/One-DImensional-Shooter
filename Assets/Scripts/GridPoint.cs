#region

using UnityEngine;

#endregion

namespace Assets
{
    public class GridPoint
    {
        public float Angle;
        public Vector3 Position;

        public GridPoint(Vector3 pos, float angle)
        {
            Position = pos;
            Angle = angle;
        }
    }
}