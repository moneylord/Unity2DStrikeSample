
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour {

    public float MoveSpeed;
    public float DestroyYPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);

        if( transform.position.y >= DestroyYPos )
        {
            GetComponent<Collider2D>().enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Enemy"))
        {
            Debug.Log("Collision to Enemy Panel");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
