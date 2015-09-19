using UnityEngine;
using System.Collections;
using System.IO;

public class WinSpheres : MonoBehaviour {

	public int rotateSpeed;
    private GameObject music;

    void Start() {
        music = GameObject.Find("Music");
        Cursor.visible = true;
    }

    void Update () {
		transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime, Space.World);
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
            Destroy(music);
            Application.LoadLevel ("_Main Menu");
		}

	}

    public void GoToURL(string url)
    {
        Application.OpenURL(url);

    }

}
