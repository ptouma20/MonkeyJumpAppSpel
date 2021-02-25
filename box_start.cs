using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_start : MonoBehaviour
{
    public GameObject effect;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SS()
    {
        //effect.SetActive(true);
        player.SetActive(true);
        //Destroy(gameObject);
    }
    public void DD()
    {
        Destroy(gameObject);
    }
}
