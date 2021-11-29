using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipControllers
{
    public abstract class ShipController : MonoBehaviour
    {

        private ISpaceship _spaceship;


        public void Init(ISpaceship spaceship)
        {
            _spaceship = spaceship;
        }

        private void Update()
        {
            ProcessHandling(_spaceship.MovementSystem);
            ProcessFire(_spaceship.WeaponSystem);
        }

        /// <summary>
        /// Health changing listener;
        /// </summary>
        /// <param name="hp"></param>
        public abstract void ManageHP(float hp);
        protected abstract void ProcessHandling(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);

    }
}
