using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_EnemyWarrior : MonoBehaviour {


    public int Health; //Задаем количество жизней через инспект
    public float Speed; // Задаем скорость 

   // private GameObject AttackTarget; // цель врага (в таргет крадем префаб плеера)
    private bool Angry; //видит ли нас противник     
    private bool facingRight = true; // смотрит вперед
    private float DistanceToPlayer;
    public float AttackDist; //минимальное расстояние, с которого враг может атаковать
    public float MaxFollowDist; //расстояние, на котором враг теряет игрока из виду
    public GameObject SpawnPos; //точка возврата врага, если он теряет игрока из виду
    private GameObject player;
    
    private GameObject Warrior_body;

    // public GameObject Projectile; // снаряд врага
    private bool Cooldown = false; // состояние перезарядки
    public float ReloadTime; //  время перезарядки
    private Animator anim;
    public float Damage; //дамаг, наносимый плееру при атаке

    //public Transform parent; // родитель


    void Start()
    {
        //берем компонент Аниматор из тела врага
        Warrior_body = GameObject.FindGameObjectWithTag("Warrior_body");
        anim = Warrior_body.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Dragon");
        
    }
    
    // Update is called once per frame
    void Update() {
        
       
    }
    
    void FixedUpdate()
    {
        DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        print("Warrior - Player distance is" + DistanceToPlayer);

        if (DistanceToPlayer <= MaxFollowDist)
        {
            //AttackTarget = player;
            Angry = true; // меняем состояние Angry на true, то есть противник на видит
        }
        
        
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
                anim.SetFloat("Walk_float", 0);
            //Chase(SpawnPos, Speed * Time.fixedDeltaTime); //если вызывать chase, то сразу включается анимация ходьбы
        }
    }

    private void Chase(GameObject chaseObj, float chaseSpeed)
    {
        anim.SetFloat("Walk_float", chaseSpeed);
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
        anim.SetTrigger("Hurt");
        //anim.ResetTrigger("Hurt");
        if (Health < 1)
        {
            anim.SetTrigger("Die");
            Invoke("Die", 2);

        }
        //Die(); // если здоровье становится меньше 1, враг умирает
    }

    private void Attack() // функция атаки
    {
        //anim.SetTrigger("Attack");
        print("Attacking!!!");
        anim.SetBool("Attack_bool", true);

        if (!Cooldown)//если враг сейчас не перезаряжается, то 
        {
            Cooldown = true; // на перезарядке
            Invoke("HurtPlayer", ReloadTime); // с задержкой вызываем функцию релоад
                                              // Instantiate(Projectile, parent);
        }

    }

    void HurtPlayer()
    {
        //print("Attacking!!!");
        Cooldown = false; //перезарядка закончилась
        anim.SetBool("Attack_bool", false);
        player.GetComponent<Lesson5_PlayerHealth>().ReceivingDamage(Damage);
        //GameObject.FindGameObjectWithTag("Dragon").GetComponent<Lesson5_PlayerHealth>().ReceivingDamage(Damage);
    }

    void Die()
    {
        Destroy(gameObject); // смерть
    }

}
