using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_trap : MonoBehaviour
{
    public ParticleSystem effect;
    Vector3 pos = new Vector3();
    float y = 0f;
    bool till = false;
    float timing = 0f;
    public float speed = 0.07f;
    public AudioSource aud;
    void Start()
    {
        if (PlayerPrefs.GetString("level_select") == "E")
        {
            int rand = Random.Range(0, 10);
            if (rand > 3) { gameObject.SetActive(false); }

        }
        else if (PlayerPrefs.GetString("level_select") == "M")
        {
            int rand = Random.Range(0, 10);
            if (rand > 6) { gameObject.SetActive(false); }
        }
        else if (PlayerPrefs.GetString("level_select") == "H")
        {
            int rand = Random.Range(0, 10);
            if (rand > 9) { gameObject.SetActive(false); }
        }
        pos = transform.position;
        y = pos.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        till = true;
        aud.Play();
        if (!effect.isPlaying)
            effect.Play();
    }
    private void Update()
    {
        if (till) 
        {
            timing += Time.deltaTime;
            
            if (timing >2f)
            {
                y = pos.y;
                till = false;
                timing = 0f;
            }
            
        }
        else
        {
            gameObject.transform.position = new Vector3(pos.x, y, pos.z);
            y -= speed;

        }

    }
}
