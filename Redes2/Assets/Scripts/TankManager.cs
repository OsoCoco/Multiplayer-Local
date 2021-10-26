using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankManager : MonoBehaviour
{

    public float speed;
    public float turnSpeed = 0.1f;
    public Transform cam;
    float turnRef;
    TankControls controls;

    Vector2 direction;

    private void Awake()
    {
        controls = new TankControls();

        controls.Movement.Movement.performed += ctx => direction = ctx.ReadValue<Vector2>();
        controls.Movement.Movement.canceled += ctx => direction = ctx.ReadValue<Vector2>();
    }
    // Start is called before the first frame update

    private void Update()
    {
        Vector3 dir = new Vector3(direction.x, 0, direction.y).normalized;

        if(dir.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnRef,turnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f) ;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDir.normalized * speed *Time.deltaTime);
        }

        //Debug.DrawLine(transform.position, transform.forward*50,Color.red);
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
