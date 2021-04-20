using System;
using System.Collections.Generic;
using System.Text;
using Codecool.LifeOfAnts.Colony;

namespace Codecool.LifeOfAnts.Ants
{
    /// <summary>
    /// Worker class
    /// </summary>
    public class Worker : Ant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="position"> position of the ant </param>
        public Worker(Position position)
        {
            Symbol = '*';
            Coordinates = position;
        }

        /// <summary>
        /// Moves ants
        /// </summary>
        public override void MakeMove()
        {
            var nextPosition = Coordinates.NextCoordinatesInDirection(DirectionExtensions.GetRandomDirection());

            while (!IsMoveValid(nextPosition))
            {
                nextPosition = Coordinates.NextCoordinatesInDirection(DirectionExtensions.GetRandomDirection());
            }

            Coordinates = nextPosition;
        }

        /// <summary>
        /// Worker to string
        /// </summary>
        /// <returns>
        /// Returns Worker symbol as string
        /// </returns>
        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
