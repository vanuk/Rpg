using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Joystick joystic;
    
    public float moveSpeed;
    
    public Rigidbody2D rb;
    public GameObject restart;
    [SerializeField]
    GameObject bullet1;
    float fireRate1;
    float nextFire1;
    
    private Vector2 moveDirectoin;
    private Vector2 moveDirectoin1;


    public GameObject death;
    public GameObject player;

    public Animator anim;
   

    
    // Start is called before the first frame update
    void Start()
    {
       death.SetActive(false);
       restart.SetActive(false);
       nextFire1 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*

       if (joystic.Horizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
           
        }
        if (joystic.Horizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
        
   
        
         Vector2 moveInput = new Vector2(joystic.Horizontal, joystic.Vertical);
        
         anim.SetFloat("Horizontal",joystic.Horizontal);
         anim.SetFloat("Vertical",joystic.Vertical);
         anim.SetFloat("speed",moveDirectoin.sqrMagnitude);
         
         
         
         
         */
         
        //moveDirectoin1 = moveInput.normalized * speed;

/*
        moveDirectoin1.x = Input.GetAxisRaw("Horizontal");
        moveDirectoin1.y = Input.GetAxisRaw("Vertical");
        
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
*/
        if (HealthBar.health == 0)
        {

            death.transform.position = player.transform.position;
            death.SetActive(true);
            
            Destroy(player);
            restart.SetActive(true);
            //EnemyShot.CheakifTimeToFire();
            
        }
    }

    public void SootBullet()
    {
        if (Time.time > nextFire1)
        {
            Instantiate(bullet1, transform.position, Quaternion.identity);
            nextFire1 = Time.time + fireRate1;
        }
    }

    public void rigth()
    {
        moveDirectoin1.x = moveSpeed;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }
    public void left()
    {
        moveDirectoin1.x = -moveSpeed;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }

    public void stop()
    {
        moveDirectoin1.x = 0;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }

    public void up()
    {
        moveDirectoin1.y = moveSpeed;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }
    public void down()
    {
        moveDirectoin1.y = -moveSpeed;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }
    public void stop1()
    {
        moveDirectoin1.y = 0;
        anim.SetFloat("Horizontal",moveDirectoin1.x);
        anim.SetFloat("Vertical",moveDirectoin1.y);
        anim.SetFloat("speed",moveDirectoin1.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+moveDirectoin1*moveSpeed* Time.deltaTime);
        
     
    //  rb.velocity = moveDirectoin * moveSpeed * Time.deltaTime;


   
  

    
    }

  
  
    
  
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy")) {
            HealthBar.health -= 20;
        }

        if(other.CompareTag("Heart")) {
            HealthBar.health += 20;
        }
    }
}
