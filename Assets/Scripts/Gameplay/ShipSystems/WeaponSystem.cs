using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;

        public UnityEvent<float> OnCooldownChange;



        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
            OnCooldownChange?.Invoke(GetAverageCooldown(_weapons));
        }


        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        /// <summary>
        /// Change cooldown by adding changingPercent param for every weapon. Invoke event OnCooldownChange(float)
        /// </summary>
        /// <param name="changingPercent">changing value in percents</param>
        public void ChangeCooldown(float changingPercent)
        {
            _weapons.ForEach(w => w.Cooldown += w.Cooldown * changingPercent);
            OnCooldownChange?.Invoke(GetAverageCooldown(_weapons));
        }

        /// <summary>
        /// Calculate average cooldown for weapons
        /// </summary>
        /// <param name="weapons"> collection of weapons for which will calculating average cooldownn</param>
        /// <returns>average in float</returns>
        private float GetAverageCooldown(List<Weapon> weapons)
        {
            float averageCooldown = 0;
            _weapons.ForEach(w => averageCooldown += w.Cooldown);
            averageCooldown /= _weapons.Count;
            return averageCooldown;
        }

    }
}
