﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//player movement variables
	private float speed = 10f;
	private float jumpForce = 25f;
	public bool grounded;
	private RaycastHit hit;
	private float dist;
	private Vector3 direction;
	private float airControlModifier = 0.5f;

	//UI Text
	public GameObject goldPanel;
	public Text goldCountText;
	public GameObject silverPanel;
	public Text silverCountText;
	public GameObject LevelWin;
	public Text winText;
	public Text levelNum;
	public GameObject tip;
	public bool disableTip;
	public int goldsToWin;
	public int silversToWin;

	//Variables for exiting level
	public Transform exit;
	private Rigidbody rb;
	public GameObject exitCylinder;

	//Audio Clips
	public AudioSource rolling;
	public AudioSource pickup;

	//internal stuff
	public int countGold;
	public int countSilver;

    //particle effects
	public GameObject explosion;
    public Transform goldBurst;
    public Transform silverBurst;

	//set Scene win condition
	void SetCountText () {
		silverCountText.text = "Silver Cubes: " + countSilver + " / " + silversToWin;
		goldCountText.text = "Gold Cubes: " + countGold + " / " + goldsToWin;
		if (countGold >= goldsToWin && countSilver >= silversToWin) {
			LevelWin.SetActive (true);
			winText.text = Application.loadedLevelName + " Complete\n Find the Exit";
			exit.gameObject.SetActive (true);

		}
	}

	// start Scene
	void Start ()
	{
        MusicController.musicControl.attemptCount = MusicController.musicControl.attemptCount + 1;

        if (Application.loadedLevel <= 20)
        {
            if (Application.loadedLevel >= GameControl.control.maxLevel)
            {
                GameControl.control.maxLevel = Application.loadedLevel;
            }
            GameControl.control.levels = Application.loadedLevel;
        }

        if (Application.loadedLevelName == "Secret Level") {
            GameControl.control.secretLevel = 1;
        }

		GameControl.control.Save ();
		Debug.Log ("GameControl levels is " + GameControl.control.levels);
		Debug.Log ("GameControl maxLevel is " + GameControl.control.maxLevel);
		rb = GetComponent<Rigidbody> ();
		countGold = 0;
		countSilver = 0;
		SetCountText ();
		goldPanel.SetActive (false);
		silverPanel.SetActive (false);
		LevelWin.SetActive (false);
		levelNum.text = Application.loadedLevelName;
		exit.gameObject.SetActive (false);
		explosion.gameObject.SetActive (false);
		rolling.volume = 0;
		rolling.Play();
		disableTip = false;
		grounded = false;
        AudioListener.volume = PlayerPrefs.GetInt("volume");
        Debug.Log("Audiolistener volume is " + AudioListener.volume);
        Cursor.visible = false;


    }

	void Update (){
		dist = 0.9f;
		direction = Vector3.down;
		if (Physics.Raycast (transform.position, direction, dist)) {
			grounded = true;
		} else {
			grounded = false;
		}

		if (GameObject.Find("TimerControl") != null){
			if (GameObject.Find("TimerControl").GetComponent<Timer>().outOfTime == true){
				explosion.gameObject.SetActive (true);
				explosion.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
				Destroy (gameObject);
			}
		}



		if (countGold == goldsToWin){
			GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("GoldRemoval");
			
			foreach(GameObject go in gameObjectArray)
			{
				go.SetActive (false);
			}
		}


		if (grounded == true) {
			rolling.volume = Mathf.Clamp01 (rb.velocity.magnitude / 10);
			rolling.pitch = Mathf.Clamp (rb.velocity.magnitude / 10, -3,3);
		} else {
			rolling.volume = 0;
		}

		// Jump with space bar
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			Vector3 movement = new Vector3 (0, jumpForce, 0);
			rb.AddForce (movement*speed);
		}

	}

	// update every physics frame
	void FixedUpdate ()
	{
		// get Axis input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//see if player is grounded, if not, modify the movement speed, and either way, add force to player
		if (grounded == true) {
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement*speed);
		}
		else {
			Vector3 movement = new Vector3 (moveHorizontal * airControlModifier, 0.0f, moveVertical * airControlModifier);
			rb.AddForce (movement*speed);
		}



		// Turn off tip once first cube is picked up
		if (countGold >= 1 || countSilver >= 1) {
			disableTip = true;
		}
    }




	// destroys tagged pickups, adds 1 to respective counter
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up Gold")) {
            Instantiate(goldBurst, other.gameObject.transform.position, Quaternion.identity);
            other.gameObject.SetActive (false);
			pickup.pitch = 1.5f;
			pickup.volume = 0.5f;
			pickup.Play ();
			countGold = countGold + 1;
			goldPanel.SetActive (true);
			SetCountText ();
		} 
		if 	(other.gameObject.CompareTag("Pick Up Silver")) {
            Instantiate(silverBurst, other.gameObject.transform.position, Quaternion.identity);
            other.gameObject.SetActive (false);
			pickup.pitch = 1.0f;
			pickup.volume = 0.5f;
			pickup.Play ();
			countSilver = countSilver +1;
			silverPanel.SetActive (true);
			SetCountText ();
		}

		// kill player if they touch an enemy
		if (other.gameObject.CompareTag ("Enemy") && exitCylinder.GetComponent<ExitScript> ().exited == false) {
			explosion.gameObject.SetActive (true);
			explosion.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			Destroy (gameObject);
			
		}
		//kill player if they fall out of the board
		if (other.gameObject.CompareTag ("Boundary")) {
			explosion.gameObject.SetActive (true);
			explosion.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			Destroy (gameObject);
		}

	}
		
	}