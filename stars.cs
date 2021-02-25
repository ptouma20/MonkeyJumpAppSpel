using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars : MonoBehaviour
{
    struct S
    {
        int star_num;
        int star_win;
    }
    private S[] star_memory;
    public GameObject[] star;
    void Start()
    {

        //PlayerPrefs.SetInt("level_" + 1, 20 / 15);
       /* for (int i=0;i< PlayerPrefs.GetInt("Level_1"); i++)
        {
            star[i].GetComponent<Animator>().SetInteger("stars", PlayerPrefs.GetInt("level_"+i));
        }
        star[PlayerPrefs.GetInt("Level_1")].GetComponent<Animator>().SetInteger("stars", PlayerPrefs.GetInt("level_" + PlayerPrefs.GetInt("Level_1")));*/
    }

public void stars_call()
    {
        int max = 0;
        if (gameObject.GetComponent<B_controller>().allWorldCount == 0) { if (PlayerPrefs.GetInt("Level_1") > 9) max = 9; else max = PlayerPrefs.GetInt("Level_1"); }
        else if (gameObject.GetComponent<B_controller>().allWorldCount == 1) { if (PlayerPrefs.GetInt("Level_1") > 16) max = 16; else max = PlayerPrefs.GetInt("Level_1"); }
        else if (gameObject.GetComponent<B_controller>().allWorldCount == 2) {  if (PlayerPrefs.GetInt("Level_1") > 22) max = 22; else max = PlayerPrefs.GetInt("Level_1"); }
        else if (gameObject.GetComponent<B_controller>().allWorldCount == 3) { if (PlayerPrefs.GetInt("Level_1") > 28) max = 28; else max = PlayerPrefs.GetInt("Level_1"); }
        else if (gameObject.GetComponent<B_controller>().allWorldCount == 4) {  max = PlayerPrefs.GetInt("Level_1"); }
        for (int i = 0; i < max; i++)
        {
            star[i].GetComponent<Animator>().SetInteger("stars", PlayerPrefs.GetInt("level_" + i));
        }
        //star[PlayerPrefs.GetInt("Level_1")].GetComponent<Animator>().SetInteger("stars", PlayerPrefs.GetInt("level_" + PlayerPrefs.GetInt("Level_1")));
        
    }
}
