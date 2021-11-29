using UnityEngine;
using Gameplay.Spaceships;
using Gameplay.ShipSystems;


namespace Gameplay.Bonuses
{
    public abstract class Bonus : MovementSystem
    {
        [SerializeField]
        private MovementSystem movementSystem;

        private void Update()
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        /// <summary>
        /// Apply bonus effect to player
        /// </summary>
        /// <param name="spaceship"></param>
        public abstract void ApplyBonus(ISpaceship spaceship);

    }
}