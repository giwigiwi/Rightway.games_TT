using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Counters;
using Gameplay.Bonuses;
using Random = UnityEngine.Random;
using UnityEngine;



namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemyShipController : ShipController, IScorable
    {
        [SerializeField]
        private float _scoreByDestroy;

        [SerializeField]
        private Vector2 _fireDelay;

        [SerializeField]
        private List<Bonus> bonuses;

        private bool _fire = true;
        private ScoreCounter _scoreCounter;

        public float ScoreForDestroy => _scoreByDestroy;
        public ScoreCounter ScoreCounter
        {
            get
            {
                return _scoreCounter;
            }
            set
            {
                _scoreCounter = value;
            }
        }

        public void AddScore(float score)
        {
            ScoreCounter.Score += score;
        }

        public override void ManageHP(float hp)
        {
            if (hp <= 0)
            {
                AddScore(ScoreForDestroy);
                SpawnBonus(bonuses[Random.Range(0, bonuses.Count)]);
                Destroy(gameObject);
            }
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (!_fire)
                return;

            fireSystem.TriggerFire();
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
        }

        private IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }

        /// <summary>
        /// Spawn a bonus;
        /// </summary>
        /// <param name="bonus">bonus for spawn</param>
        private void SpawnBonus(Bonus bonus)
        {
            Instantiate(bonus, transform.position, transform.rotation);
        }

    }
}