NOTE: This is an old hobby project made in 2018, and put in the Unity Asset Store here:
https://assetstore.unity.com/packages/3d/environments/elfansoermaze-simple-142904

Elfansoer Maze (Simple) Documentation

///////////////
A. Introduction
///////////////
Basic Features:
- Procedurally-generated perfect maze (a maze that only have 1 solution).
- Variable maze width and height.
- Random seed, to generate the same maze twice.
- Allow creation in both Editor and Runtime.
- Includes 3 Demo scenes: Basic maze, dynamic maze, and runtime maze.

Point Features:
- Quick and Editable.
The maze generation process uses primitive data structures to ensure speed.
The generated maze is a collection of tiles; you can edit and change it however you want.

- Separate maze generation and instantiation
Maze generation process is independent to the tileset used.
Technically, this package only consisted of scripts. The prefabs for tiles are only for demos (and plain-looking, created by a programmer).

- Tile-based.
The maze is composed of tiles with connectivity to top, bottom, left, or right.
It uses 6 basic tiles to generate the maze.

- Flexible tile.
Create your own tileset to customize your maze, and any gameObject can be a tile. 
You can use a mesh, a parent gameobject with children, a trigger, or anything that has a Transform, to be a tile.
The tiles can be any size, specified on your custom tileset.

Full version Features (coming soon):
- Pattern tiles.
Zig-zags looks boring? Long corridors looks plain?
Define your own pattern tiles to replace zigzags into a roundabout and long corridors into a bridge!
The Pattern Tile is a MxN-sized tile, with a probability to make a certain pattern in the maze to use the pattern tiles instead of basic tileset.
The actual maze itself didn't change; only the tileset representation that are replaced.

- Special tiles.
Want to have a boss room inside the maze? Have a specific big room to hold all treasure? Wanna PUT A MAZE INSIDE A MAZE!?
Define your own special tiles to create special rooms for unique gameplay!
The Special Tile is a MxN-sized tile, with a probability to appear in the room.
The actual maze will respect the room walls, and you can specify to guarantee that each room's entrances leads to a different spot of the maze (nice for fetch quests).

/////////////
B. Usage
/////////////
- TL:DR;
1. Put the Maze prefab on the scene.
2. Specify the width, height, and seed of the maze (0 is random).
3. Click "Generate".
4. Don't like it? Click "Generate".
5. Want another? Click "Generate".
6. There you go. The maze will stay the same if the seed is not zero, though.
To change the maze, simply change the values and click "Generate" again.

- Long Read
1. Set your Basic Tiles
There are 6 types of basic tiles: None, Up, UpRight, UpDown, UpDownRight, and All. These tiles corresponds to maze's connectivity.
"Up" means that within maze, the tile only connect to up direction, UpRight to up and right, and so on.
For other connectivity, say LeftRight, the Implementer will use UpDown tile and ROTATE COUNTER-CLOCKWISE, and so are other connectivity.

Here's the guideline on creating your Tiles for the tileset:
- Any GameObject with Transform can be a tile. Even an empty GameObject. Or a GameObject with childrens.
- Make sure that its Transform is located at origin (0,0,0)
- Try rotate the tile in Y-direction at 90, 180, and 270. The tile should look like another tile (e.g. "Up" tile become "Right", "Down", and "Left")
- It's not mandatory, but for a nice look, make sure that it connects nicely to other tiles.
- "None" tile is rarely used for this version, but it is mandatory. You can use an empty GameObject for it.

2. Set your MazeTileSet
The maze itself didn't need a tileset to generate, but to implement them to the scene, a MazeTileSet is required.
You can use the existing MazeTileSet, modify them, or create on your own.

Here's the guideline on creating MazeTileSet (MTS):
- The MTS is a Component; you can use an empty GameObject as its host.
- Specify the Tile Size. This will specify the distance between the tiles generated.
- Set the basic tiles, as described above, by dragging your tiles to the Component.
- Special and Pattern tiles aren't used at this version. Leave them as is.

3. Instantiate your Maze
Like MazeTileSet, the script creating the Maze (ElfansoerMazeSimple) is a Component; so normally you'd want an empty Gameobject.
Each tile will have its coordinates, with x component goes to the right, and y component goes to up.
The Maze will spawn at the Parent's position; precisely the tile at [0,0] (bottom-left-most tile).

The fields are pretty straightforward, but here's the guideline:
- Width and height must be positive.
- Seed can be any integer. Use zero to have the Maze be randomed each time you generate.
- Gameobject for "Tile Set" must have "MazeTileSet" component to it. (you've been warned...)

4. Instantiate using script
You can also create the Maze at Runtime, and re-Generate it dynamically. 

You can take a look at "GameController" script in the Demo, and here's the guideline:
- Create an ElfansoerMazeSimple component to a GameObject (Or just instantiate "Maze" prefab)
- Modify the fields (width, height, seed)
- Instantiate the Tileset Prefab, then set it to the Component
- Call Build().

Here's a few exposed methods that you can use:
- Build(): Must be called after setting fields and TileSet. Generates the maze for the first time.
- Generate(): Must be called after Maze has been created. Destroys existing maze and re-create it.
- Destroy(): Must have existing maze. Destroy the current maze.
- Indexes: Must have existing maze. Calling the component as maze[x,y] will get you the tile at [x,y].

///////////////////
C. Demo Scenes
///////////////////
There are 3 Demo Scenes you can use as examples:
1. SimpleMazeScene
This Scene is the most basic usage for the Maze.
It has a sphere player (with basic control and camera) inside an existing maze.
You can modify the Maze's values and click "Generate" to change the maze. The maze will stay as it is when you run the game.

2. RuntimeMazeScene
This scene shows how you can create and re-Generate a maze during runtime.
It has a sphere player and an empty GameObject named GameController. This object will spawn a Maze at its origin.
Each time the player moved 100 distance out from the original position, the maze will reset. 
You can take a look at GameController object and script, to give you examples on how to use it.

3. DynamicMazeScene
This scene shows that anything can be a tile.
It has a sphere player, a Maze, and a Plane. The TileSet used consisted of only walls, so a plane exists as the floor.
The Maze uses a different tileset that you can observe. Each tile is a group of walls with tag "DynamicWall" on it.
The Wall's height is determined by how close it is to the player.

///////////////////
D. Future Releases
///////////////////
There's several improvements I would like to implement in this version, such as:
1. Entrance and Exit position.
2. Loop Maze (A maze you can create a tile around seamlessly)
3. 3D Maze (A maze that you can also go up and down)