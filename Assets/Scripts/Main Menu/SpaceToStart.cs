using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class SpaceToStart : MonoBehaviour {

	private Text words;
	public GameObject levelSelectText;
    private GameObject music;


    // Use this for initialization
    void Start () {
		words = gameObject.GetComponent<Text> ();
		if (GameControl.control.maxLevel > 1) {
			words.text = "Press Space to Continue";
			levelSelectText.SetActive (true);
		} else {
			words.text = "Press Space to Start";
			levelSelectText.SetActive (false);
		}
        music = GameObject.Find("Music");

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();		
		}
		if (Input.GetKeyDown (KeyCode.L) && GameControl.control.maxLevel > 1) {
            Destroy(music);
            Application.LoadLevel ("zzLevelSelect");
		}
		if (Input.GetKeyDown (KeyCode.M) && File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			GameControl.control.maxLevel = 20;
            GameControl.control.secretLevel = 1;
		}
	}
}
