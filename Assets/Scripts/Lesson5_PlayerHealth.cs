﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_PlayerHealth : MonoBehaviour {


    public float PlayersHealth;

    private float sliderValue;
    public float playerHP_Max = 10.0f;

    // Use this for initialization

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ReceivingDamage(float dmg)
    {
        PlayersHealth -= dmg;
        if (PlayersHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void OnGUI()
    {

        sliderValue = PlayersHealth;

        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, 10, 200, 100));
        GUI.Label(new Rect(0, 0, 50, 20), "Health: ");
        sliderValue = GUI.HorizontalSlider(new Rect(50, 7, 100, 30), sliderValue, 0.0f, playerHP_Max);
        GUI.EndGroup();

    }

    void Shoot()
    {
        transform.GetChild(0).GetComponent<Lesson3_Shooting1>().Shoot();

    }

}
