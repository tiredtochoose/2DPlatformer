using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Scrits : MonoBehaviour {

    // Use this for initialization
    //public GameObject GO;
    //public Camera Cam;
    public Transform target;
    public float speed, RotSpeed;
    public Vector3 My3DVector;
    public Quaternion StartPos;

   

	void Start () {

        StartPos = transform.rotation;


        //print(gameObject.name);

        //GO = GameObject.Find("GameObject");

        //Cam = GO.GetComponent<Camera>();
        ////Cam = GetComponent<Camera>();

        //print(Cam.orthographicSize);

        //Cam.allowHDR = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);

        transform.LookAt(target);
	}
}
