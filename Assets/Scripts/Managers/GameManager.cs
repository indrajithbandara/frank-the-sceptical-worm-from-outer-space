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
	public ScoreManager scoreManager;
	public DeathMenu deathMenu;

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
		this.setPlatformStartPoint ();
		this.setPlayerStartPoint ();
		this.setScoreManager ();
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

	/*****/
	/***** SCORE MANAGER *****/
	/*****/

	private void setScoreManager() {
		this.scoreManager = FindObjectOfType<ScoreManager>();
	}

	/**************************************************/
	/**************************************************/

	/*******************/
	/***** RESTART *****/
	/*******************/

	public void restartGame() {
		//StartCoroutine ("restartGameCo");

		this.deactivatePlayerAndScore ();
		this.deathMenu.gameObject.SetActive (true);

	}

	/**************************************************/
	/**************************************************/

	/***************************/
	/***** RESTART GAME CO *****/
	/***************************/

	public IEnumerator restartGameCo() {

		this.deactivatePlayerAndScore ();
		yield return new WaitForSeconds (0.5f);
		this.reset();

	}

	/**************************************************/
	/**************************************************/

	/***************************************/
	/***** DEACTIVATE PLAYER AND SCORE *****/
	/***************************************/

	public void deactivatePlayerAndScore() {
		this.scoreManager.scoreIncreasing = false;
		this.thePlayer.gameObject.SetActive (false);
	}

	/**************************************************/
	/**************************************************/

	/*****************/
	/***** RESET *****/
	/*****************/

	public void reset() {

		this.deathMenu.gameObject.SetActive (false);
		this.platformList = FindObjectsOfType<PlatformDestroyer> ();

		for (int i = 0; i < this.platformList.Length; i++) {
			this.platformList [i].gameObject.SetActive (false);
		}

		this.thePlayer.transform.position = this.playerStartPoint;
		this.platformGenerator.position = this.platformStartPoint;

		this.thePlayer.gameObject.SetActive (true);

		this.scoreManager.scoreCount = 0;
		this.scoreManager.scoreIncreasing = true;

	}

}
