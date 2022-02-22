using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int health;
    private SpriteRenderer render;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    public AudioSource audioSource; 
    public AudioClip destroySoundClip;




    void Start()
    {
        //health = Random.Range(0, 4);
        health = 0;
        render = gameObject.GetComponent<SpriteRenderer>();
        if(health == 0) render.sprite = health0;
        if(health == 1) render.sprite = health1;
        if(health == 2) render.sprite = health2;
        if(health == 3) render.sprite = health3;
        if(health == 4) render.sprite = health4;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0) render.sprite = health0;
        if(health == 1) render.sprite = health1;
        if(health == 2) render.sprite = health2;
        if(health == 3) render.sprite = health3;
        if(health == 4) render.sprite = health4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health <= 0) {
            AudioSource.PlayClipAtPoint(destroySoundClip, transform.position, 5);
            Destroy(gameObject);
        }
        
        health -= 1;
    }
}
