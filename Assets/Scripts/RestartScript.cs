using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

    private GameObject music;

    void Start() {
        music = GameObject.Find("Music");
    }

	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)){
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
            Destroy(music);
			Application.LoadLevel ("_Main Menu");	
		}

	}

}
