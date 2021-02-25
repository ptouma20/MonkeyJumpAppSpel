using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class item_controller : MonoBehaviour
{
    public GameObject[] items;
    public GameObject monky;
    public AudioSource button_sound;
    int count=0;
    public Text SCORE;
    public GameObject dialog;
    string[] items_Arr;
    private string str;
    void Start()
    {

        items[0].SetActive(true);
        //PlayerPrefs.SetInt("banana",450);
        SCORE.text = PlayerPrefs.GetInt("banana").ToString();
        string old_items = PlayerPrefs.GetString("items");
        items_Arr = old_items.Split(',');
        foreach(string s in items_Arr)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i].name+" " == s || " "+items[i].name + " " == s)
                {
                    items[i].transform.GetChild(0).GetComponent<Text>().text = "";
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next()
    {
        button_sound.Play();
        items[count].GetComponent<Animator>().SetBool("next", true);
        count++;
        if(count >= items.Length)
        {
            count = 0;
        }
        items[count].SetActive(true);
    }

    public void prev()
    {
        button_sound.Play();
        items[count].GetComponent<Animator>().SetBool("next",true);
        count--;
        if (count <0)
        {
            count = items.Length-1;
        }
        
        items[count].SetActive(true);
    }
    public void shop_item()
    {
        if (items[count].transform.GetChild(0).GetComponent<Text>().text != "")
        {
            int items_coast = int.Parse(items[count].transform.GetChild(0).GetComponent<Text>().text);
            int player_score = PlayerPrefs.GetInt("banana");
            if (PlayerPrefs.GetInt("banana") >= items_coast)
            {
                dialog.SetActive(true);
                dialog.transform.GetChild(0).GetComponent<Text>().text = "COST " + items_coast;
            }
        }
        else
        {
            for (int i = 0; i < monky.GetComponent<clothes>().clothes_obj.Length; i++)
            {
                if (monky.GetComponent<clothes>().clothes_obj[i].name == items[count].name && monky.GetComponent<clothes>().clothes_obj[i].gameObject.activeSelf|| 
                    monky.GetComponent<clothes>().clothes_obj[i].name == items[count].name + " (1)" && monky.GetComponent<clothes>().clothes_obj[i].gameObject.activeSelf)
                {
                    monky.GetComponent<clothes>().clothes_obj[i].SetActive(false); 
                }
                else if(monky.GetComponent<clothes>().clothes_obj[i].name == items[count].name || monky.GetComponent<clothes>().clothes_obj[i].name == items[count].name+" (1)")
                {
                    monky.GetComponent<clothes>().clothes_obj[i].SetActive(true);
                }
            }
            
        }
    }
    public void OK()
    {
        int items_coast = int.Parse(items[count].transform.GetChild(0).GetComponent<Text>().text);
        int player_score = PlayerPrefs.GetInt("banana");
        PlayerPrefs.SetInt("banana", player_score-items_coast);
        string old_items = PlayerPrefs.GetString("items");
        string new_item = items[count].name + " , ";
        PlayerPrefs.SetString("items", old_items+new_item);
        items[count].transform.GetChild(0).GetComponent<Text>().text = "";
        dialog.SetActive(false);
        SCORE.text = PlayerPrefs.GetInt("banana").ToString();
    }
    public void Dis()
    {
        dialog.SetActive(false);
    }
    public void all_showsen_items()
    {

        for (int i = 0; i < monky.GetComponent<clothes>().clothes_obj.Length; i++)
        {
            if (monky.GetComponent<clothes>().clothes_obj[i].gameObject.activeSelf)
            {
                str += "/" +monky.GetComponent<clothes>().clothes_obj[i].gameObject.name;  
            }

        }
        PlayerPrefs.SetString("use", str);
        SceneManager.LoadScene("START_1");
    }
}
