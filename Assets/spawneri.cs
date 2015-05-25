using UnityEngine;
using System.Collections;

public class spawneri : MonoBehaviour {
	GameObject asteroidi;
	public int intervaali = 1;
	public int speed;
	int timer;
	// Use this for initialization
	void Start () {
		asteroidi = Resources.Load ("asteroidi") as GameObject;
		timer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < Time.time) {
			GameObject tmp = Instantiate(asteroidi,new Vector3(transform.position.x,transform.position.y,0),transform.rotation) as GameObject;
			asteroidi tmp2 = tmp.GetComponent<asteroidi>();
			tmp2.speed = speed;
			timer += intervaali;
		}
	
	}
}
