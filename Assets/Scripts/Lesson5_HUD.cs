using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_HUD : MonoBehaviour {
    
    private Lesson5_PlayerHealth PlayerHP;
    private float sliderValue;
    public float playerHP_Max;



    void OnGUI()
    {
        //PlayerHP = transform.root.GetComponent<Lesson5_PlayerHealth>();
        //sliderValue = PlayerHP.PlayersHealth;

        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, 10, 200, 100));
        GUI.Label(new Rect(0, 0, 50, 20), "Health: ");
        sliderValue = GUI.HorizontalSlider(new Rect(50, 7, 100, 30), sliderValue, 0.0f, playerHP_Max);
        GUI.EndGroup();
        
    }

}
