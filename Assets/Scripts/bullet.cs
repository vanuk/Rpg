using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  //public GameObject hitEffect;
  float moveSpeed = 7f;
  public GameObject bullet01;
  Rigidbody2D rb;
  EnemyAi target;
  Vector2 moveDirection;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    target = GameObject.FindObjectOfType<EnemyAi>();
    moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
    rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    Destroy(bullet01, 3f);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("enemy")) {
      Destroy(bullet01);
    } 
  }
}
