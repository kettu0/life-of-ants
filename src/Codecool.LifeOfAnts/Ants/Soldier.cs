using System;

namespace Codecool.LifeOfAnts.Ants
{
    /// <summary>
    /// Soldier class
    /// </summary>
    public class Soldier : Ant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Soldier"/> class.
        /// </summary>
        /// <param name="position"> Position of the ant </param>
        public Soldier(Position position)
        {
            Symbol = '@';
            Coordinates = position;
        }

        private Direction _lastStepDirection;

        /// <summary>
        /// Gets new Soldier direction
        /// </summary>
        /// <returns>
        /// Returns position
        /// </returns>
        public Direction GetNextDirection()
        {
            Direction nextDirection = _lastStepDirection;

            switch (_lastStepDirection)
            {
                case Direction.West:
                    nextDirection = Direction.South;
                    _lastStepDirection = Direction.South;
                    break;
                case Direction.South:
                    nextDirection = Direction.East;
                    _lastStepDirection = Direction.East;
                    break;
                case Direction.East:
                    nextDirection = Direction.North;
                    _lastStepDirection = Direction.North;
                    break;
                case Direction.North:
                    nextDirection = Direction.West;
                    _lastStepDirection = Direction.West;
                    break;
            }

            return nextDirection;
        }

        /// <summary>
        /// Moves ants
        /// </summary>
        public override void MakeMove()
        {
            var nextPosition = Coordinates.NextCoordinatesInDirection(GetNextDirection());

            while (!IsMoveValid(nextPosition))
            {
                nextPosition = Coordinates.NextCoordinatesInDirection(GetNextDirection());
            }

            Coordinates = nextPosition;
        }

        /// <summary>
        /// Soldier to string
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
