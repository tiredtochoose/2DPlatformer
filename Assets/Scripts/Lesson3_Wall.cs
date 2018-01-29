using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D" + collision.gameObject.name);
        //Floor.SetActive(false);
        Destroy(collision.gameObject);
    }
}
