using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDifficulty : MonoBehaviour {

	public static int difficulty = 1;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void StartLevel() {
		SceneManager.LoadScene ("GameScene");
	}
}
