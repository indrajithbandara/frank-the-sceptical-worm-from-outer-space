/**
 * FTSWFOS - PlayerController.cs
 *
 * @since       04.01.2017
 * @version     1.0.0.0
 * @author      MLB
 * @copyright   -
 */

/*******************/
/***** IMPORTS *****/
/*******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************/
/**************************************************/

/**********************/
/***** CONTROLLER *****/
/**********************/

public class PlayerController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public float moveSpeed;
	public float jumpForce;
	public float jumpTime;

	public bool isGrounded;

	public LayerMask theGround;

	//PRIVATE
	//-------

	private float jumpTimeCounter;

	private Collider2D playerCollider;

	private Rigidbody2D playerRigidbody;

	private Animator playerAnimator;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.getComponents ();
		this.setValues ();
	}

	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		this.moves ();
	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {
		this.playerRigidbody = GetComponent<Rigidbody2D> ();
		this.playerCollider = GetComponent<BoxCollider2D> ();
		this.playerAnimator = GetComponent<Animator> ();
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** SETTERS *****/
	/*******************/

	/*****/
	/***** SET VALUES *****/
	/*****/

	private void setValues () {
		this.setJumpTimeCounter (this.jumpTime);
	}

	/*****/
	/***** JUMP TIME COUNTER *****/
	/*****/

	private void setJumpTimeCounter (float time) {
		this.jumpTimeCounter = time;
	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** HORIZONTAL MOVEMENT *****/
	/*******************************/

	private void moves () {
		
		this.horizontalMovement ();
		this.jump ();

		playerAnimator.SetFloat ("Speed", this.playerRigidbody.velocity.x);
		playerAnimator.SetBool ("isGrounded", this.isGrounded);

	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** HORIZONTAL MOVEMENT *****/
	/*******************************/

	private void horizontalMovement () {
		this.playerRigidbody.velocity = new Vector2 (this.moveSpeed, this.playerRigidbody.velocity.y);
	}

	/**************************************************/
	/**************************************************/

	/****************/
	/***** JUMP *****/
	/****************/

	private void jump () {

		isGrounded = this.checkIfGrounded ();

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) && isGrounded) {
			this.doJump ();
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) {

			if (this.jumpTimeCounter > 0) {
				this.doJump ();
				this.jumpTimeCounter -= Time.deltaTime;
			}

		}
			
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) {
			this.setJumpTimeCounter (0);
		}

		if (isGrounded) {
			this.setJumpTimeCounter (this.jumpTime);
		}

	}

	/**************************************************/
	/**************************************************/

	/*****************************/
	/***** CHECK IF GROUNDED *****/
	/*****************************/

	private bool checkIfGrounded () {
		return Physics2D.IsTouchingLayers (this.playerCollider, this.theGround);
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** DO JUMP *****/
	/*******************/

	private void doJump () {
		this.playerRigidbody.velocity = new Vector2 (this.playerRigidbody.velocity.x, this.jumpForce);
	}

}
