using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Tank : MonoBehaviour
{
    
    Vector2 move;

    public GameObject bullet;
    public Transform barrel;

    public float tankSpeed,attackDamage,life;
    public float fireRate = 0.5f;
    public float rotationSpeed = 720;

    float nextFire;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move.x,0,move.y) * tankSpeed * Time.deltaTime);
        Quaternion toRotation = Quaternion.LookRotation(new Vector3(move.x, 0, move.y), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //transform.Rotate(rotSpeed * move.x * Time.deltaTime * Vector3.up);
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        }

        
        //Debug.Log("Fire");
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
        
        
    }
}
