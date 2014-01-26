using UnityEngine;
using System.Collections;
//using Assets.Scripts;

public class distanciaSalida : MonoBehaviour {
	public Transform gato;							// traemos el gato
	public Light luz;								// traemos la luz
	public float minimaDistancia = float.MaxValue;
	public Camera camara;							// traemos la camara
	private TiltShiftHdr efecto;

	// Use this for initialization
	void Start () {
		efecto = camara.GetComponent <TiltShiftHdr> ()/* as TiltShiftHdr*/;
		//efecto.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		// This script calculates where the caraj is the cat
		//float distancia = Mathf.Sqrt(pow(gato.position.x-
		float distancia = Vector2.Distance (gato.position, this.transform.position);
		if (distancia < minimaDistancia) {
						minimaDistancia = distancia;
		}

		// ahora seteamos la luminosidad en funcion de la distancia

		float intensidad = (1 / (distancia));
		if (intensidad > 1)
			luz.intensity = 1;
		elserr
			luz.intensity = intensidad;

		if (Input.GetKeyDown (KeyCode.E)) {
			efecto.enabled = !efecto.enabled;
		}
		efecto.blurArea=distancia*3;
		efecto.maxBlurSize = 6;


		//print (luz.intensity);
	}
}
