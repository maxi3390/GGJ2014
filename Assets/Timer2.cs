using UnityEngine;
using System.Collections;

public class Timer2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float myTimer2 = 3600f;

	void Update () {
		if(myTimer2 > 0){
			myTimer2 -= Time.deltaTime;
		}
		if(myTimer2 <= 0){
			Debug.Log("GAME OVER");
		}


		GameObject.Find ("Text").guiText.text = "Timer: "+ myTimer2.ToString("F2");
	}


}
