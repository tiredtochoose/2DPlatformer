using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CameraBhv : MonoBehaviour {

    private Transform player;
    public float xMargin = 1f;      // расстояние по х, по которому игрок может перемещаться, до того как камера будет за ним двигаться

    public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.

    public Vector2 maxXAndY;		// максимумальные х и у, которые может иметь камера
    public Vector2 minXAndY;		// z х и у, которые может иметь камера


    
    // Use this for initialization
    void Awake () {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Dragon").transform;
    }

    bool CheckXMargin() // если игрок ушел слишком далеко
    {
        // возвращает true если расстояние между камерой и игроком по х больше xMargin
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    void FixedUpdate()
    {        
        TrackPlayer();
    }


    void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

        //// If the player has moved beyond the y margin...
        //if (CheckYMargin())
        //    // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
        //    targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
