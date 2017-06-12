using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackground : MonoBehaviour {

	Sprite[] logos;
	SpriteRenderer backgroundLogo;

	// Use this for initialization
	void Start () {
		logos = new Sprite[4];

		logos [0] = Resources.Load ("Sprites/school", typeof(Sprite)) as Sprite;
		logos [1] = Resources.Load ("Sprites/badge", typeof(Sprite)) as Sprite;
		logos [2] = Resources.Load ("Sprites/myface", typeof(Sprite)) as Sprite;
		logos [3] = Resources.Load ("Sprites/nsa", typeof(Sprite)) as Sprite;

		backgroundLogo = GameObject.Find ("BackgroundLogo").GetComponent<SpriteRenderer>();

		switch (LevelDifficulty.difficulty) {
		case 1:
			backgroundLogo.sprite = logos [0];
			break;
		case 2:
			backgroundLogo.sprite = logos [1];
			break;
		case 3:
			backgroundLogo.sprite = logos [2];
			break;
		case 4:
			backgroundLogo.sprite = logos [3];
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
