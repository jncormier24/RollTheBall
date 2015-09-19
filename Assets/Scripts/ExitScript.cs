using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {
	
	private Rigidbody playerRB;
	private GameObject player;
	public float eB;
	private float eLX;
	private float eLZ;
	public bool exited;
	private AudioSource aud;
	private bool playedExitSound = false;
	private float dist;
    private Renderer playerRend;
    private GameObject music;


    // lerp to exit
    private Vector3 playerPos;
	private Vector3 exitPos;
	private float lerpTime;
	private float currentLerpTime;

	// OnEnable called when script's object is enabled
	void OnEnable () {
		eLX = gameObject.transform.position.x;
		eLZ = gameObject.transform.position.z;
		exited = false;
		aud = GetComponent<AudioSource> ();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerRend = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        music = GameObject.Find("Music");

    }

	// Update is called once per frame
	void Update () {
		if (player != null) {
			dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
			if (exited == false) {
				//if Vector 3 distance from exit is under eB, and then changes exited to true
				if (dist <= eB){
					if (playedExitSound == false){
						playedExitSound = true;
						aud.Play();
					}
					exited = true;
				}

			} else {
				//lerp to exit - start
				playerPos = player.transform.position; 
				exitPos = new Vector3 (eLX, player.transform.position.y, eLZ);
				lerpTime = 3f;
				currentLerpTime += Time.deltaTime;
				if (currentLerpTime > lerpTime) {
					currentLerpTime = lerpTime;
				}
				float perc = currentLerpTime / lerpTime;
				player.transform.position = Vector3.Lerp (playerPos, exitPos, perc); 
				// lerp to exit - end

				player.transform.rotation = Quaternion.identity;
				playerRB.velocity = Vector3.zero;
				playerRB.angularVelocity = Vector3.zero; 
				player.transform.localScale += new Vector3 (-0.3f * Time.deltaTime, 1.5f * Time.deltaTime, 0);

                // Fade out on entering exit cylinder
                if (exited == true)
                {
                    playerRend.material.color = new Color(playerRend.material.color.r, playerRend.material.color.g, playerRend.material.color.b, playerRend.material.color.a - 0.003f);
                }
  
                // Change Levels
                if (exited == true && player.transform.position.y >= transform.position.y + 3)
                {
                    if (Application.loadedLevel <= 20)
                    {
                        if (Application.loadedLevel + 1 >= GameControl.control.maxLevel)
                        {
                            GameControl.control.maxLevel = Application.loadedLevel + 1;
                        }
                        GameControl.control.levels = Application.loadedLevel + 1;
                    }
                    GameControl.control.Save();
                    Destroy(music);
                    Application.LoadLevel(GameControl.control.levels);
                }




            }
		}
	}
}