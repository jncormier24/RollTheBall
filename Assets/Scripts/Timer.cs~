using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer;
	public Text timerText;
	public bool outOfTime;

	// Use this for initialization
	void Start () {
		outOfTime = false;
		timerText.fontSize = 25;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("Exit Cylinder") != null){
			if (GameObject.Find("Exit Cylinder").GetComponent<ExitScript>().exited == false){
				timer -= Time.deltaTime;
			} 
		} else if (GameObject.Find("Exit Cylinder") == null){
			timer -= Time.deltaTime;
		}

		if (timer > 0){
			string seconds = timer.ToString("#.00");
			timerText.text = seconds;
		} else {
			outOfTime = true;
			timerText.text = ".00";
		}

		if (timer < 6){
			timerText.fontSize = 30;
			timerText.color = Color.red;
			timerText.fontStyle = FontStyle.Bold;

		}
	}
}
