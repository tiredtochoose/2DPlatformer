using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wazard_Bhv : MonoBehaviour {

    public GameObject Projectile;
    public Transform SpawnPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shoot()
    {
        Instantiate(Projectile, SpawnPos);

    }
}
