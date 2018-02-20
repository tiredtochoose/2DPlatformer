using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_WizrdBullet : MonoBehaviour {

    private GameObject player;
    public float speed;
    public float lifeTime;
    private float direction;
    public float damage;
    private float distance;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Dragon");
        Destroy(gameObject, lifeTime);
        direction = player.transform.position.x - transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (direction > 0)
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
        if (direction < 0)
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
        distance = Vector3.Distance(transform.position, player.transform.position);
//        print(distance);
        if (distance <= 0.5f)
        {
            
            player.GetComponent<Lesson5_PlayerHealth>().ReceivingDamage(damage);
            Destroy(gameObject);//убиваем снаряд           
        }
    }
}
