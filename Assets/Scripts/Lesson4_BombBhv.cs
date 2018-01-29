using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_BombBhv : MonoBehaviour
{
    //4. Реализовать мины, который ставит игрок, наступая на которые они взрываются нанося урон и отталкивая все в радиусе поражения.
    public int startForce; //импкльс, который дается мине при спавне
    private Rigidbody2D rigidbody2d;  // Rigidbody этого объекта
    private Rigidbody2D enteredColliderRB; // Rigidbody объекта, 
    public float bombForce; // сила удара бомбы

    void Start () {
        
        //сделано для того, чтобы мина, которую ставит игрок, не ставилась за ним, а немного впереди от него
        rigidbody2d = GetComponent<Rigidbody2D>(); // в rigidbody2d кладем компонент rigidbody этого игрового объекта
        rigidbody2d.AddForce(Vector2.right * startForce, ForceMode2D.Impulse); // к нему применяет импульс равный startForce

        StartCoroutine(BombDetonation()); //начинаем квн.. корутину)


    }

    IEnumerator BombDetonation() // корутина детонации мины
    {
        yield return new WaitForSeconds(3.0f); //ждем 3 секунды

        GetComponent<CircleCollider2D>().enabled = true; // берем компонент мины CircleCollider2D, который является триггером и выключен по умолчанию в инспекрте, и включаем его
    }


    private void OnTriggerEnter2D(Collider2D enteredCollider) // что происходит, когда срабатывает триггер:
    {
       

        if (enteredCollider.gameObject.tag == "Enemy") // если таг объекта, который зашел в коллайдер-триггер мины, - Enemy, то...
        {
            enteredColliderRB = enteredCollider.GetComponent<Rigidbody2D>(); // его Rigidbody кладем в enteredColliderRB

            //пока отключила смерть, потому что тогда не видно, как их отбрасывает

            //enteredCollider.GetComponent<Lesson3_MyEnemy>().Health = 0; //убиваем врага при взрыве
            //enteredColliderRB.GetComponent<Lesson3_MyEnemy>().Health = 0;

            //Find a vector from the bomb to the enemy. 
            Vector3 deltaPos = enteredColliderRB.transform.position - transform.position;     // находим вектор от бомбы к врагу            
            enteredColliderRB.AddForce(deltaPos * bombForce, ForceMode2D.Impulse); // отбрасываем его в этом направлении с силой bombForce
        }

    }
    
    // Update is called once per frame
    void Update () {        

    }

}
