using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	public GameObject levelDeathPanel;
	private Vector3 offset;

	void Start (){
		levelDeathPanel.SetActive (false);
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 10);
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {

		if (player != null) {
			transform.position = player.transform.position + offset;
		} else {
			levelDeathPanel.SetActive (true);
		}
		
	}		



}
