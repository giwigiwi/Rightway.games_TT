using UnityEngine;
using UnityEngine.UI;


namespace UI.Drawer
{
    public class ScoreDrawer : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText;

        /// <summary>
        /// Drawn a cooldown between shot amount on UI
        /// </summary>
        /// <param name="cooldown"></param>
        public void DrawScore(float score)
        {
            _scoreText.text = score.ToString();
        }

    }
}