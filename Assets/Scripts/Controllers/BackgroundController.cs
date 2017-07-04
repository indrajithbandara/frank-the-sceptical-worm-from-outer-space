/**
 * FTSWFOS - BackgroundController.cs
 *
 * @since       13.01.2017
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

public class BackgroundController : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public float smoothing;

	public Transform fixedBackground;
	public Transform[] backgrounds;

	//PRIVATE
	//-------

	private float[] parallaxScales;

	private Vector3 lastFixedBackgroundPosition;
	private Vector3 previousCameraPosition;

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

	/***********************/
	/***** LATE UPDATE *****/
	/***********************/

	void LateUpdate () {
		this.manageBackgrounds ();
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

		this.setPreviousCameraPosition ();
		this.setParallaxScales ();

	}

	/*****/
	/***** PREVIOUS CAMERA POSITION *****/
	/*****/

	private void setPreviousCameraPosition () {
		this.previousCameraPosition = this.transform.position;
	}

	/*****/
	/***** PARALLAX SCALES *****/
	/*****/

	private void setParallaxScales () {
		
		this.parallaxScales = new float[this.backgrounds.Length];

		for (int i = 0; i < this.parallaxScales.Length; i++) {
			this.parallaxScales [i] = this.backgrounds [i].position.z * -1;
		}

	}

	/**************************************************/
	/**************************************************/

	/******************************/
	/***** MANAGE BACKGROUNDS *****/
	/******************************/

	private void manageBackgrounds() {

		this.moveFixedBackground ();
		this.moveBackgrounds ();
		this.setPreviousCameraPosition ();

	}

	/**************************************************/
	/**************************************************/

	/*********************************/
	/***** MOVE FIXED BACKGROUND *****/
	/*********************************/

	private void moveFixedBackground() {
		
		float distanceToMoveX = this.transform.position.x;

		this.fixedBackground.transform.position = new Vector3 (distanceToMoveX, this.fixedBackground.transform.position.y, this.fixedBackground.transform.position.z);

	}

	/**************************************************/
	/**************************************************/

	/****************************/
	/***** MOVE BACKGROUNDS *****/
	/****************************/

	private void moveBackgrounds() {

		for (int i = 0; i < this.backgrounds.Length; i++) {
			 
			Vector3 parallax = (this.previousCameraPosition - this.transform.position) * (this.parallaxScales[i] / this.smoothing);
			this.backgrounds[i].position = new Vector3 (this.backgrounds[i].position.x + parallax.x, this.backgrounds[i].position.y + parallax.y, this.backgrounds[i].position.z);

		}
			
	}

}
