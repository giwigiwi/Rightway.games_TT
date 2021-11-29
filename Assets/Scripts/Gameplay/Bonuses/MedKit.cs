using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;
using Gameplay.ShipControllers.CustomControllers;

namespace Gameplay.Bonuses
{
    public class MedKit : Bonus
    {

        [SerializeField]
        private float _healAmount = 100f;

        public override void ApplyBonus(ISpaceship spaceship)
        {
            spaceship.HealthPower += _healAmount;
            Destroy(gameObject);
        }

    }
}