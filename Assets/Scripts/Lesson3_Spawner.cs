using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Spawner : MonoBehaviour {

    // Use this for initialization

    //Задание3 Реализовать спаунер противников.
    public float spawnTime;        // Время между спаунами
    public float spawnDelay; //задержка
    public GameObject[] enemies; // массив врагов 


    void Start()
    {
        
        // вызываем функцию Spawn с задержкой
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        // Instantiate a random enemy.
        int enemyIndex = Random.Range(0, enemies.Length); // создаем случайное число от 0 до длинны массива enemies
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation); // спавним элемент массива enemies с
                                                                                  //   индексом, полученным сточкой выше

    }
}
