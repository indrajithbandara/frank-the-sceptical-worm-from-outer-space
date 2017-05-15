/**
 * FTSWFOS - GameManager.cs
 *
 * @since       15.15.2017
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

/*******************/
/***** MANAGER *****/
/*******************/

public class GameManager : MonoBehaviour {

	/**********************/
	/***** PROPERTIES *****/
	/**********************/

	//PUBLIC
	//------

	public Transform platformGenerator;
	public PlayerController thePlayer;

	//PRIVATE
	//-------

	private Vector3 platformStartPoint;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** START *****/
	/*****************/

	void Start () {
		this.setValues ();
	}

	/******************/
	/***** UPDATE *****/
	/******************/
	
	/**************************************************/
	/**************************************************/

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
		this.setPlatformStartPoint ();
		this.setPlayerStartPoint ();
	}

	/*****/
	/***** PLATFORM START POINT *****/
	/*****/

	private void setPlatformStartPoint () {
		this.platformStartPoint = this.platformGenerator.position;
	}

	/*****/
	/***** PLAYER START POINT *****/
	/*****/

	private void setPlayerStartPoint() {
		this.playerStartPoint = thePlayer.transform.position;
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** RESTART *****/
	/*******************/

	public void restartGame() {
		StartCoroutine ("restartGameCo");
	}

	/**************************************************/
	/**************************************************/

	/***************************/
	/***** RESTART GAME CO *****/
	/***************************/

	public IEnumerator restartGameCo() {

		this.thePlayer.gameObject.SetActive (false);

		yield return new WaitForSeconds (0.5f);

		this.platformList = FindObjectsOfType<PlatformDestroyer> ();

		for (int i = 0; i < this.platformList.Length; i++) {
			this.platformList [i].gameObject.SetActive (false);
		}

		this.thePlayer.transform.position = this.playerStartPoint;
		this.platformGenerator.position = this.platformStartPoint;

		this.thePlayer.gameObject.SetActive (true);

	}

}
