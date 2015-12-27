#region

using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class TrailSegment
    {
        public Vector3 End;
        public Vector3 Start;

        public TrailSegment(Vector3 s, Vector3 e)
        {
            Start = s;
            End = e;
        }
    }
}