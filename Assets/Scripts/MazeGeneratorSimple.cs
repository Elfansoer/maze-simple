using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Elfansoer.Maze {

class MazeGeneratorSimple {
	// Convention: (x,y)
	const int UP = 1;
	const int DOWN = 4;
	const int LEFT = 8;
	const int RIGHT = 2;
	const int ALL = 15;

	// Configurables
	int size;
	int width, height;
	int seed;
	Vector2Int startPoint;

	// Fields
	int[,] area;
	Maze m;
	// Full-version only
	// SpecialTile[] specials;
	// PatternTile[] patterns;

	// Constructors
	public MazeGeneratorSimple( int w, int h ): this(w,h,0,new Vector2Int(0,0)) {}
	public MazeGeneratorSimple( int w, int h, Vector2Int v ): this(w,h,0,v) {}
	public MazeGeneratorSimple( int w, int h, int s ): this(w,h,s,new Vector2Int(0,0)) {}
	public MazeGeneratorSimple( int w, int h, int s, Vector2Int v ) {
		width = w;
		height = h;
		seed = s;
		startPoint = v;
	}
	public Maze GetMaze() {
		return m;
	}

	/* Initializations
	- a tileset should contain an array of special tileset and pattern tileset (can be zero)
	- each special tile Must contain MazeSpecialTile element
	- each pattern tile Must contain MazePatternTile element
	*/
	public void SetTileSet( MazeTileSet mt ) {
		// Set Special Tiles
		// Full-version only
		// SetSpecialTileSet( mt.GetSpecialTiles() );
		// SetPatternTileSet( mt.GetPatternTiles() );
	}
	public void SetSpecialTileSet( GameObject[] tiles ) {
		// Full-version only
	}
	public void SetPatternTileSet( GameObject[] tiles ) {
		// Full-version only
	}

	/* steps of map generation:
	- InitMaze, initialize maze with unvisited status and no traversability
	- AssignSpecials, initialize blank maze with pre-determined special rooms
	- Traverse, use random walk to fill out maze
	- AssignPatterns, change a pattern in maze to a specific tile
	*/
	public void Create() {
		InitMaze();

		// Full-version only
		// AssignSpecials();
		// PlaceSpecials();

		Traverse();

		// Full-version only
		// AssignPatterns();
	}

	void InitMaze() {
		// set up visit status and traversability
		area = new int[width,height];
		m = new Maze( new int[width,height] );

		int x,y;
		for( x=0; x<width; x++ ) {
			for( y=0; y<height; y++) {
				// all can be traversed
				area[x,y] = ALL;

				// except at boundary
				if (x==0) {
					area[x,y] &= (~LEFT);
				}
				if (x==width-1) {
					area[x,y] &= (~RIGHT);
				}
				if (y==0) {
					area[x,y] &= (~DOWN);
				}
				if (y==height-1) {
					area[x,y] &= (~UP);
				}
			}
		}
	}

	void AssignSpecials() {
		// Full-version only
	}
	void PlaceSpecials() {
		// Full-version only
	}

	void Traverse() {
		// setup random seed
		if (seed!=0) {
			Random.InitState(seed);
		}

		Vector2Int v = startPoint;

		// setup stack
		Vector2Int[] stack = new Vector2Int[width*height];
		int sti = 0;

		// loop until can't traverse anymore
		int r, dir;
		while(true) {
			// set all neighbor that this is visited
			Vector2Int g;
			for (dir=UP; dir<=LEFT; dir=dir<<1 ) {
				g = M.MoveVector( v, dir );
				if (IsInBoundary(g)) {
					area[g.x,g.y] &= (~M.inverse[dir]);
				}
			}

			// pop if all neighbors has been visited
			if (area[v.x,v.y]==0) {
				// if end of stack, end
				if (sti<0) {
					break;
				} else {
					// go back in stack
					v = stack[sti];
					sti = sti-1;
					continue;
				}
			}

			// randomize direction, except if there's big tile
			int[] available = M.directions[area[v.x,v.y]];
			r = Random.Range(0, available.Length);
			dir = available[r];

			// set select neighbor as visited
			area[v.x,v.y] &= (~dir);
			// areaDel(area,v,dir);

			// set select neighbor as traversable
			m[v] = m[v] | dir;

			// add to stack if still traversable
			sti = sti+1;
			stack[sti] = v;

			// move to the next tile
			v = M.MoveVector(v,dir);

			// preinit for the next tile
			dir = M.inverse[dir];
			m[v] = m[v] | dir;
		}
	}

	void AssignPatterns() {
		// Full-version only
	}

	bool IsInBoundary( Vector2Int pos ) {
		return ( pos.x>=0 && pos.x<width && pos.y>=0 && pos.y<height );	
	}
	bool IsInBoundary( int x, int y ) {
		return ( x>=0 && x<width && y>=0 && y<height );	
	}
}

}