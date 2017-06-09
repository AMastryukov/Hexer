using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour {

	public AudioSource slow;
	public AudioSource moderate;
	public AudioSource fast;
	public AudioSource crazy;

	// Use this for initialization
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
