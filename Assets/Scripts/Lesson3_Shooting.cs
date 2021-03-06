﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_Shooting : MonoBehaviour
{
    //>>>>>>>>>>>>>this script lies on Dragon's Gun<<<<<<<<<<<<<<<<<<<<<<

    //Задание2 -  Реализовать стрельбу.
    //public Transform SpawnPos; //точка, в которм будет сауниться снаряд
    public GameObject Bullet; //создаем объект, в который через инспектор кладем ссылку на префаб Fire
    public GameObject BombInst; //создаем объект, в который через инспектор кладем ссылку на префаб Bomb
    public Transform parent;
    private Animator animator;

    void Start()
    {
        animator = transform.root.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) // Если нажата кнопка выстрела                                          
        {
            animator.SetBool("Attack_Bool", true); // в анимации стоит ивент, вызывающий метод Shoot
        }
        if (Input.GetButtonUp("Fire1"))
            animator.SetBool("Attack_Bool", false);

        //4. Реализовать мины, который ставит игрок, наступая на которые они взрываются нанося урон и 
        //отталкивая все в радиусе поражения.

        if (Input.GetButtonDown("Fire2")) // Если нажата вторая кнопка выстрела 
            Instantiate(BombInst, transform.position, transform.rotation); // Создаем бомбу в точке SpawnPos
    }

    public void Shoot() //функция, вызываемая в анимации по ивенту 
    {
        Instantiate(Bullet, parent); // родить снаряд
    }
}
