using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data : MonoBehaviour {

    private int _hp;
    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public Enemy_Data(int _hp)
    {
        HP = _hp;
    }

    public void DecreaseHP(int _demage)
    {
        HP -= _demage;
    }

}
