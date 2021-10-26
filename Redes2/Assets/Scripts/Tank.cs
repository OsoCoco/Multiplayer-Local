using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
public class Tank : MonoBehaviour
{

    [HideInInspector]
    public int ID;
    
    Vector2 move;

    public GameObject bullet;
    public Transform barrel;

    public int score;

    public Transform spawnPoint;
    
    public float tankSpeed,attackDamage,life;
    public float fireRate = 0.5f;
    public float rotSpeed;
    float refSpeed;
    public float bulletForce;
    public TMP_Text scoreText;
    public Slider lifeSlider;
    public Image sliderImage;
    float nextFire;

    float initLife;
    bool isAlive;

    private void Start()
    {
        initLife = life;
        lifeSlider.maxValue = initLife;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y);

        //transform.Translate(movement * tankSpeed * Time.deltaTime);


        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref refSpeed, rotSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            transform.Translate(movement * tankSpeed * Time.deltaTime);
        }

        //transform.Rotate(rotSpeed * move.x * Time.deltaTime * Vector3.up);

        //CheckDeath();
    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        lifeSlider.value = life;

        if (life > initLife * .50f)
        {
            sliderImage.color = Color.green ;
        }
        else if( life > initLife * .25f && life <= initLife * .50f )
        {
            sliderImage.color = Color.yellow;
        }
        else 
        {
            sliderImage.color = Color.red;
        }

        scoreText.text = "Score: " + score.ToString();
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
       if(ctx.performed && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            GameObject go = Instantiate(bullet, barrel.transform.position, transform.rotation);
            go.GetComponent<Bullet>().damage = attackDamage;
            go.GetComponent<Bullet>().myTank = this;
            go.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * bulletForce, barrel.position, ForceMode.Impulse);
            
        }
         //Debug.Log("Fire");
    }

   public void CheckDeath()
    {
        if (life <= 0)
            isAlive = false;
        Death(isAlive);
    }

    void Death(bool alive)
    {
        if(!alive)
        {
            Debug.Log("I DIE");
            Respawn();
        }
    }

    void Respawn()
    {
        isAlive = true;
        life = initLife;
        transform.position = spawnPoint.position;
    }
    public void Move(InputAction.CallbackContext ctx)
    {
         move = ctx.ReadValue<Vector2>().normalized;
    }
}
