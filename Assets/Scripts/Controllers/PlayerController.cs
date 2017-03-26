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

	public bool isGrounded;

	public LayerMask theGround;



	//PRIVATE
	//-------

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

	/*******************************/
	/***** HORIZONTAL MOVEMENT *****/
	/*******************************/

	private void moves () {
		
		this.horizontalMovement ();
		this.jump ();

		playerAnimator.SetFloat ("Speed", playerRigidbody.velocity.x);
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

		isGrounded = Physics2D.IsTouchingLayers (playerCollider, theGround);

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) && isGrounded) {
			this.playerRigidbody.velocity = new Vector2 (this.playerRigidbody.velocity.x, this.jumpForce);
		}

	}

}
