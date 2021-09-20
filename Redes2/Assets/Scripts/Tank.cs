using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Tank : MonoBehaviour
{
    
    public MeshRenderer[] renderToChange; 
    Vector2 move;

    public GameObject bullet;
    public Transform barrel;

    public float score;

    public Transform spawnPoint;
    
    public float tankSpeed,attackDamage,life;
    public float fireRate = 0.5f;
    public float rotationSpeed = 720;
    public TextMeshPro scoreText;
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
        /*if(ctx.performed && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        }*/

        //Debug.Log("Fire");
    }

    void Respawn()
    {
        Instantiate(this, spawnPoint.position, Quaternion.identity);
    }

    void Death()
    {

    }
    
    public void ChangeColor(Material material)
    {
        for (int i = 0; i < renderToChange.Length; i++)
        {
            renderToChange[i].materials[0] = material;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
        
        
    }
}
