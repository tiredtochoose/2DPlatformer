using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_Spikes : MonoBehaviour {

    private float speed;
    private float distance;
    private Rigidbody2D rbSpike;
    private Vector2 rayVertPos;
    private Vector2 rayHorisPos;
    private GameObject player;
    private float damage;

    // Use this for initialization
    void Start () {
        distance = 10;
        rbSpike = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Dragon");
        damage = 8;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        rayVertPos.x = transform.position.x + 0.5f;
        rayVertPos.y = transform.position.y;

        rayHorisPos.x = transform.position.x - 0.5f;
        rayHorisPos.y = transform.position.y - 0.5f;


        Debug.DrawRay(rayVertPos, Vector3.down * distance, Color.cyan);
        RaycastHit2D spikeFall = Physics2D.Raycast(rayVertPos, Vector2.down, distance, 1 << 9);
       
        if (spikeFall.collider != null)
        {
            //print(spikeFall.collider.gameObject.name);
            rbSpike.bodyType = RigidbodyType2D.Dynamic;


            Debug.DrawRay(rayHorisPos, Vector3.right, Color.red);
            RaycastHit2D hitKill = Physics2D.Raycast(rayHorisPos, Vector2.right, 1, 1 << 9);

            if (hitKill.collider != null)
            {
                print("Red ray " + hitKill.collider.gameObject.name);
                //player.GetComponent<Lesson5_PlayerHealth>().ReceivingDamage(damage);

                player.GetComponent<Animator>().SetBool("Die_Bool", true);

            }

        }


        
        


    }
}
