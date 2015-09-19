using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Attempts : MonoBehaviour {

    private Text attemptText;

    void Start()
    {
        attemptText = GameObject.Find("Attempts Count").GetComponent<Text>();

    }

    void Update()
    {
        if (MusicController.musicControl.attemptCount == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            attemptText.text = ("Attempts " + MusicController.musicControl.attemptCount);
        }

    }
}
