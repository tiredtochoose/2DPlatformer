using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_PlayerController : MonoBehaviour
{

   // 3. Реализовать прыжок.


    public float Speed;  //Cкорость персонажа
    public float JumpForce;  //Сила прыжка
    Vector3 Dir = new Vector3(0, 0, 0); //направление

    private bool grounded = false;          // условие, когда игрок стоит на земле (нужно, для того 
                                                //чтобы запрещать персонажу прыгать от воздуха)
    private bool jump = false;				// условие, при котором игрок может прыгать
    public Transform groundCheck;           // марвер "на земле", в который положен спрайт groundCheck в инспректре, расположенный в
                                                //ногах у персонажа
    private Rigidbody2D rb;                 //переменная Rigidbody2D


    void Start () {
        rb = GetComponent<Rigidbody2D>();  //в rb кладем компонент Rigidbody данного геймобжекта
    }
	
	// Update is called once per frame
	void Update () {

        // даем определение grounded: когда игрок косается чего-либо со слоем ground
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //даем определение jump: если нажата кнопка "Jump" из input менеджера (пробел)  
        // и если выполнено условие grounded
        
        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
    }

    void FixedUpdate()
    {
        Dir.x = Input.GetAxis("Horizontal"); //считываем, какие клавиши были нажаты из Input Manager'а 
                                             //из настроек оси Horizontal и записываем данные в Vector3 Dir ось х
        if (Dir.x != 0)                         // если значение оси меняется, то есть что-то было нажато, то
            transform.position += Dir * Speed * Time.fixedDeltaTime; // меняем положение персонажа

        //3. Реализовать прыжок.
        Dir.y = Input.GetAxis("Jump"); //считываем, какие клавиши были нажаты, из Input Manager'а компонет Jump
        
        if (jump)// если игрок может прыгать (то есть если условие jump выполнено)
        {

            rb.velocity = new Vector2(0, JumpForce); //к Rigidbogy rb (в котором лежит компонент Rigidbody данного геймобжекта)
            //применяем вектор скорости x=0, y=JumpForce,установленный в инспектре

            // запрещаем игроку прыгать
            jump = false;
        }
    }

}
