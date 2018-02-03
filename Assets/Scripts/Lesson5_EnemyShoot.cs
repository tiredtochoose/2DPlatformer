using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_EnemyShoot : MonoBehaviour
{


    public float LifeTime;
    public float Speed;
    public float AttackDamage;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, LifeTime); // убиваем снаряд через определенное время LifeTime (устанавливается через инспектор)
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("enemy's bullet entered collision" + collision.gameObject.name);
        if (collision.gameObject.tag == "Player") //при сталкновени с геймобжектосм с тэгом Enemy
        {
            collision.GetComponent<Lesson5_PlayerHealth>().ReceivingDamage(AttackDamage);//вызываем функцию Hurt из скрипта Lesson3_MyEnemy
                                                                                         //и передеаем значение дамага как аргумент
                                                                                         //Instantiate(BOOM, transform.position, transform.rotation); // Спауним объект, который симулирует взрыв
            Destroy(gameObject);//убиваем снаряд 
                                // Destroy(BOOM); -- не работает почему-то поэтому убрала :(

        }

    }
}