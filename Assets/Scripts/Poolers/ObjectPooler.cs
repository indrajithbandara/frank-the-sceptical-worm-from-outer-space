/**
 * FTSWFOS - ObjectPooler.cs
 *
 * @since       26.03.2017
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

/******************/
/***** POOLER *****/
/******************/

public class ObjectPooler : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public GameObject pooledObject;
	public int pooledAmount;

	List<GameObject> pooledObjects;

	//PRIVATE
	//-------

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {

		this.initPooledObjectsList ();
		this.fillPooledObjectsList ();

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

	/************************************/
	/***** INIT POOLED OBJECTS LIST *****/
	/************************************/

	private void initPooledObjectsList() {
		this.pooledObjects = new List<GameObject>();
	}

	/**************************************************/
	/**************************************************/

	/************************************/
	/***** FILL POOLED OBJECTS LIST *****/
	/************************************/

	private void fillPooledObjectsList() {

		for (int i = 0; i < this.pooledAmount; i++) {
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}

	}

}
