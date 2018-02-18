using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_MillWings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.back, 15* Time.deltaTime);
    }
}
