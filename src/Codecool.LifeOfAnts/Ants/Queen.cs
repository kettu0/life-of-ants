using System;

namespace Codecool.LifeOfAnts.Ants
{
    /// <summary>
    /// Queen class
    /// </summary>
    public class Queen : Ant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen"/> class.
        /// </summary>
        /// <param name="position"> Position </param>
        public Queen(Position position)
        {
            Symbol = '&';
            Coordinates = position;
            _goodMoodCountdown = new Random().Next(50, 100);
        }

        private int _goodMoodCountdown;

        /// <summary>
        /// Gets good mood countfown of the Queen
        /// </summary>
        /// <returns>
        /// Returns int
        /// </returns>
        public int GetGoodMoodCountdown()
        {
            return _goodMoodCountdown;
        }

        /// <summary>
        /// Checks if Queen is in mood for mating
        /// </summary>
        /// <returns>
        /// Returns bool
        /// </returns>
        public bool IsInGoodMood()
        {
            if (_goodMoodCountdown == 0)
            {
                Console.WriteLine("The Queen is in mood for mating");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Queen mates
        /// </summary>
        public void Mate()
        {
            _goodMoodCountdown = new Random().Next(50, 100);
        }

        ///<summary>
        /// Queen to string
        /// </summary>
        /// <returns>
        /// Returns Queens symbol as string
        /// </returns>
        public override string ToString()
        {
            return Symbol.ToString();
        }

        /// <summary>
        /// Checks if Queen is ready for the mating
        /// </summary>
        public override void MakeMove()
        {
            if (IsInGoodMood())
            {
                Mate();
            }
            else if (!IsInGoodMood() && _goodMoodCountdown != 0)
            {
                _goodMoodCountdown -= 1;
            }

            Console.WriteLine("The Queen will be in good mood for another mating in " + _goodMoodCountdown + " time steps\n");
        }
    }
}
