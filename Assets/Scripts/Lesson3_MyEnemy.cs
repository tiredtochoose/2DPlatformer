using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_MyEnemy : MonoBehaviour {

    //Задание4 - Пусть ваш снаряд отнимает жизни и убивает противников.
    public int Health; //Задаем количество жизней через инспект
    public float Speed; // Задаем скорость 

    private GameObject AttackTarget; // цель врага (в таргет крадем префаб плеера)
    private bool Angry; //видит ли нас противник     
    private bool facingRight = true; // смотрит вперед
    public float MinAttackDist; //минимальное расстояние, с которого враг может атаковать
    public float MaxFollowDist; //расстояние, на котором враг теряет игрока из виду
    public GameObject SpawnPos; //точка возврата врага, если он теряет игрока из виду

    public GameObject Projectile;
    private bool Cooldown = false;
    public float ReloadTime;

    public Transform parent;


    void Start () {
		
	}

    public void Hurt(int Damage) //функция Hurt, которая принимает аргумент Damage, прописанный в
                                 //Lesson3_Projectile, положенный на префаб Fire
    {
        Health -= Damage;  //Уменьшаем здоровье на дамаг   
        if (Health < 1)
            Die(); // если здоровье становится меньше 1, враг умирает
    }

    // Update is called once per frame
    void Update () {
        
    }

    void FixedUpdate()
    {
       

        if (Angry) // если игрок зашел в зону видимости 
        {

            float x = DirectionDeterm(AttackTarget); // определяем с какой стороны игрок: если х < 0, то слева, если х > 0, то справа

            if (x < 0 && facingRight) //если игрок слева, а враг смотрит направо
                Flip(); //разворачивается
            else if (x > 0 && !facingRight) //если игрок справв, а враг смотрит налево
                Flip(); //разворачивается

            //проверяем дистанцию до игрока 
            //if (Vector3.Distance(transform.position, AttackTarget.transform.position) <= MinAttackDist) //eсли дистанция позволяет атакуем
            if (DistanceBetween(transform.position, AttackTarget.transform.position) <= MinAttackDist)
                    Attack(); // атакуем

            // Если мы далековато, двигаемся к цели
            else
            {                
                transform.position = Vector3.MoveTowards(transform.position, AttackTarget.transform.position, Speed * Time.fixedDeltaTime);
                
                //if (Vector3.Distance(transform.position, AttackTarget.transform.position) > MaxFollowDist)
                if (DistanceBetween(transform.position, AttackTarget.transform.position) > MaxFollowDist)

                    ReturnToPosition();


            }
                             
        }
        else
            return;
    }

    private void ReturnToPosition()
    {
       float x = DirectionDeterm(SpawnPos); //определяем в каком направлении SpawnPos
        if (x < 0 && facingRight) //если SpawnPos слева, а враг смотрит направо
            Flip(); //разворачивается
        else if (x > 0 && !facingRight) //если SpawnPos справв, а враг смотрит налево
            Flip(); //разворачивается

        transform.position = Vector3.MoveTowards(transform.position, SpawnPos.transform.position, Speed * Time.fixedDeltaTime);
    }

    private float DistanceBetween(Vector3 currentPos, Vector3 target)
    {
        return Vector3.Distance(currentPos, target);
    }
    
    private float DirectionDeterm(GameObject target) //функция определия направления между данным игровым объектом(врагом) и целью (аргумент функции)
    {
        return target.transform.position.x - transform.position.x;
    }

    private void Flip() //разворот
    {
        facingRight = !facingRight; //меняем состояния "смотрит направо" на противоположное (неважно какое было изначально)

        Vector3 enemyScale = transform.localScale; // берем вектор3 и кладем в него компонеет transform.localScale данного игрового объекта
        enemyScale.x *= -1; //меняем направление по иксу на противоположное
        transform.localScale = enemyScale; // то, что поменяли, отдаем обратно данному игровому объекту
    }

    private void OnTriggerEnter2D(Collider2D enteredCol) //триггер на косание
    {
        if (enteredCol.gameObject.layer == 9) //если объект, активировавший триггер, имеет слой "player", то 
        {
            AttackTarget = enteredCol.gameObject; // целью аттаки становится он (объект, активировавший триггер со слоем "player",)
            Angry = true; // меняем состояние Angry на true, то есть противник на видит
        }
    }

    private void Attack() // функция атаки
    {
        //print("Attacking!!!");

        if (!Cooldown)
        {
            Cooldown = true;
            Invoke("Reload", ReloadTime);
            Instantiate(Projectile, parent);
        }
               
    }

    void Reload()
    {
        Cooldown = false;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
