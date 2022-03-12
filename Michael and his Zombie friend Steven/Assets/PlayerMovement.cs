using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private Vector3 inputVector;
    //public float speed = 50.0f;

    private AudioSource src;

    
    public AudioClip footstep1;
    public AudioClip footstep2;
    public AudioClip footstep3;
    public AudioClip footstep4;

    AudioClip[] feet;
    void Start() {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
        feet = new AudioClip[4];
        feet[0] = footstep1;
        feet[1] = footstep2;
        feet[2] = footstep3;
        feet[3] = footstep4;
        StartCoroutine(Footstep());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //freeze X and Z rotation of player GO
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 100.0f, rb.velocity.y, Input.GetAxisRaw("Vertical") * 100.0f);
        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = inputVector;
        //rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);


        
    }

    IEnumerator Footstep()
    {
        //If moving
        if (rb.velocity.magnitude > 0)
        {
            if (src != null)
            {
                src.clip = feet[Random.Range(0, 4)];
                if (!src.isPlaying)
                {
                    src.Play();
                }

            }
            
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Footstep());
    }


}