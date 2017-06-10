using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soundtrack : MonoBehaviour {

	public AudioSource slow;
	public AudioSource moderate;
	public AudioSource fast;
	public AudioSource crazy;
	public AudioSource mainMenu;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		SceneManager.sceneLoaded += SceneLoaded;
	}

	void SceneLoaded (Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "GameScene") {
			mainMenu.Stop ();

			switch (LevelDifficulty.speed) {
			case 1:
				slow.Play ();
				break;
			case 2:
				moderate.Play ();
				break;
			case 3:
				fast.Play ();
				break;
			case 4:
				crazy.Play ();
				break;
			default:
				slow.Play ();
				break;
			}
		} else if (scene.name == "MainMenuScene") {
			slow.Stop ();
			moderate.Stop ();
			fast.Stop ();
			crazy.Stop ();

			mainMenu.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
