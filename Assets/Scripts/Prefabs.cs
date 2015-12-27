#region

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets
{
    public class Prefabs : MonoBehaviour
    {
        public static Prefabs ctrl;
        public GameObject LineRendererGO;
        public GameObject EvilRay;
        public GameObject FriendlyRay;

        public void Awake()
        {
            if (ctrl == null)
                ctrl = this;
            else if(ctrl != this)
                Destroy(this);
        }
    }
}