using UnityEngine;
using System.Collections;

public class DisableTipPanel : MonoBehaviour {

	public Vector3 rotatingFrom;
	public Vector3 rotatingTo;
	public float lerpTime;
	private float currentLerpTime;
	private GameObject timer;
	private GameObject timerControl;

	void Awake(){
		timer = GameObject.Find("Timer");
		GameObject.Find("Timer").SetActive(false);
		if (GameObject.Find("TimerControl") != null){
			timerControl = GameObject.Find("TimerControl");
			GameObject.Find("TimerControl").SetActive(false);
			}
		rotatingTo = GetComponent<GUISwingDown>().rotatingFrom;
		rotatingFrom = transform.eulerAngles;
		if (lerpTime == 0){
			Debug.Log ("Change the Lerp Time from ZERO");
		}
		//Debug.Log (GetComponent<GUISwingDown>().rotatingFrom);
		//Debug.Log (rotatingFrom);
		//Debug.Log (rotatingTo);
		//Debug.Log (Vector3.Distance(rotatingFrom, rotatingTo));
	}

	void Update () {
		if (GameObject.Find("Player") != null) {

			//Debug.Log (GameObject.Find("Player").GetComponent<PlayerController>().disableTip);

				if (GameObject.Find("Player").GetComponent<PlayerController>().disableTip == true){
					if (timerControl != null){
						timer.SetActive(true);
						timerControl.SetActive(true);
					}
			//	if (Vector3.Distance(rotatingFrom, rotatingTo) > 0.01f){
			//		transform.eulerAngles = rotatingFrom;
			//		currentLerpTime += Time.deltaTime;
			//		if (currentLerpTime > lerpTime) {
			//			currentLerpTime = lerpTime;
			//		}
			//		float perc = currentLerpTime / lerpTime;
			//		transform.eulerAngles = Vector3.Lerp (rotatingFrom, rotatingTo, perc);
			//		Debug.Log ("Lerping!");
			//	}
			//} else {
				//	transform.eulerAngles = rotatingTo;
				//	rotating = false;
					gameObject.SetActive (false);
			}
		}
	}

}
