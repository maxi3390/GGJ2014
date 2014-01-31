using UnityEngine;
using System.Collections;

public class mouseGeneric : MonoBehaviour {
	
	private Color color;
	public Color ColorNuevo;
	public GameObject go;
	// Use this for initialization
	void Start () {
		color = renderer.material.color;
	}
	
	void OnMouseEnter(){
		//cambiar el color del texto
		renderer.material.color = ColorNuevo;
		this.go.GetComponent<AudioSource>().Play ();
	}
	
	void OnMouseExit(){
		//cambiar el color del texto al anterior
		renderer.material.color = color;
	}
}
