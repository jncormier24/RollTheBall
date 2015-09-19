using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int levels;
	public int maxLevel;
    public int secretLevel;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control !=this){
            Debug.Log("new GameControl destroyed");
			Destroy(gameObject);
            return;
		}
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("volume", 1);
		Debug.Log ("GameControl levels/maxLevel " + GameControl.control.levels + "/" + GameControl.control.maxLevel);
    }


	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		data.levels = levels;
		data.maxLevel = maxLevel;
        data.secretLevel = secretLevel;
		bf.Serialize (file, data);
		Debug.Log ("Saved levels/maxLevel " + data.levels + "/" + data.maxLevel);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			levels = data.levels;
			maxLevel = data.maxLevel;
            secretLevel = data.secretLevel;
			Debug.Log ("Loaded levels/maxLevel " + data.levels + "/" + data.maxLevel);
		}
	}
}


[Serializable]
class PlayerData {

	public int levels;
	public int maxLevel;
    public int secretLevel;


}