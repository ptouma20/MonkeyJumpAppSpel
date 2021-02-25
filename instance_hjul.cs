using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance_hjul : MonoBehaviour
{
    public Transform prefab;
    float timing;
    int rand;
    void Start()
    {
        rand = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (timing > rand)
        {
            Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            timing = 0f;
            if (PlayerPrefs.GetString("level_select") == "E")
            {
                rand = Random.Range(12, 20);
            }
            else if (PlayerPrefs.GetString("level_select") == "M")
            {
                rand = Random.Range(8, 12);
            }
            else if (PlayerPrefs.GetString("level_select") == "H")
            {
                rand = Random.Range(4, 8);
            }

        }
        
    }
}
