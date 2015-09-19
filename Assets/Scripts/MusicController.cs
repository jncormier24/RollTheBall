using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {
    public static MusicController musicControl;

    public GameObject attempts;
    public int attemptCount;
    

    void Awake()
    {
        if (musicControl == null)
        {
            DontDestroyOnLoad(gameObject);
            musicControl = this;
        }
        else if (musicControl != this)
        {
            Destroy(gameObject);
        }
        attemptCount = 0;

    }

 }
