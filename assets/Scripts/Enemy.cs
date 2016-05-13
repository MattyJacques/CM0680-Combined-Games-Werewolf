﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  public int health;
  public bool scary;
  public float speed = 15;
  public int damage = 10;
  public int rangeCheck = 20;
  public GameObject player;

	void Start ()
  {
    health = 100;
    scary = false;

    player = GameObject.FindGameObjectWithTag("Player");
	}


  public virtual void Move()
  {

  }

  //run the animator and then destory the object
  public IEnumerator Die()
  { // Play animation then destroy the enemy when has no health left

    GetComponent<Animator>().SetBool("IsDead", true);     // Play dead animation

    // Wait until animation is finished to destroy enemy
    yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).
                                    length);

    Destroy(this.gameObject);                             // Destroy enemy

  } // Die()

  void OnTriggerEnter2D(Collider2D other)
  {
      if (other.gameObject.tag == "Instant Kill")
      {
          StartCoroutine(Die());
      }
  }
  

}
