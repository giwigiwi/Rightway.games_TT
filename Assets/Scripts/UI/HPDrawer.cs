using UnityEngine;
using UnityEngine.UI;

namespace UI.Drawer
{
    public class HPDrawer : MonoBehaviour
    {

        [SerializeField]
        private Image _progressBar;
        private float _defaultValue;
        private bool _init = false;

        public void DrawHP(float hp)
        {
            if(!_init)
            {
                _init = true;
                _defaultValue = hp;
            }
            _progressBar.fillAmount = hp / _defaultValue;
        }

    }
}