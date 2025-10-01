using System;
using MotoGP.API.Entities;

namespace MotoGP.API.Strategies
{
    public class LapsBasedCalculator : IRaceDurationCalculator
    {
        public TimeSpan CalculateDuration(Race race)
        {
            if (race.LapCount <= 0 || race.LapTime <= 0)
            {
                throw new InvalidOperationException("Lap count and average lap time must be greater than zero.");
            }

            return TimeSpan.FromSeconds(race.LapCount * race.LapTime);
        }
    }
}
