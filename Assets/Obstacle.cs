using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour {

	public int damage = 1;
	public float speed;
	private float rotationspeed;
	private int rotdirection;
	int rand;

	public GameObject effect;

	void Start(){
		if (this.tag == "Bomb")
		{
			rand = UnityEngine.Random.Range(0,360);
			transform.Rotate(0,0,rand,Space.Self);

			rotdirection = UnityEngine.Random.Range(-1,1);
			if(rotdirection==0){ rotdirection = 1; }

			rotationspeed = UnityEngine.Random.Range(20,200);
	}
	}

	private void Update(){
		transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
		if (this.tag == "Bomb")
		{
			transform.Rotate(0, 0, rotdirection * rotationspeed * Time.deltaTime,Space.Self);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){
			Instantiate(effect, transform.position, Quaternion.identity);

			//player takes damage
			other.GetComponent<PlayerControl>().health -= damage;
			if(other.GetComponent<PlayerControl>().health <= 0){
				other.GetComponent<PlayerControl>().health = 0;
			}

			// Debug.Log(other.GetComponent<PlayerControl>().health);
			Destroy(gameObject);
		}
	}
}
