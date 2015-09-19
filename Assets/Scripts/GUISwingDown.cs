using UnityEngine;
using System.Collections;

public class GUISwingDown : MonoBehaviour {

	private bool rotating = true;
	public Vector3 rotatingFrom;
	private Vector3 rotatingTo;
	public float lerpTime;
	private float currentLerpTime;

	void Start(){
		rotatingTo = transform.eulerAngles;
		transform.eulerAngles = rotatingFrom;
		if (lerpTime == 0){
			Debug.Log ("Change the Lerp Time from ZERO");
		}
	}

	// Update is called once per frame
	void Update () {
		if (rotating){
			if (Vector3.Distance(rotatingFrom, rotatingTo) > 0.01f){
				transform.eulerAngles = rotatingFrom;
				currentLerpTime += Time.deltaTime;
				if (currentLerpTime > lerpTime) {
					currentLerpTime = lerpTime;
				}
				float perc = currentLerpTime / lerpTime;
				transform.eulerAngles = Vector3.Lerp (rotatingFrom, rotatingTo, perc);
			}
		} else {
			transform.eulerAngles = rotatingTo;
			rotating = false;
		}
	}
}
