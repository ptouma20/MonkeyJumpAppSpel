using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_point : MonoBehaviour
{
    public GameObject check;
    public AudioSource sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "monkey_idle")
        {
            sound.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = check.GetComponent<SpriteRenderer>().sprite;
        }
        
    }
}
