#region

using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        private Hero _hero;
        private float _lastSpawn;
        public Text PlayerScore;
        public float SpawnSpeed = 0.3f;
        public SpawningSequence SpawningSequence;

        public void Start()
        {
            _hero = Hero.Ctrl;
        }

        public void Update()
        {
            if (Time.time > (_lastSpawn + SpawnSpeed))
            {
                var segment = Trail.Ctrl.GetSegmentAt(Random.Range(0, Trail.Ctrl.NumberOfPoints));
                BaseRay.Instantiate(Random.value < 0.3f ? RayType.Friendly : RayType.Evil, Ways.Ctrl.transform.position,
                    segment.Start, segment.End);
                _lastSpawn = Time.time;
            }

            UpdatePlayerScore();
        }

        private void UpdatePlayerScore()
        {
            PlayerScore.text = "Score: " + _hero.Score;
        }
    }
}