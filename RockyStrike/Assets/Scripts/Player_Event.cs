using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Event : MonoBehaviour
{
    public GameObject Player;
    public int PlayerHP;
    private Player_Data playerData;
    public Slider HPBar;

	// Use this for initialization
	void Start ()
    {
        playerData = new Player_Data(PlayerHP);
        HPBar.maxValue = PlayerHP;
        HPBar.value = PlayerHP;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckPlayerHP();
	}

    public void UnderAttack(int _damage)
    {
        playerData.HP -= _damage;
    }

    void CheckPlayerHP()
    {
        PlayerHP = playerData.HP;
        if( PlayerHP <= 0 )
        {
            PlayerHP = 0;
            Destroy(Player);
        }
        HPBar.value = PlayerHP;
    }
}
