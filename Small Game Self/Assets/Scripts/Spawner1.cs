using UnityEngine;
using System.Collections;

public class Spawner1 : MonoBehaviour {
	private float rndber;
	private float scalemultiplier = 5.0f;

	public GameObject cube;
	public GameObject Cylinder;
	public GameObject resetter;
	public GameObject levelDown;

	public int numSpawn;
	public int minNum;
	public int Maxnum;

	public Transform[] perfab;
	public GameObject plane;
	// Use this for initialization
	public void Spawn(){

		for (int i = 0; i < numSpawn / 3; i++) {
		
			float rndX, rndZ;
			rndX = Random.Range (-plane.transform.localScale.x * scalemultiplier,plane.transform.localScale.x * scalemultiplier);
			rndZ = Random.Range (-plane.transform.localScale.z * scalemultiplier, plane.transform.localScale.z * scalemultiplier);
			rndber = Random.Range (0, minNum);
			Transform temp = (Transform)Instantiate (perfab [(int)rndber], new Vector3 (rndX, 2, rndZ), transform.rotation);
			switch ((int)rndber) {
			case 0:
				temp.transform.parent = resetter.transform;
				break;
			case 1:
				temp.transform.parent = levelDown.transform;
				break;
			}
		}
		for (int i = 0; i < numSpawn; i++) {
			float rendX, rndZ;
			rendX = Random.Range (-plane.transform.localScale.x * scalemultiplier, plane.transform.localScale.x * scalemultiplier);
			rndZ = Random.Range (plane.transform.localScale.z * scalemultiplier, plane.transform.localScale.z * scalemultiplier);

			rndber = Random.Range (minNum, Maxnum);
			Transform temp = (Transform)Instantiate (perfab [(int)rndber], new Vector3 (rendX, 2, rndZ), transform.rotation);

			switch ((int)rndber) {
			case 1:
				temp.transform.parent = cube.transform;
				break;
			case 2:
				temp.transform.parent = Cylinder.transform;
				break;

			}
		
		}

	}
	void Start () {
		Spawn ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
