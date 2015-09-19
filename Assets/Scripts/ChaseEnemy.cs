using UnityEngine;
using System.Collections;

public class ChaseEnemy : MonoBehaviour {
	private NavMeshAgent Internal_Nav_Mesh_Agent;
	private GameObject Player;
	private PlayerController playerScript;




	void Start () {
		Internal_Nav_Mesh_Agent = GetComponent<NavMeshAgent>();
		Player = GameObject.FindGameObjectWithTag("Player");
		playerScript = Player.GetComponent<PlayerController>();
	}
	

	void Update () {
		if (playerScript.countGold > 0 || playerScript.countSilver > 0){
			if (Player != null){
				Internal_Nav_Mesh_Agent.SetDestination (Player.transform.position);
			} 
		}


	}
}
