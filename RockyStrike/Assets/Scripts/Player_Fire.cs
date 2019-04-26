using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour {

    public GameObject PlayerBullet;
    public Transform BulletLocation;
    public float FireDelay;
    private bool FireState;

    public int BulletMaxPool;
    private MemoryPool mPool;
    private GameObject[] BulletArray;

    private void OnApplicationQuit()
    {
        mPool.Dispose();
    }

    // Use this for initialization
    void Start ()
    {
        FireState = true;

        mPool = new MemoryPool();
        mPool.Create(PlayerBullet, BulletMaxPool);
        BulletArray = new GameObject[BulletMaxPool];
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerFire();
    }

    private void PlayerFire()
    {
        if( FireState )
        {
            if(Input.GetKey(KeyCode.A))
            {
                StartCoroutine(FireCycleControl());
                
                for(int i = 0; i < BulletMaxPool; i++)
                {
                    if( BulletArray[i] == null )
                    {
                        BulletArray[i] = mPool.NewItem();
                        BulletArray[i].transform.position = BulletLocation.transform.position;
                        break;
                    }
                }
            }
        }

        for(int i = 0; i < BulletMaxPool; i++)
        {
            if(BulletArray[i])
            {
                if( BulletArray[i].GetComponent<Collider2D>().enabled == false )
                {
                    BulletArray[i].GetComponent<Collider2D>().enabled = true;
                    mPool.RemoveItem(BulletArray[i]);
                    BulletArray[i] = null;
                }
            }
        }
    }

    IEnumerator FireCycleControl()
    {
        FireState = false;
        yield return new WaitForSeconds(FireDelay);
        FireState = true;
    }
}
