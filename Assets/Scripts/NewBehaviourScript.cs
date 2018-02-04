using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Animator MyAnimCtrl;

    void Start()
    {
        MyAnimCtrl = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            MyAnimCtrl.SetInteger("Death", 1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            MyAnimCtrl.SetInteger("Death", 0);

        //if (Input.GetKeyDown(KeyCode.Q))
        //    MyAnimCtrl.SetFloat("Speed", 0);

        //if (Input.GetKeyDown(KeyCode.W))
        //    MyAnimCtrl.SetFloat("Speed", 0.5f);

        if (Input.GetKeyDown(KeyCode.E))
            MyAnimCtrl.SetFloat("Speed", 2.0f);
        if (Input.GetKeyUp(KeyCode.E))
            MyAnimCtrl.SetFloat("Speed", 0f);

    }
    public void AnimStarted()
    {
        //print("Animation has started");

    }

    public void AnimEnded()
    {
       // print("Animation has ended");
    }
}
