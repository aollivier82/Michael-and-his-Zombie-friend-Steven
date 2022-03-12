using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float despawnTime = 5f;
    private Rigidbody body;
    public float speed = 5;

    public PlayerHealth health;
    public AudioSource hurtSrc;


    private void Start()
    {
        body = GetComponent<Rigidbody>();
        health = FindObjectOfType<PlayerHealth>();
        hurtSrc = GameObject.Find("HurtSrc").GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        
        StartCoroutine(Despawn());
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            body.MovePosition(transform.position + transform.forward * speed);

        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            health.health -= 10;
            hurtSrc.Play();
        }
        this.gameObject.SetActive(false);
    }
}
