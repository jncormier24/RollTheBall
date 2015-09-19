using UnityEngine;
using System.Collections;

public class SlideEnemy : MonoBehaviour {

	private Vector3 startPoint;
	public Vector3 endPoint;
	public float speed;


	IEnumerator Start()
	{
		var startPoint = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, startPoint, endPoint, speed));
			yield return StartCoroutine(MoveObject(transform, endPoint, startPoint, speed));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPoint, Vector3 endPoint, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPoint, endPoint, i);
			yield return null; 
		}
	}
}