﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

		float speed = 4f;
		Vector3 moveLeft = new Vector3(-1,0,0);
		Vector3 moveRight = new Vector3(1,0,0);
		Vector3 moveUp = new Vector3(0,1,0);
		Vector3 moveDown = new Vector3(0,-1,0);

	Animator animator;
	public void Start()
	{
		animator = GetComponent<Animator>();
	}
		void Update() {
		transform.eulerAngles = new Vector3(0, 0, 0);//fix barrier bug
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += moveLeft * Time.deltaTime*speed; //x,y,z
			sr.flipX = false;
			animator.SetBool ("isWalking", true);
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			transform.position += moveUp * Time.deltaTime*speed; //x,y,z
			animator.SetBool ("isWalking", true);
		}

		if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			transform.position += moveDown * Time.deltaTime*speed; //x,y,z
			animator.SetBool ("isWalking", true);
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.position += moveRight * Time.deltaTime*speed; //x,y,z
			sr.flipX = true;
			animator.SetBool ("isWalking", true);
		}
		//if the player is not moving
		if(!(Input.GetKey(KeyCode.W))&&!(Input.GetKey(KeyCode.A))&&!(Input.GetKey(KeyCode.S))&&!(Input.GetKey(KeyCode.D)))
		{
			if(!(Input.GetKey(KeyCode.UpArrow))&&!(Input.GetKey(KeyCode.LeftArrow))&&!(Input.GetKey(KeyCode.DownArrow))&&!(Input.GetKey(KeyCode.RightArrow))){
			animator.SetBool ("isWalking", false);
			}
		}
			
		speed = 4f; //in case player is done hitting barrier
		}
		
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Barrier") {
			speed = 0;
		}
	}

	}
