using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_PlayerHealth : MonoBehaviour {


    public float PlayersHealth;

    private float sliderValue;
    public float playerHP_Max = 10.0f;
    private Animator anim;


    // Use this for initialization

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ReceivingDamage(float dmg)
    {
        PlayersHealth -= dmg;
        anim.SetBool("Hurt", true);
        if (PlayersHealth <= 0)
              anim.SetBool("Die_Bool", true);
    }

    void HurtAnimOff()
    {
        anim.SetBool("Hurt", false);
    }

    void Die()
    {
        Destroy(gameObject); //вызывается из анимации
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
        transform.GetChild(0).GetComponent<Lesson3_Shooting>().Shoot();
    }

}
