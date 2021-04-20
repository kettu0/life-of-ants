using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.LifeOfAnts.Ants;

namespace Codecool.LifeOfAnts.Colony
{
    /// <summary>
    /// Ant colony class
    /// </summary>
    public class AntColony
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AntColony"/> class.
        /// </summary>
        /// <param name="width">width</param>
        public AntColony(int width)
        {
            _width = width;
            _height = _width;
            _allAnts = new List<Ant>();
            _theQueen = new Queen(new Position(_width / 2, _width / 2));
        }

        /// <summary>
        /// Gets or sets list of drones
        /// </summary>
        public List<Drone> DronesList { get; set; }

        private Random _randomNumber = new Random();
        private Dictionary<Position, List<Ant>> _colonyMap;
        private int _width;
        private int _height;
        private List<Ant> _allAnts;
        private Queen _theQueen;

        /// <summary>
        /// Prints updated colony
        /// </summary>
        public void CreateEmptyColony()
        {
            _colonyMap = new Dictionary<Position, List<Ant>>();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _colonyMap[new Position(x, y)] = new List<Ant>();
                }
            }
        }

        /// <summary>
        /// Prints updated colony
        /// </summary>
        public void UpdateAndPrintColony()
        {
            CreateEmptyColony();
            UpdateColony();
            PrintColony();
        }

        /// <summary>
        /// Updates colony
        /// </summary>
        public void UpdateColony()
        {
            foreach (var ant in _allAnts)
            {
                ant.MakeMove();
                _colonyMap[ant.GetPosition()].Add(ant);
            }
        }

        /// <summary>
        /// Prints colony
        /// </summary>
        public void PrintColony()
        {
            string vertialEdge = String.Concat(Enumerable.Repeat("-", 2 * _width));
            string antColonyBoard = "+" + vertialEdge + "+\n";

            for (int x = 0; x < _width; x++)
            {
                string printedRow = string.Empty;

                for (int y = 0; y < _height; y++)
                {
                    Position position = new Position(x, y);

                    if (_colonyMap[position].Count() != 0)
                    {
                    printedRow += _colonyMap[position][0].ToString() + " ";
                    }
                    else
                    {
                        printedRow += "  ";
                    }
                }

                antColonyBoard += "|" + printedRow + "|" + "\n";
            }

            antColonyBoard += "+" + vertialEdge + "+\n";

            Console.WriteLine(antColonyBoard);
        }

        /// <summary>
        /// Checks validity of initial position of Drones
        /// </summary>
        /// <returns>Returns initial position of Drones</returns>
        public Position ValidStartingDroneAntCoordinates()
        {
            var startingDronePosition = RandomPointInColony();

            while (startingDronePosition.DistanceToCoordinate(_theQueen.GetPosition()) < _width / 2)
            {
                startingDronePosition = RandomPointInColony();
            }

            return startingDronePosition;
        }

        /// <summary>
        /// Gets random position of ants in colony
        /// </summary>
        /// <returns>Returns random position point in colony</returns>
        public Position RandomPointInColony()
        {
            int xcoordinate = Math.Abs(_randomNumber.Next(0, _width - 1));
            int ycoordinate = Math.Abs(_randomNumber.Next(0, _width - 1));

            return new Position(xcoordinate, ycoordinate);
        }

        /// <summary>
        /// Gets width of the colony
        /// </summary>
        /// <returns>Returns int</returns>
        public int GetWidth()
        {
            return _width;
        }

        /// <summary>
        /// Gets the Queen
        /// </summary>
        /// <returns>Returns The Queen</returns>
        public Queen GetTheQueen()
        {
            return _theQueen;
        }

        /// <summary>
        /// Generates Ants
        /// </summary>
        /// <param name="workers">number of workers</param>
        /// <param name="soldiers">number of soldiers</param>
        /// <param name="drones">number of drones</param>
        public void GenerateAnts(int workers, int soldiers, int drones)
        {
            for (int w = 0; w < workers; w++)
            {
                _allAnts.Add(new Worker(RandomPointInColony()));
            }

            for (int s = 0; s < soldiers; s++)
            {
                _allAnts.Add(new Soldier(RandomPointInColony()));
            }

            for (int d = 0; d < drones; d++)
            {
                _allAnts.Add(new Drone(ValidStartingDroneAntCoordinates()));
            }

            _allAnts.Add(_theQueen);

            foreach (var ant in _allAnts)
            {
                _colonyMap[ant.GetPosition()].Add(ant);
                ant.AntColony = this;
            }
        }
    }
}
