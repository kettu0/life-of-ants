# Life of the Ants

This is one of the final tasks at Codecool. We had to write a console simulation regarding life of ants in colony. Rules below.

## Story 

In an ant colony there are four different castes: _workers_, _soldiers_, _drones_, and there is one _queen_. The colony area is square (has a width), and the ants live and move within the borders of the colony.

Each ant changes position in every timestep, according to a caste-specific rule:
- the queen sits in the middle and does not move
- the workers normally make one step in one of the four directions, chosen randomly before each move
- the soldiers "patrol" close to their starting position; this means that in a 4-cycle they step one and turn to the left (towards North, East, South, and West, and then they start the cycle again)
- the drones always try to make one step towards the Queen. When they get next to the queen, they have a chance that she is in the mood of mating. In this happy case they say "HALLELUJAH", and stay there for 10 timesteps. After that they are kicked off to a random position at the edge of the colony. If the queen isn't in the mood, drones say ":(", and are kicked away instantly.

The queen’s mating mood is following this rule: after a successful mating she sets a countdown timer (starting from some time between 50 and 100 timesteps) to get in the mood again.

## Tasks


1. A colony is created with a `Width` value setting its range, a `Width` by `Width` square.
A colony is created with a `Width` value setting its range, a `Width` by `Width` square.
A queen is created at construction time positioned at the center of
the colony. Colony also has a `GenerateAnts` method with three integer arguments
that set the number of drones, workers, and soldiers to be created, respectively.
It also has an `Update` method which invokes each ants' `OnUpdate` method,
and a `Display` method which displays the colony "map" on the console.
    - Upon construction, the value of width is set, and a queen is created at the center
    - Method `Update` that calls `Move` on each ants
    - Method `Display` prints all ants in the colony as a `Width` by `Width` map, placing the initials of the ants (`Q`, `W`, `S`, `D`) at their actual positions. If more then one ants share the same position, display the letter for one of them

2. Implement the main loop of the simulation: step forward one time unit and display the state of the colony every time when the `Enter` key is pressed. Hitting `q` and `Enter` exits the program.
    - The simulation creates a colony and populates it with all kinds of ants
    - The simulation updates once and displays the state of the colony after hitting `Enter`
    - The program stops one after hitting `q` and `Enter`

3. Implement the basic movement behavior of ants. Ensure that if the step would cause an ant to leave the range of the colony, it won't move.
    - Workers move one step into a random direction
    - Soldiers patrol by stepping one and turning to the left in every time step
    - Drones move one step closer to the queen. If they reach the queen's position, they get instantly kicked away to a random position, exactly `Width / 2` steps away
    - The queen does not move at all
    - Ants stay within the range of the colony

4. Implement the mating behavior of drones and the queen.
    - The queen's mating mood is set by a counter which is decremented by one in each step. If it reaches zero, the next drone encounter will end up in mating. This resets the counter to a random value between 50 and 100
    - The successful drone stays next to the queen for 10 steps after mating, before getting kicked away as usual


# My solution

Instead of letters (`Q`, `W`, `S`, `D`), I decided to mark ants as `&`, `*`, `@`, `#` respectively.
Screenshots for reference.

## Starting screen
![image](https://user-images.githubusercontent.com/60843449/115462200-a70e7200-a22a-11eb-9a34-db8c33ece2c2.png)

## Colony with mating and ant information
![image](https://user-images.githubusercontent.com/60843449/115462560-11bfad80-a22b-11eb-9de4-2899b59156e7.png)

