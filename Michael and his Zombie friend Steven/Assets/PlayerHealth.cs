using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Slider slider;
    public Text endGame;
    public AudioSource eatingSrc; 

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (health < 0)
        {
            endGame.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }     
    }

    void OnCollisionEnter(Collision obj) {
        //need green health orb and orange health orb created
        if (obj.gameObject.tag == "GreenOrb") {
            health += 10;
            obj.gameObject.SetActive(false);
            eatingSrc.Play();
        }
        else if (obj.gameObject.tag == "OrangeOrb") {
            health += 5;
            obj.gameObject.SetActive(false);
            eatingSrc.Play();
        }

        

    }
}