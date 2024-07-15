using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elfansoer.Maze;

[ExecuteInEditMode]
public class ElfansoerMazeSimple : MonoBehaviour {
	// Public fields
	public int width = 5;
	public int height = 5;
	public int seed = 0;
	public GameObject tileSet;
	Vector2Int startPoint = new Vector2Int(0,0);

	// private fields
	MazeGeneratorSimple mg;
	MazeImplementerSimple mi;
	Dictionary<Vector2Int,GameObject> tiles;

	// Auto-properties
	public GameObject this[int x, int y] {
		get { return tiles[new Vector2Int(x,y)]; }
	}
	public GameObject this[Vector2Int pos] {
		get { return tiles[pos]; }
	}

	/* Build:
	- Initializes the maze builder, and generate a maze.
	- It should be called after setting public fields.
	- The generated maze's origin tile (at position (0,0)) will be positioned at parent's origin.
	*/
	public void Build() {
		// Init tileset
		MazeTileSet ts = tileSet.GetComponent<MazeTileSet>();

		// Init generator
		mg = new MazeGeneratorSimple( width, height, seed, startPoint );
		// Full-version only
		// mg.SetTileSet( ts );

		// init implementer
		mi = new MazeImplementerSimple();
		mi.SetTileSet( ts );
		mi.SetParent( gameObject.transform );

		// Destroy existing maze
		Destroy();

		// Create Maze
		mg.Create();

		// Implement map
		mi.SetMaze( mg.GetMaze() );
		tiles = mi.Generate();
	}

	/* Generate:
	- Reroll the maze generation, with the same public parameter.
	- If you wish to change parameter, use Build() instead.
	- If the previous maze still exists, it destroys the existing first.
	*/
	public void Generate() {
		// Destroy existing maze
		Destroy();

		// Create Maze
		mg.Create();

		// Implement map
		mi.SetMaze( mg.GetMaze() );
		tiles = mi.Generate();
	}

	/* Destroy:
	- Reroll the maze generation, with the same public parameter.
	- If the previous maze still exists, it destroys the existing first.
	*/
	public void Destroy() {
		if (tiles==null) return;
		foreach ( KeyValuePair<Vector2Int,GameObject> item in tiles ) {
			Object.Destroy(item.Value);
		}
		tiles = null;
	}

	// Editor functions
	public void Build_Editor() {
		// Init tileset
		MazeTileSet ts = tileSet.GetComponent<MazeTileSet>();

		// Init generator
		mg = new MazeGeneratorSimple( width, height, seed, startPoint );
		mg.SetTileSet( ts );

		// init implementer
		mi = new MazeImplementerSimple();
		mi.SetTileSet( ts );
		mi.SetParent( transform );

		// Create Maze
		mg.Create();

		// Implement map
		mi.SetMaze( mg.GetMaze() );
		mi.Generate();
	}

	public void Rebuild_Editor() {
		List<GameObject> l = new List<GameObject>();

		// find child object
		foreach( Transform child in transform ) {
			l.Add(child.gameObject);
		}

		// destroy objects
		foreach( var o in l ) {
			Object.DestroyImmediate(o);
		}

		// build again
		Build_Editor();
	}
}