using UnityEngine;
using System.Collections;

public class mouseGeneric : MonoBehaviour {
	
	private Color color;
	public Color ColorNuevo;
	
	// Use this for initialization
	void Start () {
		color = renderer.material.color;
	}
	
	void OnMouseEnter(){
		//cambiar el color del texto
		renderer.material.color = ColorNuevo;
	}
	
	void OnMouseExit(){
		//cambiar el color del texto al anterior
		renderer.material.color = color;
	}
}
