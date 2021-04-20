using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    /// Static class for Direction enum extension methods
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// Gets random Direction
        /// </summary>
        /// <returns> Returns Direction </returns>
        public static Direction GetRandomDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Direction randomDirection = (Direction)values.GetValue(new Random().Next(values.Length));

            return randomDirection;
        }
    }
}
