/**
 * FTSWFOS - PlateformGenerator.cs
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

/*********************/
/***** GENERATOR *****/
/*********************/

public class PlatformGenerator : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public GameObject thePlatform;
	public Transform generationPoint;

	public float platformDistanceBetweenMin;
	public float plateformDistanceBetweenMax;

	public ObjectPooler theObjectPool;

	//PRIVATE
	//-------

	private float platformWidth;
	private float distanceBetween;

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

		this.plateformsGeneration ();

	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** GET COMPONENTS *****/
	/**************************/

	private void getComponents () {
		this.platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
	}

	/**************************************************/
	/**************************************************/

	/*********************************/
	/***** PLATEFORMS GENERATION *****/
	/*********************************/

	private void plateformsGeneration () {
		this.plateformFeed ();
	}

	/**************************************************/
	/**************************************************/

	/**************************/
	/***** PALTEFORM FEED *****/
	/**************************/

	private void plateformFeed() {

		if (this.isGenerationPointBehind ()) {
			this.generateNewPlatform ();
		}

	}

	/**************************************************/
	/**************************************************/

	/**************************************/
	/***** IS GENERATION POINT BEHIND *****/
	/**************************************/

	private bool isGenerationPointBehind () {

		if (this.transform.position.x < this.generationPoint.position.x) {
			return true;
		}

		return false;

	}

	/**************************************************/
	/**************************************************/

	/***********************************/
	/***** GENERATE A NEW PLATFORM *****/
	/***********************************/

	private void generateNewPlatform () {

		this.distanceBetween = Random.Range (this.platformDistanceBetweenMin, this.plateformDistanceBetweenMax);

		float xPosition = this.transform.position.x + this.platformWidth + this.distanceBetween;

		this.transform.position = new Vector3 (xPosition, this.transform.position.y, this.transform.position.z);

		GameObject newPlatform = theObjectPool.getPooledObject ();
		newPlatform.transform.position = this.transform.position;
		newPlatform.transform.rotation = this.transform.rotation;
		newPlatform.SetActive (true);

	}

}
