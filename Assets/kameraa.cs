using UnityEngine;
using System.Collections;

public class kameraa : MonoBehaviour {
	GameObject pelaaja;
	// Use this for initialization
	void Start () {
		pelaaja = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (pelaaja.transform.position.x, pelaaja.transform.position.y+1, transform.position.z);


	}
}
