using Gameplay.Counters;

namespace Gameplay.Spaceships
{
    public interface IScorable
    {
        
        /// <summary>
        /// Score counter link;
        /// </summary>
        ScoreCounter ScoreCounter { get; set; }

        /// <summary>
        /// Score amount getting for destruction;
        /// </summary>
        float ScoreForDestroy { get; }

        /// <summary>
        /// Add score to score counter;
        /// </summary>
        /// <param name="score"></param>
        void AddScore(float score);

    }
}