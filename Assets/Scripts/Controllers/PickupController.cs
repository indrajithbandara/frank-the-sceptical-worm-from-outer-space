/**
 * FTSWFOS - PickupController.cs
 *
 * @since       22.05.2017
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

public class PickupController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public int scoreToGive;

	//PRIVATE
	//-------

	private ScoreManager scoreManager;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.setValues ();
	}
	
	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		
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
		this.setScoreManager ();
	}

	/*****/
	/***** SCORE MANAGER *****/
	/*****/

	private void setScoreManager () {
		this.scoreManager = FindObjectOfType<ScoreManager> ();
	}

	/**************************************************/
	/**************************************************/

	/***************************/
	/***** CHECK COLLISION *****/
	/***************************/

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.name == "Player") {
			this.updateScore ();
		}

	}
		
	/**************************************************/
	/**************************************************/

	/************************/
	/***** UPDATE SCORE *****/
	/************************/

	private void updateScore() {
		this.scoreManager.addScore (this.scoreToGive);
		this.gameObject.SetActive (false);
	}

		
}