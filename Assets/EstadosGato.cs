using UnityEngine;
using System.Collections;

public class EstadosGato : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
						this.GetComponent<Animator> ().SetBool ("isSaltando", false);
						this.GetComponent<Animator> ().SetBool ("isCaminando", true);
				} else {
						if (Input.GetKey (KeyCode.Space)) {
								this.GetComponent<Animator> ().SetBool ("isCaminando", false);
								this.GetComponent<Animator> ().SetBool ("isSaltando", true);
						} else {
								this.GetComponent<Animator> ().SetBool ("isCaminando", false);
								this.GetComponent<Animator> ().SetBool ("isSaltando", false);
						}
				}

	}
}
