using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class br_down : MonoBehaviour
{
    Vector3 br;
    float y = 0f;
    bool riz = false;
    float timing;
    void Start()
    {
        br = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(br.x, br.y - y, br.z);
        if (riz)
        {
            timing += Time.deltaTime;
            if (timing >= 1f)
            {
                y = y - 0.2f;
                if (y >= br.y)
                {
                    riz = false;
                    timing = 0f;
                }
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "monkey_idle")
        {
            y = y + 0.2f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        riz = true;
    }
}
