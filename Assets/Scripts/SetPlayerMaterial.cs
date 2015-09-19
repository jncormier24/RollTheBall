﻿using UnityEngine;
using System.Collections;

public class SetPlayerMaterial : MonoBehaviour {

	public Material[] materials;
	private Renderer rend;

	// Use this for initialization
	void Start () {
	
		rend = GetComponent<Renderer>();
		//int rand = Random.Range(0,8);
		rend.material = materials[PlayerPrefs.GetInt("playerMat")];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
