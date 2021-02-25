using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_flying : MonoBehaviour
{
    Vector3 obj;
    Vector3 start;
    float x, y, z,x_up,y_up,x_dow,y_dow,x_pluse,x_minus,y_pluse,y_minus;
    float timing = 0f;
    bool x_till = false;
    bool y_till = false;
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
        obj = gameObject.transform.position;
        start = obj;
        x = obj.x;
        y = obj.y;
        x_pluse = Random.Range(10,40);
        x_up = x + x_pluse;
        x_dow = x - x_pluse;
        y_pluse = Random.Range(3, 6);
        y_up = y + y_pluse;
        y_dow = y - y_pluse;
        
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (timing >= 0.08f)
        {
            if (x >= x_dow && !x_till)
            {
                if (x == x_dow) { x_till = true; gameObject.transform.Rotate(0f, 180f, 0f, Space.Self); }
                x--;
            }
            else if (x <= x_up && x_till)
            {
                if (x == x_up) { x_till = false; gameObject.transform.Rotate(0f, 0f, 0f, Space.Self); }
                x++;
            }
            else
            {
                if (x_till == true)
                    x_till = false;
                else
                    x_till = true;
            }
            if (y >= y_dow && !y_till)
            {
                if (y == y_dow) { y_till = true; }
                y--;
            }
            else if (y <= y_up && y_till)
            {
                if (y == y_up) { y_till = false; }
                y++;
            }
            else
            {
                if (y_till == true)
                    y_till = false;
                else
                    y_till = true;
            }
            gameObject.transform.position = new Vector3(x,y,obj.z);
            timing = 0f;

        }
    }
}
