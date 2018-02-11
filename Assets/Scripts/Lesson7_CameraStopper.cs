using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_CameraStopper : MonoBehaviour {


    private GameObject cam;
    private float dist;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        dist = Vector3.Distance(transform.position, cam.transform.position);
        
	}
	
	// Update is called once per frame
	void Update () {
        print(dist);
       
            float x = cam.GetComponent<Lesson6_CameraBhv>().maxXAndY.x;
            x = 50f;
            cam.GetComponent<Lesson6_CameraBhv>().maxXAndY.x = x;



    }
}
