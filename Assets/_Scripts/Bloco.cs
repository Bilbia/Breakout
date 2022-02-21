using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int health;

    void Start()
    {
        health = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
        
        health -= 1;
    }
}
