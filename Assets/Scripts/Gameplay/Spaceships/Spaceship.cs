using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {

        [SerializeField]
        private ShipController _shipController;

        [SerializeField]
        private MovementSystem _movementSystem;

        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private float _healthPower = 100;

        public UnityAction<float> OnHPChanged;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        /// <summary>
        /// Ship's health power amount. When changing invoke OnHPChanged(float) event;
        /// </summary>
        public float HealthPower
        {
            get
            {
                return _healthPower;
            }
            set
            {
                _healthPower = value;
                OnHPChanged?.Invoke(_healthPower);
            }
        }

        private void Start()
        {
            _shipController.Init(this);
            OnHPChanged += _shipController.ManageHP;
            OnHPChanged?.Invoke(HealthPower);
            _weaponSystem.Init(_battleIdentity);
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            HealthPower -= damageDealer.Damage;
        }

    }
}
