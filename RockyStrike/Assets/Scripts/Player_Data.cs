﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour
{
    public Player_Data(int _hp)
    {
        HP = _hp;
    }

    private int _hp;
    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }
}
