using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			scorescript.scoreValue = 0;
		}	else if (Input.GetKeyDown(KeyCode.H)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				scorescript.scoreValue = 0;
				PlayerControl.thief_enabled = true;
			}
	}
}
