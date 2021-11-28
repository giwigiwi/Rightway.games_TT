using Gameplay.ShipSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        public UnityEvent<float> OnHPChanged;

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

        public override void ManageHP(float hp)
        {
            OnHPChanged?.Invoke(hp);
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
