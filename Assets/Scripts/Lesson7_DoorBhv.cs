using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_DoorBhv : MonoBehaviour {

    private GameObject lever;
    private bool leverClosed;
    private GameObject player;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Dragon");
        lever = GameObject.FindGameObjectWithTag("Lever");
    }	
	// Update is called once per frame
	void Update () {

        leverClosed = lever.GetComponent<Lesson6_LeverBhv>().closed;

        if (player.transform.position.x > 22.0f)
             anim.SetBool("Down", true);

        //if (!leverClosed)
        //    anim.SetBool("Down", false);
	}
}
