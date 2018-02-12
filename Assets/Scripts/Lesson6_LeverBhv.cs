using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_LeverBhv : MonoBehaviour {

    private Animator anim;
    GameObject player;
    private float DistToPayer;
    public bool doorDown = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Dragon");
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        DistToPayer = Vector3.Distance(transform.position, player.transform.position);
        //print("Lever - Player dist is" + DistToPayer);
        if (DistToPayer < 1.0f)
        {
            anim.SetBool("SwitchOn", true);
            doorDown = false;
        }


    }
}
