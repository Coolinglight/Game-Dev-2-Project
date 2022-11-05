using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    public static event Action<GameObject> OnEnemyHit = null;
    public static event Action<GameObject> OnEnemyDie = null;

    float moveDistance = 500;
    public float myHealth = 100f;

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit(10);
        }
    }

    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }

    void Hit(int _damage)
    {
        myHealth -= _damage;
        if (myHealth <= 0)
            Die();
        else
        {
            OnEnemyHit?.Invoke(this.gameObject);
        }
    }

    void Die()
    {
        if(myHealth <= 0)
        {
            StopAllCoroutines();
            OnEnemyDie?.Invoke(this.gameObject);
        }
        
    }
}
