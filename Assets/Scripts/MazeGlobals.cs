using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elfansoer.Maze {

public class M {
	// direction constants and methods
	public const int UP = 1;
	public const int DOWN = 4;
	public const int LEFT = 8;
	public const int RIGHT = 2;
	public const int ALL = 15;

	// common directional methods
	public static int[] iterator = {1, 2, 4, 8};
	public static int[] inverse = {0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15};
	public static int[] rotate = { 0, 2, 4, 6, 8, 10, 12, 14, 1, 3, 5, 7, 9, 11, 13, 15 };
	public static int[][] directions;
	static M() {
		int[] table0 = {};
		int[] table1 = { 1 };
		int[] table2 = { 2 };
		int[] table3 = { 1, 2 };
		int[] table4 = { 4 };
		int[] table5 = { 1, 4 };
		int[] table6 = { 2, 4 };
		int[] table7 = { 1, 2, 4 };
		int[] table8 = { 8 };
		int[] table9 = { 1, 8 };
		int[] table10 = { 2, 8 };
		int[] table11 = { 1, 2, 8 };
		int[] table12 = { 4, 8 };
		int[] table13 = { 1, 4, 8 };
		int[] table14 = { 2, 4, 8 };
		int[] table15 = { 1, 2, 4, 8 };
		directions = new int[][] {
			table0, table1, table2, table3, table4, table5, table6, table7, table8, table9, table10, table11, table12, table13, table14, table15,
		};
	}

	// bit operations
	public static int AddBit( int value, int bit ) {
		return value | bit;
	}
	public static int DelBit( int value, int bit ) {
		return value & (~bit);
	}
	public static bool HasBit( int value, int bit ) {
		return (value & bit) == bit;
	}

	// Vector2Int operations
	public static Vector2Int MoveVector( Vector2Int pos, int dir ) {
		switch(dir) {
			case UP:
				return pos + Vector2Int.up;
			case DOWN:
				return pos + Vector2Int.down;
			case LEFT:
				return pos + Vector2Int.left;
			case RIGHT:
				return pos + Vector2Int.right;
			default:
			return pos;
		}
	}

	public static void Move( ref Vector2Int pos, int dir ) {
		switch(dir) {
			case UP:
				pos.y++;
				break;
			case DOWN:
				pos.y--;
				break;
			case LEFT:
				pos.x--;
				break;
			case RIGHT:
				pos.x++;
				break;
		}
	}
}

}

