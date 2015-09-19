using UnityEngine;
using System.Collections;

public class MainMenuBall : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, 20 * Time.deltaTime, Space.World);
	}
}
