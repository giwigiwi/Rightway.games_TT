using UnityEngine;
using UnityEngine.UI;


namespace UI.Drawer
{
    public class ScoreDrawer : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText;

        public void DrawScore(float score)
        {
            _scoreText.text = score.ToString();
        }

    }
}