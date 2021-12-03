# Dimensional Maze Mechanics .

[Visit us on itch.io](https://victoku1.itch.io/mazesimulation1)

[![](http://img.youtube.com/vi/L4ISZooIM3Q/0.jpg)](http://www.youtube.com/watch?v=L4ISZooIM3Q "DimensionalMazeProj Tutorial And Models Demonstration .")

Use W,A,S,D to move , SPACE to change the dimension( where some walls may change their status.

Was made as one a weekly task in a unity game development course.

By VictoKu1 .

Description:

The massive changes are:
1. Added a tutorial level with a short explanations of the controls.
2. Implemented a 3D Maze Generation based on Recursive Backtrack Algorithm.

Basic generation proccess pseudocode:

```
This algorithm, also known as the "recursive backtracker" algorithm, is a randomized version of the depth-first search algorithm.

Frequently implemented with a stack, this approach is one of the simplest ways to generate a maze using a computer. Consider the space for a maze being a large grid of cells (like a large chess board), each cell starting with four walls. Starting from a random cell, the computer then selects a random neighbouring cell that has not yet been visited. The computer removes the wall between the two cells and marks the new cell as visited, and adds it to the stack to facilitate backtracking. The computer continues this process, with a cell that has no unvisited neighbours being considered a dead-end. When at a dead-end it backtracks through the path until it reaches a cell with an unvisited neighbour, continuing the path generation by visiting this new, unvisited cell (creating a new junction). This process continues until every cell has been visited, causing the computer to backtrack all the way back to the beginning cell. We can be sure every cell is visited.

As given above this algorithm involves deep recursion which may cause stack overflow issues on some computer architectures. The algorithm can be rearranged into a loop by storing backtracking information in the maze itself. This also provides a quick way to display a solution, by starting at any given point and backtracking to the beginning.


Mazes generated with a depth-first search have a low branching factor and contain many long corridors, because the algorithm explores as far as possible along each branch before backtracking.





The depth-first search algorithm of maze generation is frequently implemented using backtracking. This can be described with a following recursive routine:

Given a current cell as a parameter,
Mark the current cell as visited
While the current cell has any unvisited neighbour cells
Choose one of the unvisited neighbours
Remove the wall between the current cell and the chosen cell
Invoke the routine recursively for a chosen cell
which is invoked once for any initial cell in the area.




```
