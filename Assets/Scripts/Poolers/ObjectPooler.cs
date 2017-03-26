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

public class ObjectPool : MonoBehaviour {

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
		
	}

	/**************************************************/
	/**************************************************/

	/******************/
	/***** UPDATE *****/
	/******************/

	void Update () {
		
	}
}
