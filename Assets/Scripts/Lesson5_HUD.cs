using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_HUD : MonoBehaviour {
    
    private Lesson5_PlayerHealth PlayerHP;
    private float sliderValue;
    public float playerHP_Max;



    void OnGUI()
    {
        PlayerHP = transform.parent.GetComponent<Lesson5_PlayerHealth>();
        sliderValue = PlayerHP.PlayersHealth;
        //print(sliderValue);


        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, 10, 200, 100));
        GUI.Label(new Rect(0, 0, 50, 20), "Health: ");
        sliderValue = GUI.HorizontalSlider(new Rect(50, 7, 100, 30), sliderValue, 0.0f, playerHP_Max);
        GUI.EndGroup();

    }

    //private float mySlider = 50.0f;
    //void OnGUI()
    //{
    //    mySlider = LabelSlider(new Rect(10, 10, 200, 20), mySlider, 100.0f, "Slider name");
    //}
    //float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    //{
    //    Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
    //    GUI.Label(labelRect, labelText);
    //    Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2,
    //    screenRect.height);
    //    sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
    //    return sliderValue;
    //}


}
