using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL_true_false : MonoBehaviour
{
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
    }

}
