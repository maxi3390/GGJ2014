using UnityEngine;
using System.Collections;

public class Timer2 : MonoBehaviour {

	// Use this for initialization
	public float myTimer2;

	void Start () {
	}
	
	// Update is called once per frame

	void Update () {
		if(myTimer2 > 0){
			myTimer2 -= Time.deltaTime;
			GameObject.Find ("Text").guiText.text = "Tiempo restante: "+ myTimer2.ToString("F2");
		}
		if(myTimer2 <= 0){
			Debug.Log("GAME OVER");
			Application.LoadLevel("gameOver");
		}



	}


}
