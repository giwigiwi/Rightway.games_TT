using UnityEngine;
using UnityEngine.UI;


namespace UI.Drawer
{
    public class CooldownDrawer : MonoBehaviour
    {
        [SerializeField]
        private Text _cooldownText;

        /// <summary>
        /// Drawn a cooldown between shot amount on UI
        /// </summary>
        /// <param name="cooldown"></param>
        public void DrawAverageCooldown(float cooldown)
        {
            _cooldownText.text = cooldown.ToString("0.000");
        }


    }
}