using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_Spikes : MonoBehaviour {

    private float speed;
    public float duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 200, Color.red, duration);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, duration, 1 << 9);
       

        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
        }

    }
}
