using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Tank : MonoBehaviour
{
    Vector2 movementSpeed;
    public float tankSpeed,rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(tankSpeed*movementSpeed.y*Time.deltaTime*Vector3.forward);
        transform.Rotate(rotSpeed * movementSpeed.x*Time.deltaTime*Vector3.up);
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        Debug.Log("Fire");
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movementSpeed = ctx.ReadValue<Vector2>();
        //Debug.Log(ctx.ReadValue<Vector2>().x);
    }
}
