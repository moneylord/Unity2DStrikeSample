using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public Player_Event playerEvent;
    public float Speed = 1f;	
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove();
        MoveClamp();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector2.down * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    private void MoveClamp()
    {
        Vector2 left = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 right = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 player = transform.position;

        player.x = Mathf.Clamp(player.x, left.x + 0.8F, right.x - 0.8F);
        player.y = Mathf.Clamp(player.y, left.y + 1, right.y - 1);

        transform.position = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("적과 충돌 에너지 10 감소");
            playerEvent.UnderAttack(10);            
        }
    }
}
