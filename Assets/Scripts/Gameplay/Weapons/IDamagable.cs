

namespace Gameplay.Weapons
{
    public interface IDamagable
    {

        UnitBattleIdentity BattleIdentity { get; }
        float HealthPower { get; set; }

        void ApplyDamage(IDamageDealer damageDealer);

    }


    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


