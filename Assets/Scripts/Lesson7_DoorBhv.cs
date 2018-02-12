using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_DoorBhv : MonoBehaviour {

    //private GameObject lever;
    //private bool leverClosed;
    private GameObject player;
    private float speed = 2.0f;

    // Use this for initialization
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Dragon");
        //lever = GameObject.FindGameObjectWithTag("Lever");
    }	
	// Update is called once per frame
	void Update () {
        
        if (player.transform.position.x > 22.0f)
           GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
       
	}
}
