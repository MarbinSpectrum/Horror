using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour {

    public GameObject Door;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.position = new Vector3(Door.transform.position.x + 6f, transform.position.y, transform.position.z);
	}
}
