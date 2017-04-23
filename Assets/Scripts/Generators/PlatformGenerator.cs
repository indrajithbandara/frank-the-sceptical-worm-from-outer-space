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
	//public GameObject[] thePlatforms;

	public Transform generationPoint;

	public float platformDistanceBetweenMin;
	public float plateformDistanceBetweenMax;

	public ObjectPooler[] theObjectPools;

	//PRIVATE
	//-------

	private float platformWidth;
	private float distanceBetween;

	private int platformSelector;

	private float[] platformWidths;

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
		//this.platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		this.platformWidths = new float[this.theObjectPools.Length];

		for (int i = 0; i < this.theObjectPools.Length; i++) {
			this.platformWidths[i] = this.theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

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

		if (this.isGenerationPointAhead ()) {
			this.generateNewPlatform ();
		}

	}

	/**************************************************/
	/**************************************************/

	/**************************************/
	/***** IS GENERATION POINT BEHIND *****/
	/**************************************/

	private bool isGenerationPointAhead () {

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
		this.platformSelector = Random.Range (0, this.theObjectPools.Length);

		float intermediatePosition = this.transform.position.x + (this.platformWidths [this.platformSelector] / 2);
		float xPosition = intermediatePosition + this.distanceBetween;

		this.transform.position = new Vector3 (xPosition, this.transform.position.y, this.transform.position.z);

		print (this.platformWidths [this.platformSelector]);

		//Instantiate (this.thePlatforms[this.platformSelector], this.transform.position, this.transform.rotation);

		GameObject newPlatform = this.theObjectPools[this.platformSelector].getPooledObject ();
		newPlatform.transform.position = this.transform.position;
		newPlatform.transform.rotation = this.transform.rotation;
		newPlatform.SetActive (true);

		this.transform.position = new Vector3 (this.transform.position.x + (this.platformWidths [this.platformSelector] / 2), this.transform.position.y, this.transform.position.z);


	}

}
