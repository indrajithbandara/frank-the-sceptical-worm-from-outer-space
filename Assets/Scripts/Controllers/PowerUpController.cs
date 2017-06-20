/**
 * FTSWFOS - PowerUpController.cs
 *
 * @since       20.06.2017
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

public class PowerUpController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public bool doublePoints;
	public bool safeMode;

	public float duration;

	//PRIVATE
	//-------

	private PowerUpManager powerUpManager;

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
		this.setPowerUpManager ();
	}

	/*****/
	/***** POWERUP MANAGER *****/
	/*****/

	private void setPowerUpManager () {
		this.powerUpManager = FindObjectOfType<PowerUpManager> ();
	}

	/**************************************************/
	/**************************************************/

	/*******************************/
	/***** ON TRIGGER ENTER 2D *****/
	/*******************************/

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player") {
			
			this.powerUpManager.activatePowerUp (this.doublePoints, this.safeMode, this.duration);

		}

		gameObject.SetActive (false);

	}

}
