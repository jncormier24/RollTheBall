using UnityEngine;
using System.Collections;

public class ChaserSound : MonoBehaviour {

    private GameObject Player;
    private PlayerController playerScript;
    private bool playedSound;
    private AudioSource sound;


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerScript = Player.GetComponent<PlayerController>();
        sound = GetComponent<AudioSource>();
        playedSound = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerScript.countGold > 0 || playerScript.countSilver > 0)
        {
            if (playedSound == false)
            {
                sound.Play();
                playedSound = true;
            }
        }
    }
}
