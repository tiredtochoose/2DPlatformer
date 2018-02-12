using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_DoorBhv : MonoBehaviour {

    private GameObject lever;
    private bool DoorCheck;

    private GameObject player;
    private float speed = 2.0f;
    public GameObject doorPos;
    


    // Use this for initialization
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Dragon");
        lever = GameObject.FindGameObjectWithTag("Lever");

        //doorPos.position = new Vector3(0.2f, 3.96f, 0);
    }	
	// Update is called once per frame
	void Update () {
        DoorCheck = lever.GetComponent<Lesson6_LeverBhv>().doorDown;

        if (player.transform.position.x > 22.0f)
           GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        if (!DoorCheck)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.position = Vector3.MoveTowards(transform.position, doorPos.transform.position, speed * Time.deltaTime);
        }
    }
}
