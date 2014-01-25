using UnityEngine;
using System.Collections;

public class moveLeftRight : MonoBehaviour {
	public float speed = 5f;

	
	// Update is called once per frame
	void FixedUpdate () {
		/*if (Input.GetKeyDown(KeyCode.Space) && this.collider2D) {
			print ("Salta");
			Vector3 newScale =transform.localScale;
			transform.position += transform.up * 3f;
		}
		/*if (Input.GetKey(KeyCode.DownArrow)) {
			return;
			print ("Baja");
			Vector3 newScale =transform.localScale;
			//transform.position += - * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			print ("Mueve a la izquierda");
			Vector3 newScale =transform.localScale;
			transform.position += -transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			print ("Mueve a la derecha");
			Vector3 newScale =transform.localScale;
			transform.position += transform.right * speed * Time.deltaTime;
		}
		*/
	}
}