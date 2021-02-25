using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fead_in_out : MonoBehaviour
{
    RawImage fead;
    float value;
    float volume;
    float volume2;
    float timing;
    Color color;
    public GameObject truck;
    public GameObject music;
    void Start()
    {
        PlayerPrefs.SetInt("ad", 0);
        fead = gameObject.GetComponent<RawImage>();
        value = fead.color.a;
        color = new Color(fead.color.r, fead.color.g, fead.color.b, fead.color.a);
        Debug.Log(fead.color.a);
        volume = 0.6f;
        volume2 = 0.6f;

    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if(timing <= 8f)
        {
            color = new Color(fead.color.r, fead.color.g, fead.color.b, value);
            value -= 0.001f;
            fead.color = color;
        }
        else
        {
            color = new Color(fead.color.r, fead.color.g, fead.color.b, value);
            value += 0.001f;
            volume -= 0.0001f;
            volume2 -= 0.0001f;
            truck.GetComponent<AudioSource>().volume = volume;
            music.GetComponent<AudioSource>().volume = volume2;
            fead.color = color;
            if(value >= 1)
            {
                SceneManager.LoadScene("START_1");
            }
        }
        
        
    }
}
