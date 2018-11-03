﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speedmultiplier;
	private float speed;
	public float jumpForce;
	private float moveInput;
	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpValue;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		extraJumps = extraJumpValue;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		moveInput = Input.GetAxis("Horizontal");
		// Debug.Log(moveInput);
		rb.velocity = new Vector2(speed = moveInput * speedmultiplier, rb.velocity.y);

		if(facingRight == false && moveInput > 0) {Flip();}
		else if(facingRight == true && moveInput < 0){Flip();}
	}

	void Update(){

		if(isGrounded == true){
			extraJumps = extraJumpValue;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
			rb.velocity = Vector2.up * jumpForce;
		}

	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
