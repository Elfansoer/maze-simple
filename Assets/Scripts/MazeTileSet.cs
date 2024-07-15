using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elfansoer.Maze {

public class MazeTileSet : MonoBehaviour {
	public int tileSize;
	public GameObject tileNone;
	public GameObject tileUp;
	public GameObject tileUpRight;
	public GameObject tileUpDown;
	public GameObject tileUpDownRight;
	public GameObject tileAll;
	public GameObject[] specialTiles;
	public GameObject[] patternTiles;

	public GameObject[] GetBasicTiles() {
		GameObject[] ret = new GameObject[6];
		ret[0] = tileNone;
		ret[1] = tileUp;
		ret[2] = tileUpRight;
		ret[3] = tileUpDown;
		ret[4] = tileUpDownRight;
		ret[5] = tileAll;

		return ret;
	}

	public GameObject[] GetSpecialTiles() {
		return specialTiles;
	}
	public GameObject[] GetPatternTiles() {
		return patternTiles;
	}
}

}