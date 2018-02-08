using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Projectile : MonoBehaviour
{

    // Use this for initialization

  
    public int Damage; //Урон
    public float Speed, LifeTime; //Жизнь и скорость снаряда
    Animator fireAnim;
    private Rigidbody2D rb;


    Vector3 Dir = new Vector3(0, 0, 0); //направление


    void Start()
    {
        fireAnim = transform.gameObject.GetComponent<Animator>();
        Destroy(gameObject, LifeTime); // убиваем снаряд через определенное время LifeTime (устанавливается через инспектор)
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {        
        transform.Translate(Vector2.right * Speed * Time.fixedDeltaTime); //перемещаем ракету
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Fire entered collision" + collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy") //при сталкновени с геймобжектосм с тэгом Enemy
        {
            fireAnim.SetTrigger("Explode");
            collision.GetComponent<Lesson3_EnemyWarrior>().Hurt(Damage);//вызываем функцию Hurt из скрипта Lesson3_MyEnemy
            //и передеаем значение дамага как аргумент
            Speed = 0;
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;


            print(rb.bodyType);
            

            //DestroyProjectile();
        }
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);//убиваем снаряд 
    }
}
