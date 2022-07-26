using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    public float fireRate;
   private float nextFire;

    public float heal;

    public GameObject Enemy;
    
    public float speed;

    public float checkRadius;

    public float AttackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;

    private Rigidbody2D rb;

    private Animator anim;

    private Vector2 movement;

    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isRun",isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
         isInAttackRange   = Physics2D.OverlapCircle(transform.position, AttackRadius, whatIsPlayer);

         dir = target.position - transform.position;
         float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
         dir.Normalize();
         movement = dir;
         if (shouldRotate)
         {
             anim.SetFloat("x",dir.x);
             anim.SetFloat("y",dir.y);
             
         }

         if (isInChaseRange)
         {
             startFight();
         }


         if (heal == 0)
         {
             Destroy(Enemy);
             
             
         }

         
    }

    public void startFight()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
          //  startFight();
         //   rb.MovePosition(rb.position+movement*speed*Time.deltaTime);
        }

        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position+(dir*speed*Time.deltaTime));
      
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("shoot"))
        {
            heal -= 20;
            
        }
    }
}
