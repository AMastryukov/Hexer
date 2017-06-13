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

	public static float volume;

	private static Soundtrack instance;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);

			// set the volume from the playerprefs
			volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider> ();

			if (PlayerPrefs.HasKey ("soundVolume")) {
				volume = PlayerPrefs.GetFloat ("soundVolume");
				volumeSlider.value = volume;
			} else {
				PlayerPrefs.SetFloat ("soundVolume", 0.5f);
			}

			SceneManager.sceneLoaded += SceneLoaded;
		} else if (instance != this) {
			Destroy (this.gameObject);
			return;
		}
	}

	void SceneLoaded (Scene scene, LoadSceneMode mode)
	{
		StopMusic ();

		volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider> ();
		volumeSlider.onValueChanged.AddListener (delegate {UpdateVolume ();});
		volumeSlider.value = volume;

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
		volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider> ();
		volume = volumeSlider.value;
		PlayerPrefs.SetFloat ("soundVolume", volume);

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
