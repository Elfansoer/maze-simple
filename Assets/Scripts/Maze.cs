using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elfansoer.Maze {
class Maze {
	// Constants
	public const int MAP_TYPE = 1;
	// public const int MAP_TILE = 2;
	public const int MAP_SPECIAL = 3;

	public const int TYPE_NORMAL = 0;
	public const int TYPE_SPECIAL = 1;
	public const int TYPE_PATTERN = 2;
	public const int TYPE_HIDDEN = 3; // covered by unique tiles

	public static int UP = 1;
	public static int DOWN = 4;
	public static int LEFT = 8;
	public static int RIGHT = 2;
	public static int ALL = 15;

	// map fields
	public int[,] map { get; set; }
	public int[,] mapType { get; set; } // normal, big, special
	// public int[,] mapSpecialTile  { get; set; } // tile reference
	Dictionary<Vector2Int,UniqueTile> uniqueTiles;

	public int width { get; private set; }
	public int height { get; private set; }
	public int this[int x, int y] {
		get { return map[x,y]; }
		set { map[x,y] = value; }
	}
	public int this[Vector2Int p] {
		get { return map[p.x,p.y]; }
		set { map[p.x,p.y] = value; }		
	}
	public int this[int type, int x, int y] {
		get {
			switch(type) {
				case MAP_TYPE: return mapType[x,y];
				// case MAP_TILE: return mapSpecialTile[x,y];
				default: return map[x,y];
			}
		}
		set {
			switch(type) {
				case MAP_TYPE: mapType[x,y] = value; break;
				// case MAP_TILE: mapSpecialTile[x,y] = value; break;
				default: map[x,y] = value; break;
			}
		}
	}
	public int this[int type, Vector2Int p] {
		get {
			switch(type) {
				case MAP_TYPE: return mapType[p.x,p.y];
				// case MAP_TILE: return mapSpecialTile[p.x,p.y];
				default: return map[p.x,p.y];
			}
		}
		set {
			switch(type) {
				case MAP_TYPE: mapType[p.x,p.y] = value; break;
				// case MAP_TILE: mapSpecialTile[p.x,p.y] = value; break;
				default: map[p.x,p.y] = value; break;
			}
		}
	}
	public UniqueTile GetUniqueTile( int x, int y ) {
		return GetUniqueTile( new Vector2Int(x,y) );
	}
	public UniqueTile GetUniqueTile( Vector2Int c ) {
		UniqueTile s;
		uniqueTiles.TryGetValue( c, out s );

		return s;
	}

	// Constructor
	public Maze( int[,] m ) {
		map = m;
		width = m.GetLength(0);
		height = m.GetLength(1);

		mapType = new int[width,height];
		// mapSpecialTile = new int[width,height];

		uniqueTiles = new Dictionary<Vector2Int,UniqueTile>();
	}
	public void SetUniqueTile( int x, int y, UniqueTile s ) { 
		SetUniqueTile( new Vector2Int(x,y), s );
	}
	public void SetUniqueTile( Vector2Int c, UniqueTile s ) {
		uniqueTiles.Add( c, s );
	}

	// Properties
	public bool IsInBoundary( Vector2Int pos ) {
		return ( pos.x>=0 && pos.x<width && pos.y>=0 && pos.y<height );	
	}
}	

class UniqueTile {
	public int tileIndex;
	public int rotation;
	public Vector2 center;

	public UniqueTile( int t, int r, Vector2 c ) {
		tileIndex = t;
		rotation = r;
		center = c;
	}
}

}