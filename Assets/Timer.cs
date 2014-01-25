using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	private float myTimer = 5.0f;

	void Update () {

				if (myTimer > 0) {
						myTimer -= Time.deltaTime;
				}
				if (myTimer <= 0) {
						Debug.Log ("GAME OVER");
				}
		}
}
