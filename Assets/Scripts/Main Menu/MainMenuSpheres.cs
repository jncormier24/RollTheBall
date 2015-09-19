using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenuSpheres : MonoBehaviour {

	private bool rotateLeft = false;
	private bool rotateRight = false;
	private Vector3 rotatingFrom;
	private Vector3 rotatingTo;
	public float rotateSpeed;
	private float materialFloat;
	public int materialChoice;
    private GameObject music;


	void Start () {
		GameControl.control.Load ();
        AudioListener.volume = PlayerPrefs.GetInt("volume");
		if (rotateSpeed == 0){
			Debug.Log ("Change the rotateSpeed from ZERO");
		}
		rotatingTo = new Vector3 (0, 0, 0);
		Cursor.visible = true;
        music = GameObject.Find("Music");
    }
	
	// Update is called once per frame
	void Update () {

		materialFloat = rotatingTo.y / 45;
		materialChoice = Mathf.RoundToInt (materialFloat);

		if (Input.GetKeyDown (KeyCode.LeftArrow) && rotateLeft == false && rotateRight == false) {
			rotatingFrom = transform.rotation.eulerAngles;
			rotateLeft = true;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && rotateRight == false && rotateLeft == false) {
			rotatingFrom = transform.rotation.eulerAngles;
			rotateRight = true;
		}

        if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("pressed space on start screen");
            Destroy(music);
            if (materialChoice == 8){
				materialChoice = 0;
			}
			PlayerPrefs.SetInt("playerMat", materialChoice);
			if (GameControl.control.maxLevel > 1) {
				int i = GameControl.control.levels;
				Application.LoadLevel(i);
			} else{	
				Application.LoadLevel(1);
			} 
		}

        if (rotateLeft == true){
			transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
			if (transform.rotation.eulerAngles.y >= rotatingFrom.y + 45){
				transform.eulerAngles = new Vector3 (0, rotatingFrom.y + 45, 0);
				rotatingTo = new Vector3 (0, rotatingFrom.y + 45, 0);
				rotateLeft = false;
			}
			if (transform.rotation.eulerAngles.y >= 359){
				transform.eulerAngles = new Vector3 (0, 0, 0);
				rotatingTo = new Vector3 (0, rotatingFrom.y + 45, 0);
				rotateLeft = false;
			}
		}

		if (rotateRight == true){
			transform.Rotate (Vector3.down * Time.deltaTime * rotateSpeed);
			if (rotatingFrom == new Vector3 (0,0,0)){
				rotatingFrom = new Vector3 (0,360,0);
			}
			if (transform.rotation.eulerAngles.y <= rotatingFrom.y - 45){
				transform.eulerAngles = new Vector3 (0, rotatingFrom.y - 45, 0);
				rotatingTo = new Vector3 (0, rotatingFrom.y - 45, 0);
				rotateRight = false;
			}
			if (transform.rotation.eulerAngles.y <= 1){
				transform.eulerAngles = new Vector3 (0, 0, 0);
				rotatingTo = new Vector3 (0, rotatingFrom.y - 45, 0);
				rotateRight = false;
			}
		}

	}


    public void OpenURL(string url)
    {
        
        Application.OpenURL(url);

    }



}
