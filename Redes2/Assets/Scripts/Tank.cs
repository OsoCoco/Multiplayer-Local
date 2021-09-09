using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Tank : MonoBehaviour
{
    Vector2 move;
    public float tankSpeed;
    public float rotationSpeed = 720;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(tankSpeed * move.y * Time.deltaTime * Vector3.forward);
        Quaternion toRotation = Quaternion.LookRotation(new Vector3(move.x, 0, move.y), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //transform.Rotate(rotSpeed * move.x * Time.deltaTime * Vector3.up);
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        Debug.Log("Fire");
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
        
        //Debug.Log(ctx.ReadValue<Vector2>().x);
    }
}
