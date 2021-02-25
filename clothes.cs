using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothes : MonoBehaviour
{
    public GameObject[] clothes_obj;
    private string str;
    void Start()
    {
        str = PlayerPrefs.GetString("use");
        for (int i = 0; i < clothes_obj.Length; i++)
        {
            if (str.Contains(clothes_obj[i].name) )
            {
                clothes_obj[i].SetActive(true);
            }

        }
    }
}
