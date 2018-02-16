using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_WizrdBullet : MonoBehaviour {

    private GameObject player;
    public float speed;
    public float lifeTime;



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Dragon");
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Fire entered collision" + collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy") //при сталкновени с геймобжектосм с тэгом Enemy
        {

            collision.GetComponent<Lesson3_EnemyWarrior>().Hurt(Damage);//вызываем функцию Hurt из скрипта Lesson3_MyEnemy
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);//убиваем снаряд 
            //DestroyExplosion();
        }

    }
}
