using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float damage;


    [HideInInspector]
    public Tank myTank;
    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tank"))
        {
            
            if(myTank !=null)
            {
                myTank.score += 2;
            }

            collision.gameObject.GetComponent<Tank>().life -= damage;
            collision.gameObject.GetComponent<Tank>().CheckDeath();
        }
        Destroy(this.gameObject);
    }
}
