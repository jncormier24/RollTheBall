using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level){
        GameObject music = GameObject.Find("Music");
        Destroy(music);
		Application.LoadLevel(level);

	}
}
