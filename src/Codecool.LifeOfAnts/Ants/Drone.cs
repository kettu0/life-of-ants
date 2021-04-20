using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.Colony;

namespace Codecool.LifeOfAnts.Ants
{
    /// <summary>
    /// Drone class
    /// </summary>
    public class Drone : Ant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Drone"/> class.
        /// </summary>
        /// <param name="position">position of the ant</param>
        public Drone(Position position)
        {
            Symbol = '#';
            Coordinates = position;
            _matingCountdown = 0;
            _isMating = false;
        }

        private int _matingCountdown;
        private bool _isMating;
        private int _timeSteps = 11;

        /// <summary>
        /// Gets position of an ant
        /// </summary>
        /// <returns>
        /// Returns Position
        /// </returns>
        public override Position GetPosition()
        {
            return Coordinates;
        }

        /// <summary>
        /// Gets symbol of an ant
        /// </summary>
        /// <returns>
        /// Returns character
        /// </returns>
        public override char GetSymbol()
        {
            return Symbol;
        }

        /// <summary>
        /// Gets isMating of Drone
        /// </summary>
        /// <returns>Returns bool</returns>
        public bool GetIsMating()
        {
            return _isMating;
        }

        /// <summary>
        /// Gets isMating of tge Queen
        /// </summary>
        /// <returns>Returns bool</returns>
        public int GetMatingCountdown()
        {
            return _matingCountdown;
        }

        /// <summary>
        /// Moves Drone towards Queen
        /// </summary>
        /// <returns>Returns Position</returns>
        public Position MoveTowardsQueen()
        {
            var nextPosition = Coordinates.NextCoordinatesInDirection(DirectionExtensions.GetRandomDirection());
            var queenPosition = AntColony.GetTheQueen().GetPosition();

            while (nextPosition.DistanceToCoordinate(queenPosition) > Coordinates.DistanceToCoordinate(queenPosition))
            {
                nextPosition = Coordinates.NextCoordinatesInDirection(DirectionExtensions.GetRandomDirection());
            }

            Coordinates = nextPosition;

            return Coordinates;
        }

        /// <summary>
        /// Checking if Drone reached Queen
        /// </summary>
        /// <returns>Returns bool</returns>
        public bool ReachedQueen()
        {
            var queenPosition = AntColony.GetTheQueen().GetPosition();
            if (Coordinates.DistanceToCoordinate(queenPosition) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Drone tries mating with Queen
        /// </summary>

        public void TryMating()
        {
            if (AntColony.GetTheQueen().IsInGoodMood())
            {
                Console.WriteLine("Drone says: HALLELUJAH");
                _isMating = true;
            }
            else if (!AntColony.GetTheQueen().IsInGoodMood() && !_isMating)
            {
                Console.WriteLine("Drone says: :(\n");
                Coordinates = GetPositionAfterKickout();
            }
        }

        /// <summary>
        /// Drone contuines mating
        /// </summary>
        public void ContinueMating()
        {
            _matingCountdown += 1;
        }

        /// <summary>
        /// Resets Drone poistion
        /// </summary>
        public void ResetPosition()
        {
            Coordinates = GetPositionAfterKickout();
            _matingCountdown = 0;
        }

        ///<summary>
        /// Sets new position after kickout
        ///</summary>
        ///<returns>Returns new Drone position</returns>
        public Position GetPositionAfterKickout()
        {
            var kickOutPositions = new List<Position>();

            for (int x = 0; x < AntColony.GetWidth(); x++)
            {
                kickOutPositions.Add(new Position(x, 0));
                kickOutPositions.Add(new Position(x, AntColony.GetWidth() - 1));
                kickOutPositions.Add(new Position(0, x));
                kickOutPositions.Add(new Position(AntColony.GetWidth() - 1, x));
            }

            return kickOutPositions[new Random().Next(kickOutPositions.Count)];
        }

        /// <summary>
        /// Drone to string
        /// </summary>
        /// <returns>
        /// Returns Drone symbol as string
        /// </returns>
        public override string ToString()
        {
            return Symbol.ToString();
        }

        /// <summary>
        /// Moves ants
        /// </summary>
        public override void MakeMove()
        {
            if (ReachedQueen())
            {
                TryMating();
                if (_isMating)
                {
                    ContinueMating();

                    if (_matingCountdown <= 10)
                    {
                        _timeSteps -= 1;
                        Console.WriteLine("Drone is mating with the Queen for another " + _timeSteps + " time steps\n");
                    }
                    else if (_matingCountdown > 10)
                    {
                        _isMating = false;
                        ResetPosition();
                        _timeSteps = 11;
                    }
                }
                else if (!_isMating)
                {
                    ResetPosition();
                }
            }
            else
            {
                MoveTowardsQueen();
            }
        }
    }
}