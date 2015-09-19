using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

    public bool mute = false;


    public void MuteSound()
    {
        mute = !mute;
        Debug.Log(mute);
        if (mute == true) {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("volume", 0);
            Debug.Log("Setting volume to " + PlayerPrefs.GetInt("volume"));
        } else if (mute == false) {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("volume", 1);
            Debug.Log("Setting volume to " + PlayerPrefs.GetInt("volume"));
        }

    }
}
