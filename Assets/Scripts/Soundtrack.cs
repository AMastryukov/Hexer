using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Soundtrack : MonoBehaviour {

	public AudioSource slow;
	public AudioSource moderate;
	public AudioSource fast;
	public AudioSource crazy;
	public AudioSource mainMenu;

	Slider volumeSlider;

	public static float volume = 0.5f;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		SceneManager.sceneLoaded += SceneLoaded;
		volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider> ();
	}

	void SceneLoaded (Scene scene, LoadSceneMode mode)
	{
		StopMusic ();

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

			volumeSlider.value = volume;
			mainMenu.Play ();
		}
	}

	public void StopMusic() {
		if (SceneManager.GetActiveScene().name == "MainMenuScene") {
			mainMenu.Stop ();
		} else if (SceneManager.GetActiveScene().name == "GameScene") {
			slow.Stop ();
			moderate.Stop ();
			fast.Stop ();
			crazy.Stop ();
		}
	}

	public void UpdateVolume() {
		volume = volumeSlider.value;

		slow.volume = volume;
		moderate.volume = volume;
		fast.volume = volume;
		crazy.volume = volume;
		mainMenu.volume = volume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
