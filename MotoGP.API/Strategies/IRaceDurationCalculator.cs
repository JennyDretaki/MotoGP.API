using System;
using MotoGP.API.Models; // Adjust this namespace based on your project structure

namespace MotoGP.API.Strategies
{
    public interface IRaceDurationCalculator
    {
        TimeSpan CalculateDuration(Race race);
    }
}
