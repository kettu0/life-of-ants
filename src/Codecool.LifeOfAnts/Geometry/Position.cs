using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Position struct
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     Gets or sets X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="symbol">Symbol parameter</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets distance to the other coordinate
        /// </summary>
        /// <param name="other"> Coordinates</param>
        /// <returns> Returns int </returns>
        public int DistanceToCoordinate(Position other)
        {
            return Math.Abs(other.X - X) + Math.Abs(other.Y - Y);
        }

        /// <summary>
        /// Gets distance to the other coordinate
        /// </summary>
        /// <param name="direction"> Gets next direction </param>
        /// <returns> Returns int </returns>
        public Position NextCoordinatesInDirection(Direction direction)
        {
            Position nextCoordinate = new Position(X, Y);
            switch (direction)
            {
                    case Direction.North:
                    nextCoordinate = new Position(X, Y + 1);
                    break;
                    case Direction.East:
                    nextCoordinate = new Position(X + 1, Y);
                    break;
                    case Direction.South:
                    nextCoordinate = new Position(X, Y - 1);
                    break;
                    case Direction.West:
                    nextCoordinate = new Position(X - 1, Y);
                    break;
            }

            return nextCoordinate;
        }
    }
}
