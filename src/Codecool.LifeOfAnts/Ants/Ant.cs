using System;
using System.Collections.Generic;
using System.Text;
using Codecool.LifeOfAnts.Colony;

namespace Codecool.LifeOfAnts.Ants
{
    /// <summary>
    /// Abstract class for ant
    /// </summary>
    public abstract class Ant
    {
        /// <summary>
        /// Gets or sets Ant Colony
        /// </summary>
        public AntColony AntColony { get; set; }

        /// <summary>
        /// Gets or sets symbol for ant
        /// </summary>
        protected char Symbol { get; set; }

        /// <summary>
        /// Gets or sets ant coordinates
        /// </summary>
        protected Position Coordinates { get; set; }

        /// <summary>
        /// Moves ants
        /// </summary>
        public abstract void MakeMove();

        /// <summary>
        /// Checks validity of Worker move
        /// </summary>
        /// <param name="next"> next </param>
        /// <returns>
        /// Returns bool
        /// </returns>
        public bool IsMoveValid(Position next)
        {
            if (next.X >= AntColony.GetWidth() || next.X < 0)
            {
                return false;
            }
            else if (next.Y >= AntColony.GetWidth() || next.Y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Gets position of the Queen
        /// </summary>
        /// <returns>
        /// Returns Position
        /// </returns>
        public virtual Position GetPosition()
        {
            return Coordinates;
        }

        /// <summary>
        /// Gets symbol of the Queen
        /// </summary>
        /// <returns>
        /// Returns character
        /// </returns>
        public virtual char GetSymbol()
        {
            return Symbol;
        }
    }
}
