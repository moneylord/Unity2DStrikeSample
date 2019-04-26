using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int HP;
    private Enemy_Data enemyData;

	// Use this for initialization
	void Start ()
    {
        enemyData = new Enemy_Data(HP);
        Debug.Log(gameObject.name + "의 HP : " + enemyData.HP);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player_Bullet"))
        {
            Debug.Log("Collision to Bullet");
            enemyData.DecreaseHP(10);
            Debug.Log(gameObject.name + "of HP is : " + enemyData.HP);
        }
    }

    private void FixedUpdate()
    {
        if( enemyData.HP <= 0  )
        {
            Debug.Log("Enemy Destroyed..........");
            Destroy(gameObject);
        }
    }
}
