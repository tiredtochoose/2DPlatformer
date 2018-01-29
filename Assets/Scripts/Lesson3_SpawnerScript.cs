using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_SpawnerScript : MonoBehaviour {

    // Use this for initialization

    //public GameObject Enemy, GO;
    public Transform SpawnPos;
    //public bool Delete;

    public Rigidbody Bullet, Projectile;

    void Start () {

        Bullet = Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        //Bullet = Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation, transform); --- transform спавнит дочерний объект
        Bullet.AddForce(Vector3.forward * 25, ForceMode.Impulse);


        //GO = Instantiate(Enemy, SpawnPos.position, SpawnPos.rotation);
        ///!!!Destroy(gameObject) ==== Destroy(this);
        //Destroy(gameObject, 2); // 2- время до удаления; удалили сам спаунер
        //Destroy(Bullet.gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
