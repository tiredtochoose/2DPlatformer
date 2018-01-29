using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_MyEnemy : MonoBehaviour {

    //Задание4 - Пусть ваш снаряд отнимает жизни и убивает противников.
    public int Health; //Задаем количество жизней через инспект
    public float Speed; // Задаем скорость 
                        
    void Start () {
		
	}

    public void Hurt(int Damage) //функция Hurt, которая принимает аргумент Damage, прописанный в
                                 //Lesson3_Projectile, положенный на префаб Fire
    {
        Health -= Damage;  //Уменьшаем здоровье на дамаг              
    }

    // Update is called once per frame
    void Update () {
        
        transform.Translate(Vector2.right * Speed * Time.deltaTime); //перемещение врага
        
        if (Health < 1)
            Destroy(gameObject); // если здоровье становится меньше 0, враг умирает
    }
}
