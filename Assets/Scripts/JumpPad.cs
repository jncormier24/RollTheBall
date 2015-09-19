using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

	public bool touching;
	public int xForce;
	public int upForce;
	public int zForce;
	public AudioSource pad;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			other.GetComponent<Rigidbody>().AddForce (xForce, upForce, zForce, ForceMode.Impulse);
			touching = true;
			pad.Play();
		} 
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			touching = false;
		} 
	}
}
