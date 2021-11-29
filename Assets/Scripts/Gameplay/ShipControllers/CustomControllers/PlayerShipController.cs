using Gameplay.ShipSystems;
using UnityEngine;
using UnityEngine.Events;
using Gameplay.Bonuses;
using Gameplay.Spaceships;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {

        public UnityEvent<float> OnHPChanged;
        public UnityEvent OnPlayerDead;


        public override void ManageHP(float hp)
        {
            OnHPChanged?.Invoke(hp);
            if (hp <= 0)
            {
                OnPlayerDead?.Invoke();
            }
        }



        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }

        /// <summary>
        /// Check collision. If collide with bonus - applied it;
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            Bonus bonus;
            if (other.gameObject.TryGetComponent<Bonus>(out bonus))
            {
                bonus.ApplyBonus(GetComponent<ISpaceship>());
            }
        }

    }
}
