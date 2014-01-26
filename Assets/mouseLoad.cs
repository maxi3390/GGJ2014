using UnityEngine;
using System.Collections;

public class mouseLoad : MonoBehaviour {

	public string quesito;

	void OnMouseDown(){
		if (string.Compare(quesito,"salir",true) != 0)
			Application.LoadLevel (quesito);
		else 
			Application.Quit ();
	}
}
