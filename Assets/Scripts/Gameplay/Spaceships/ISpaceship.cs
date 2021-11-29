
using Gameplay.ShipSystems;

namespace Gameplay.Spaceships
{
    public interface ISpaceship
    {

        MovementSystem MovementSystem { get; }
        WeaponSystem WeaponSystem { get; }

        /// <summary>
        /// Ship's health power amount;
        /// </summary>
        float HealthPower { get; set; }

    }
}
