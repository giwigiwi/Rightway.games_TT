using Counters;

namespace Gameplay.Spaceships
{
    public interface IScorable
    {

        ScoreCounter ScoreCounter { get; set; }
        float ScoreForDestroy { get; }

        void AddScore(float score);

    }
}