using UnityEngine;
using UnityEngine.Events;

namespace Counters
{
    public class ScoreCounter : MonoBehaviour
    {

        public UnityEvent<float> OnScoreChange;

        [SerializeField]
        private float _score;

        public float Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnScoreChange?.Invoke(_score);
            }
        }

        private void Start()
        {
            Score = 0;
        }

    }
}