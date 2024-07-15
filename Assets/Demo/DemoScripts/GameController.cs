using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Don't forget to use this
using Elfansoer.Maze;

public class GameController : MonoBehaviour {
	public GameObject player;
	int gameWidth = 10;
	int gameHeight = 10;

	Vector3 position;
	ElfansoerMazeSimple maze;

	// Use this for initialization
	void Start () {
		// Add ElfansoerMazeSimple Component
		maze = gameObject.AddComponent<ElfansoerMazeSimple>();

		// Set maze parameter
		maze.width = gameWidth;
		maze.height = gameHeight;
		// maze.seed = 0 // default value is zero

		// Set tileset
		maze.tileSet = Resources.Load<GameObject>("Prefabs/BasicTileset/BasicTileset");

		// build maze
		maze.Build();

		// init player
		position = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distance = Vector3.Distance(position, player.transform.position);

		// if player's distance from previous reset is more than 100, reset maze
		if (distance>100) {
			// store position
			position = player.transform.position;

			// reset maze
			maze.Generate();
		}
	}
}
