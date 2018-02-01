using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Projectile : MonoBehaviour
{

    // Use this for initialization

    public GameObject BOOM;
    public int Damage; //Урон
    public float Speed, LifeTime; //Жизнь и скорость снаряда

    Vector3 Dir = new Vector3(0, 0, 0); //направление


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
        
        transform.Translate(Vector2.right * Speed * Time.fixedDeltaTime); //перемещаем ракету
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //при сталкновени с геймобжектосм с тэгом Enemy
        {
            collision.GetComponent<Lesson3_MyEnemy>().Hurt(Damage);//вызываем функцию Hurt из скрипта Lesson3_MyEnemy
                                                                   //и передеаем значение дамага как аргумент
           //Instantiate(BOOM, transform.position, transform.rotation); // Спауним объект, который симулирует взрыв
            Destroy(gameObject);//убиваем снаряд 
           // Destroy(BOOM); -- не работает почему-то поэтому убрала :(
        }
    }
}
