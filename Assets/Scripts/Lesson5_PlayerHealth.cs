using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_PlayerHealth : MonoBehaviour {

    [HideInInspector]
    public float PlayersHealth = 50.0f;

    // Use this for initialization

    public void PlayerHurt(float Dam)
    {
        PlayersHealth -= Dam;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
