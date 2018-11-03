using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerControl : MonoBehaviour {

private Vector2 targetPos;
public float Yincrement;
public float bombSpeed;

public float speed;
public float maxHeight, minHeight;
public int health;
private float currentTimeinSeconds;
private double lastSecond;

public static bool thief_enabled = false;

public GameObject effect;
public GameObject gameOver;
public GameObject Thief_Spawner;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;

		if(thief_enabled){
			Thief_Spawner.SetActive(true);
			Debug.Log("thieves actived.");
		}
	}

	// Update is called once per frame
	void Update () {

		if (health <= 0){
			gameOver.SetActive(true);
			FinalScore.finalValue = scorescript.scoreValue;
			HIGHSCORE.value = FinalScore.finalValue;
			Destroy(gameObject);
		}

		transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
		{
			Instantiate(effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
		{
			Instantiate(effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
		}

		currentTimeinSeconds += Time.deltaTime;

		if (Math.Ceiling(currentTimeinSeconds) != lastSecond && currentTimeinSeconds > 4f){
				scorescript.scoreValue += 1;
				lastSecond = Math.Ceiling(currentTimeinSeconds);
		}

		HealthScript.healthValue = health;
	}

	public float getBombSpeed(){
		return bombSpeed;
	}
	public void setBombSpeed(float somespeed){
		bombSpeed = somespeed;
	}
}
