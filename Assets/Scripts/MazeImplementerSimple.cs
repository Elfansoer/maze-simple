using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
using UnityEngine;

namespace Elfansoer.Maze {

class MazeImplementerSimple {
	static byte[] tileType   = { 0, 1, 1, 2, 1, 3, 2, 4, 1, 2, 3, 4, 2, 4, 4, 5 };
	static byte[] tileRotate = { 0, 0, 1, 0, 2, 0, 1, 0, 3, 3, 1, 3, 2, 2, 1, 0 };

	public int tileSize {get; private set;}
	Maze map;
	Transform parent;
	GameObject[] tileSet;
	// Full-version only
	// GameObject[] specialTileSet;
	// GameObject[] patternTileSet;

	public void SetMaze( Maze m ) {
		map = m;
	}

	public void SetMap( int[,] m ) {
		map = new Maze( m );
	}

	public void SetTileSet( MazeTileSet mt ) {
		tileSize = mt.tileSize;
		tileSet = mt.GetBasicTiles();

		// Full-version only
		// specialTileSet = mt.GetSpecialTiles();
		// patternTileSet = mt.GetPatternTiles();
	}

	public void SetParent( Transform p ) {
		parent = p;
	}

	public Dictionary<Vector2Int,GameObject> Generate() {
		Dictionary<Vector2Int,GameObject> ret = new Dictionary<Vector2Int,GameObject>();

		// Generate
		Vector2Int pos = new Vector2Int(0,0);
		for( int x=0; x<map.width; x++ ) {
			for( int y=0; y<map.height; y++ ) {
				pos.Set(x,y);

				// Full-version only
				// // check hidden tile
				// if ( map[ Maze.MAP_TYPE, pos ] == Maze.TYPE_HIDDEN ) {
				// 	continue;
				// }
				// // check special tile
				// if ( map[ Maze.MAP_TYPE, pos ] == Maze.TYPE_SPECIAL ) {
				// 	ret.Add( LoadSpecialTile( pos ) );
				// 	continue;
				// }				
				// // check pattern tile
				// if ( map[ Maze.MAP_TYPE, pos ] == Maze.TYPE_PATTERN ) {
				// 	ret.Add( LoadPatternTile( pos ) );
				// 	continue;
				// }

				// Instantiate object at (x,y)
				ret.Add(new Vector2Int(x,y), LoadTile( map[x,y], pos ) );
			}
		}

		return ret;
	}

	GameObject LoadTile( int type, Vector2Int pos ) {
		// Instantiate object at (x,y)
		return Object.Instantiate(
			tileSet[ tileType[ type ] ],
			parent.position + new Vector3( pos.x*tileSize, 0, pos.y*tileSize ),
			Quaternion.Euler( new Vector3(0, 90*tileRotate[ type ], 0 ) ),
			parent
		);
	}

	// Full-version only
	// GameObject LoadPatternTile( Vector2Int pos ) {
	// }
	// GameObject LoadSpecialTile( Vector2Int pos ) {
	// }
}

}