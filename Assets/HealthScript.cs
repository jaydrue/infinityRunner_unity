using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public static int healthValue;
	Text score;
	Color startScoreColor;
	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
		startScoreColor = score.color;
	}

	// Update is called once per frame
	void Update () {
		if (healthValue <= 1){
			score.color = Color.red;
		}
		else if (healthValue > 1){
			score.color = startScoreColor;
		}
		score.text = "HEALTH: " + healthValue;
	}
}
