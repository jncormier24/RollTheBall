using UnityEngine;
using System.Collections;
using System.IO;

public class LSSpheres : MonoBehaviour {

    private GameObject music;
    public int rotateSpeed; 
	public GameObject L1;
	public GameObject L2;
	public GameObject L3;
	public GameObject L4;
	public GameObject L5;
	public GameObject L6;
	public GameObject L7;
	public GameObject L8;
	public GameObject L9;
	public GameObject L10;
	public GameObject L11;
	public GameObject L12;
	public GameObject L13;
	public GameObject L14;
	public GameObject L15;
	public GameObject L16;
	public GameObject L17;
	public GameObject L18;
	public GameObject L19;
	public GameObject L20;
    public GameObject SL;

	void Awake() {
		L1.SetActive (false);
		L2.SetActive (false);
		L3.SetActive (false);
		L4.SetActive (false);
		L5.SetActive (false);
		L6.SetActive (false);
		L7.SetActive (false);
		L8.SetActive (false);
		L9.SetActive (false);
		L10.SetActive (false);
		L11.SetActive (false);
		L12.SetActive (false);
		L13.SetActive (false);
		L14.SetActive (false);
		L15.SetActive (false);
		L16.SetActive (false);
		L17.SetActive (false);
		L18.SetActive (false);
		L19.SetActive (false);
		L20.SetActive (false);
        SL.SetActive (false);

		Debug.Log ("GameControl levels is " + GameControl.control.levels);
		Debug.Log ("GameControl maxLevel is " + GameControl.control.maxLevel);

	}

	void Start (){
        music = GameObject.Find("Music");

        if (GameControl.control.maxLevel >= 1){
			L1.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 2){
			L2.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 3){
			L3.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 4){
			L4.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 5){
			L5.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 6){
			L6.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 7){
			L7.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 8){
			L8.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 9){
			L9.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 10){
			L10.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 11){
			L11.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 12){
			L12.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 13){
			L13.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 14){
			L14.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 15){
			L15.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 16){
			L16.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 17){
			L17.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 18){
			L18.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 19){
			L19.SetActive (true);
		}
		if (GameControl.control.maxLevel >= 20){
			L20.SetActive (true);
		}
        if (GameControl.control.secretLevel == 1) {
            SL.SetActive(true);
        }
		Cursor.visible = true;


	}


	void Update () {
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
		if (Input.GetKeyDown (KeyCode.Space)) {
            Destroy(music);
            int i = GameControl.control.levels;
			Application.LoadLevel(i);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
            Destroy(music);
            Application.LoadLevel ("_Main Menu");
		}

	}
}
