#region

using UnityEngine;

#endregion

namespace Assets
{
    public class Ways : MonoBehaviour
    {
        public static Ways Ctrl;
        private LineRenderer[] _lineRenderers;

        public void Awake()
        {
            if (Ctrl == null)
                Ctrl = this;
            else if (Ctrl != this)
                Destroy(this);
        }

        public void Start()
        {
            Init();
        }

        private void Init()
        {
            _lineRenderers = new LineRenderer[Trail.Ctrl.NumberOfPoints];
            GameObject temp;
            for (var i = 0; i < _lineRenderers.Length; i++)
            {
                temp = Instantiate(Prefabs.ctrl.LineRendererGO, transform.position, Quaternion.identity) as GameObject;
                _lineRenderers[i] = temp.GetComponent<LineRenderer>();
            }

            for (var i = 0; i < _lineRenderers.Length; i++)
            {
                _lineRenderers[i].SetVertexCount(2);
                _lineRenderers[i].SetPosition(0, transform.position);
                _lineRenderers[i].SetPosition(1, Trail.Ctrl.Points[i].Position);
                _lineRenderers[i].transform.SetParent(transform);
            }
        }
    }
}