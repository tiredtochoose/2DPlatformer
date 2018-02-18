using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_Wizard : MonoBehaviour
{


    public int Health; //Задаем количество жизней через инспект
    public float Speed; // Задаем скорость 
    public GameObject bullet;
    public Transform bulletPos;
    
    private bool Angry; //видит ли нас противник     
    private bool facingRight = true; // смотрит вперед
    private float DistanceToPlayer;
    public float AttackDist; //минимальное расстояние, с которого враг может атаковать
    public float MaxFollowDist; //расстояние, на котором враг теряет игрока из виду
    public GameObject SpawnPos; //точка возврата врага, если он теряет игрока из виду
    private GameObject player;
    
    private bool Cooldown = false; // состояние перезарядки
    
    private Animator anim;
    // public float Damage; //дамаг, наносимый плееру при атаке 
                            // перенесся на Lesson7_WizrdBullet

    void Start()
    {
       anim = GetComponent<Animator>();
       player = GameObject.FindGameObjectWithTag("Dragon");
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (DistanceToPlayer <= MaxFollowDist)
              Angry = true; // меняем состояние Angry на true, то есть противник на видит

        if (Angry) // если игрок зашел в зону видимости врага
        {

            float x = DirectionDeterm(player); // определяем с какой стороны игрок: если х < 0, то слева, если х > 0, то справа
            if (x < 0 && facingRight) //если игрок слева, а враг смотрит направо
                Flip(); //разворачивается
            else if (x > 0 && !facingRight) //если игрок справв, а враг смотрит налево
                Flip(); //разворачивается

            //проверяем дистанцию до игрока, eсли дистанция позволяет атакуем
            if (DistanceToPlayer <= AttackDist)
                Attack(); // атакуем


            else if (DistanceToPlayer > AttackDist && DistanceToPlayer < MaxFollowDist)
                Chase(player, Speed * Time.fixedDeltaTime); // Если враг слишком далеко от игрока, идем к нему

            //если же игрок убежал от врага, враг возвращается на свою позицию
            if (DistanceToPlayer > MaxFollowDist)
                Angry = !Angry;
        }

        if (!Angry) // возвращени на место >>>>>>все работает<<<<<<<
        {
            float x = DirectionDeterm(SpawnPos); //определяем в каком направлении SpawnPos
            if (x < 0 && facingRight) //если SpawnPos слева, а враг смотрит направо
                Flip(); //разворачивается
            else if (x > 0 && !facingRight) //если SpawnPos справв, а враг смотрит налево
                Flip(); //разворачивается

            // враг возвращается на свою позицию

            transform.position = Vector3.MoveTowards(transform.position, SpawnPos.transform.position, Speed * Time.fixedDeltaTime); //с этим методом перс стоит в айдле
            if (Mathf.Abs(transform.position.x - SpawnPos.transform.position.x) < 0.1)
                anim.SetFloat("Walk", 0);
            //Chase(SpawnPos, Speed * Time.fixedDeltaTime); //если вызывать chase, то сразу включается анимация ходьбы
        }
    }

    private void Chase(GameObject chaseObj, float chaseSpeed)
    {
        anim.SetFloat("Walk", chaseSpeed);
        transform.position = Vector3.MoveTowards(transform.position, chaseObj.transform.position, chaseSpeed);
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

    public void Hurt(int Damage) //функция Hurt, которая принимает аргумент Damage, прописанный в
                                 //Lesson3_Projectile, положенный на префаб Fire
    {
        Health -= Damage;  //Уменьшаем здоровье на дамаг   
        anim.SetBool("Hurt", true); //анимация выключается через private void AnimOff()

        if (Health < 1)
        {
            transform.position = transform.position;
            anim.SetTrigger("Die"); //объект уничтожается по ивенту в конце анимации
            
        }
        
    }

    private void AnimOff()// вызывается ивентом в конце анимации Hurt
    {
        anim.SetBool("Hurt", false);
    }

    private void Attack() // функция атаки
    {        
        anim.SetBool("Attack", true);
    }

    public void MagicBullet() //вызывается ивентом в анимации
    {
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        anim.SetBool("Attack", false);
    }

    void HurtPlayer()
    {
        
        Cooldown = false; //перезарядка закончилась
        anim.SetBool("Attack", false);
        
    }

    void Die() //объект уничтожается по ивенту в конце анимации
    {
        Destroy(gameObject); // смерть
    }

}
