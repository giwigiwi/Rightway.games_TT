using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ShipControllers;
using Gameplay.Spaceships;
using Gameplay.ShipControllers.CustomControllers;


namespace Gameplay.Bonuses
{
    public class FireBoost : Bonus
    {
        [SerializeField]
        private float _boostPercent = -10f;

        public override void ApplyBonus(ISpaceship spaceship)
        {
            spaceship.WeaponSystem.ChangeCooldown(_boostPercent/100);
            Destroy(gameObject);
        }

    }
}