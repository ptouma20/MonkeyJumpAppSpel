using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class B_controller : MonoBehaviour
{
    public GameObject info_panel;
    public AudioSource button_sound;
    public GameObject level_pekare;
    public GameObject[] Lock;
    public GameObject[] allWorlds;
    public int allWorldCount =0;
    float timing;
    float timing_play;
    bool once = true;
    bool play_till = false;
    bool[] level_till;

    public Animator banan;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if(SceneManager.GetActiveScene().name == "Levels")
        {
            return_to_levels();
        }
    }
    private void Update()
    {
        timing += Time.deltaTime;

        if(timing>= 1f && once && SceneManager.GetActiveScene().name == "Levels")
        {
            
            if (PlayerPrefs.GetInt("Level_1") == 32) { }
            else
            {
                for (int i = 0; i <= PlayerPrefs.GetInt("Level_1") - 1; i++)
                {
                    Lock[i].GetComponent<Animator>().SetBool("unlock", true);
                    Destroy(Lock[i],4f);
                }
            }
            int pecka = PlayerPrefs.GetInt("Level_1") + 1;
            if(pecka > 9)
            {
                pecka = 9;
            }
           // level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
            once = false;
        }
        if (play_till)
        {
            timing_play += Time.deltaTime;
            
            banan.SetBool("start",true);
            if (timing_play > 1f)
            {
                SceneManager.LoadScene("Levels");
            }
        }
    }
    public void Play()
    {
        button_sound.Play();
        play_till = true;
    }
    public void info()
    {
        button_sound.Play();
        if (info_panel.activeSelf)
        {
            info_panel.SetActive(false);
        }
        else
        {
            info_panel.SetActive(true);
        }
    }
    public void shop()
    {
        button_sound.Play();
        SceneManager.LoadScene("shop");
    }
    public void exit()
    {
        Application.Quit();
    }

    public void Level_select()
    {
        button_sound.Play();
        string name = EventSystem.current.currentSelectedGameObject.name;

        SceneManager.LoadScene(name);
    }

    public void Back()
    {
        level_pekare.GetComponent<Animator>().Play("map_levels", -1, 0f);
        allWorldCount--;
        if (allWorldCount < 0)
        {
            button_sound.Play();
            SceneManager.LoadScene("START_1");
        }
        else
        {
            for (int i = 0; i < allWorlds.Length; i++) { allWorlds[i].SetActive(false); }
            allWorlds[allWorldCount].SetActive(true);
            int pecka = 0;
            switch (allWorldCount)
            {
                case 0:
                    pecka = PlayerPrefs.GetInt("Level_1") + 1;
                    level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                    break;
                case 1:
                    pecka = PlayerPrefs.GetInt("Level_1") + 1 - 9;
                    level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                    break;
                case 2:
                    pecka = PlayerPrefs.GetInt("Level_1") + 1 - 16;
                    level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                    break;
                case 3:
                    pecka = PlayerPrefs.GetInt("Level_1") + 1 - 22;
                    level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                    break;
                case 4:
                    pecka = PlayerPrefs.GetInt("Level_1") + 1 - 28;
                    level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                    break;

            }
            gameObject.GetComponent<stars>().stars_call();
        }


    }
    public void next_world()
    {
        level_pekare.GetComponent<Animator>().Play("map_levels", -1,0f);
        allWorldCount++;
        if (allWorldCount == 5) { allWorldCount = 0; }
        for (int i = 0; i < allWorlds.Length; i++) { allWorlds[i].SetActive(false); }
        allWorlds[allWorldCount].SetActive(true);
        int pecka = 0;
        switch (allWorldCount)
        {
            case 0:
                pecka = PlayerPrefs.GetInt("Level_1") + 1;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 1:
                pecka = PlayerPrefs.GetInt("Level_1") + 1-9;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 2:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 16;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 3:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 22;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 4:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 28;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;

        }
        gameObject.GetComponent<stars>().stars_call();
    }
    public void reset_levels()
    {
        PlayerPrefs.SetInt("Level_1", 0);
        PlayerPrefs.SetInt("banana", 0);
    }
    private void return_to_levels()
    {
 
        if (PlayerPrefs.GetInt("Level_1") < 9) { allWorldCount = 0; allWorlds[allWorldCount].SetActive(true); }
        else if (PlayerPrefs.GetInt("Level_1") > 9 && PlayerPrefs.GetInt("Level_1") < 17) { allWorldCount =1; allWorlds[allWorldCount].SetActive(true); }
        else if (PlayerPrefs.GetInt("Level_1") > 16 && PlayerPrefs.GetInt("Level_1") < 23) { allWorldCount=2; allWorlds[allWorldCount].SetActive(true); }
        else if (PlayerPrefs.GetInt("Level_1") > 22 && PlayerPrefs.GetInt("Level_1") < 29) { allWorldCount=3; allWorlds[allWorldCount].SetActive(true); }
        else if (PlayerPrefs.GetInt("Level_1") > 28) { allWorldCount = 4; allWorlds[allWorldCount].SetActive(true); }
        int pecka = 0;
        switch (allWorldCount)
        {
            case 0:
                pecka = PlayerPrefs.GetInt("Level_1") + 1;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 1:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 9;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 2:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 16;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 3:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 22;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;
            case 4:
                pecka = PlayerPrefs.GetInt("Level_1") + 1 - 28;
                level_pekare.GetComponent<Animator>().SetInteger("level", pecka);
                break;

        }
        gameObject.GetComponent<stars>().stars_call();

    }
}
