using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadiing_false : MonoBehaviour
{
    public GameObject panel_loding;
    void Start()
    {
        if(PlayerPrefs.GetInt("Ad") == 1)
        {
            panel_loding.SetActive(false);
        }
    }

}
