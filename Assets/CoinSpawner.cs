using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public GameObject[] bombPattern;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;


	// Update is called once per frame
	void Update () {

		if(scorescript.scoreValue >= 10){
			if(timeBtwSpawn <= 0)
			{
				int rand = Random.Range(0, bombPattern.Length);
				Instantiate(bombPattern[rand], transform.position, Quaternion.identity);
				timeBtwSpawn = startTimeBtwSpawn;

				timeBtwSpawn += Random.Range(0,5);

				if(startTimeBtwSpawn > minTime){
					startTimeBtwSpawn -= decreaseTime;
				}
			}
			else
			{
				timeBtwSpawn -= Time.deltaTime;
			}
		}
	}
}
