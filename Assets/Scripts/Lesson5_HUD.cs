using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_HUD : MonoBehaviour {
    
    private Lesson5_PlayerHealth PlayerHP; //текущее HP игрока
    private float sliderValue;// значение слайдера
    public float playerHP_Max;// всего хп игрока



    void OnGUI()
    {
        PlayerHP = transform.parent.GetComponent<Lesson5_PlayerHealth>(); // берем текущее значение здоровья из скрипта 
        sliderValue = PlayerHP.PlayersHealth; //присваиваем его бегунку
       
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, 10, 200, 100)); //делаем группу
        GUI.Label(new Rect(0, 0, 50, 20), "Health: "); // надпись
        sliderValue = GUI.HorizontalSlider(new Rect(50, 7, 100, 30), sliderValue, 0.0f, playerHP_Max); // сдайдер
        GUI.EndGroup(); // конец группы

    }

    
}
