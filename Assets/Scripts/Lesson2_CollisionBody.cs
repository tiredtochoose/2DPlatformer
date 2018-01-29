using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2_CollisionBody : MonoBehaviour {

    // Use this for initialization

    public GameObject Floor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D" + collision.gameObject.name);
        Floor.SetActive(false);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
