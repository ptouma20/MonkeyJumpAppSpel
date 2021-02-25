using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_collection : MonoBehaviour
{
    public GameObject shield_icon;
    public Text shield_timing;
    public GameObject replay;
    public Text score_st;
    public GameObject gameOver;
    private int score_num=0;
    public AudioSource banan;
    public AudioSource die_aoudio;
    public GameObject[] hart_plus;
    public GameObject[] hart_minus;
    int H=2;
    int ti_sheald = 0;
    Vector3 retor;
    bool open = true;
    float timing = 0;
    bool shield = false;
    public AudioSource pause;
    public AudioSource shild_music;
    public GameObject shild_effect;
    public GameObject backround_MUSIC;
    void Start()
    {
        backround_MUSIC = GameObject.Find("MUSIC");
        shield_icon.SetActive(false);
    }
    [System.Obsolete]
    private void OnTriggerExit2D(Collider2D collision)
    {
        //open = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shield" && open)
        {
            shield = true;
            shield_icon.SetActive(true);
            banan.Play();
            collision.gameObject.SetActive(false);
            ti_sheald++;
            shield_timing.text = ti_sheald.ToString();
            shild_effect.SetActive(true);
            backround_MUSIC.SetActive(false);
            shild_music.Play();

        }
        else if (shield && open && (collision.gameObject.tag == "die" || collision.gameObject.name == "hinder"
                || collision.gameObject.name == "croc" || collision.gameObject.name == "kl_01"
                || collision.gameObject.name == "dsk_04(Clone)" || collision.gameObject.name == "plant"
                || collision.gameObject.name == "Quad" || collision.gameObject.name == "BallSpines"
                || collision.gameObject.name == "Tiki_Enemy" || collision.gameObject.name == "Enemy_01")) 
             { die_aoudio.Play(); ti_sheald--; shield_timing.text = ti_sheald.ToString(); open = false; if (ti_sheald == 0){ backround_MUSIC.SetActive(true); shild_music.Stop(); shild_effect.SetActive(false); shield = false; shield_icon.SetActive(false); }  }
       else if (collision.gameObject.name == "fall"|| collision.gameObject.name == "Water") { ti_sheald = 0; shild_music.Stop(); backround_MUSIC.SetActive(true); shild_effect.SetActive(false); shield = false; shield_icon.SetActive(false); open = false; die_aoudio.Play();
            if (H > -1)
                hart_minus[H].SetActive(false);
            H--;
            if (H == -1)
            {
                gameOver.SetActive(true);
                gameObject.SetActive(false);
                replay.SetActive(true);
            }
            gameObject.transform.position = retor;}
            if (collision.gameObject.name == "Level_Selection_Door")
        {
            gameObject.GetComponent<player_controller>().runSpeed = 0f;
            gameObject.GetComponent<Animator>().SetBool("finesh", true);
            if (PlayerPrefs.GetInt("Level_1") >= SceneManager.GetActiveScene().buildIndex - 2) { }
            else
            {
                if (SceneManager.GetActiveScene().name == "Level_1 0") { PlayerPrefs.SetInt("Level_1", 1); }
                else if (SceneManager.GetActiveScene().name == "Level_1 1") { PlayerPrefs.SetInt("Level_1", 2); }
                else if (SceneManager.GetActiveScene().name == "Level_1 2") { PlayerPrefs.SetInt("Level_1", 3); }
                else if (SceneManager.GetActiveScene().name == "Level_1 3") { PlayerPrefs.SetInt("Level_1", 4); }
                else if (SceneManager.GetActiveScene().name == "Level_1 4") { PlayerPrefs.SetInt("Level_1", 5); }
                else if (SceneManager.GetActiveScene().name == "Level_1 5") { PlayerPrefs.SetInt("Level_1", 6); }
                else if (SceneManager.GetActiveScene().name == "Level_1 6") { PlayerPrefs.SetInt("Level_1", 7); }
                else if (SceneManager.GetActiveScene().name == "Level_1 7") { PlayerPrefs.SetInt("Level_1", 8); }
                else if (SceneManager.GetActiveScene().name == "Level_1 8") { PlayerPrefs.SetInt("Level_1", 9); }
                else if (SceneManager.GetActiveScene().name == "Level_2 0") { PlayerPrefs.SetInt("Level_1", 11-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 1") { PlayerPrefs.SetInt("Level_1", 12-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 2") { PlayerPrefs.SetInt("Level_1", 13-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 3") { PlayerPrefs.SetInt("Level_1", 14-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 4") { PlayerPrefs.SetInt("Level_1", 15-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 5") { PlayerPrefs.SetInt("Level_1", 16-1); }
                else if (SceneManager.GetActiveScene().name == "Level_2 6") { PlayerPrefs.SetInt("Level_1", 17-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 0") { PlayerPrefs.SetInt("Level_1", 18-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 1") { PlayerPrefs.SetInt("Level_1", 19-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 2") { PlayerPrefs.SetInt("Level_1", 20-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 3") { PlayerPrefs.SetInt("Level_1", 21-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 4") { PlayerPrefs.SetInt("Level_1", 22-1); }
                else if (SceneManager.GetActiveScene().name == "Level_3 5") { PlayerPrefs.SetInt("Level_1", 23-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 0") { PlayerPrefs.SetInt("Level_1", 24-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 1") { PlayerPrefs.SetInt("Level_1", 25-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 2") { PlayerPrefs.SetInt("Level_1", 26-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 3") { PlayerPrefs.SetInt("Level_1", 27-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 4") { PlayerPrefs.SetInt("Level_1", 28-1); }
                else if (SceneManager.GetActiveScene().name == "Level_4 5") { PlayerPrefs.SetInt("Level_1", 29-1); }
                else if (SceneManager.GetActiveScene().name == "Level_5 0") { PlayerPrefs.SetInt("Level_1", 30-1); }
                else if (SceneManager.GetActiveScene().name == "Level_5 1") { PlayerPrefs.SetInt("Level_1", 31-1); }
                else if (SceneManager.GetActiveScene().name == "Level_5 2") { PlayerPrefs.SetInt("Level_1", 32-1); }
            }
            
        }
        if (collision.gameObject.name == "Level_Selection_Door_F") { SceneManager.LoadScene("FINAL"); }
            if (collision.gameObject.name == "banana"|| collision.gameObject.tag == "banan")
        {
            score_num++;
            banan.Play();
            Destroy(collision.gameObject);
        }
        if (!shield)
        {
            if ((collision.gameObject.tag == "die" || collision.gameObject.name == "hinder" || collision.gameObject.name == "fall"
                || collision.gameObject.name == "croc" || collision.gameObject.name == "kl_01"
                || collision.gameObject.name == "dsk_04(Clone)" || collision.gameObject.name == "plant"
                || collision.gameObject.name == "Quad" || collision.gameObject.name == "BallSpines"
                || collision.gameObject.name == "Tiki_Enemy" || collision.gameObject.name == "Enemy_01") && open)
            {
                die_aoudio.Play();
                open = false;
                if (H > -1)
                    hart_minus[H].SetActive(false);
                H--;
                if (H == -1)
                {
                    Time.timeScale = 0;
                    gameOver.SetActive(true);
                    gameObject.SetActive(false);
                    replay.SetActive(true);
                }
                gameObject.transform.position = retor;
            }
        }
        if (collision.gameObject.name == "hart")
        {
            
            H++;
            if (H > 2)
                H = 2;
            hart_minus[H].SetActive(true);

            banan.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "icon_jungle_statue@2x")
        {
            retor = collision.gameObject.transform.position;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(shield && collision.gameObject.name == "dsk_04(Clone)" && open)
        {
            die_aoudio.Play(); ti_sheald--; shield_timing.text = ti_sheald.ToString(); open = false; if (ti_sheald == 0) { backround_MUSIC.SetActive(true); shild_music.Stop(); shild_effect.SetActive(false); shield = false; shield_icon.SetActive(false); }
        }
        else if (collision.gameObject.name == "dsk_04(Clone)" && open)
        {
            open = false;
            die_aoudio.Play();
            hart_minus[H].SetActive(false);
            H--;
            if (H == -1)
            {
                Time.timeScale = 0;
                gameOver.SetActive(true);
                gameObject.SetActive(false);
                replay.SetActive(true);
            }
            gameObject.transform.position = retor;
        }
    }
    private void Update()
    {
        score_st.text = "           "+score_num.ToString();
        if (!open)
        {
            timing += Time.deltaTime;
            if (timing >= 1f)
            {
                timing = 0f;
                open = true;
            }
        }
        /*if (shield)
        {
            timing += Time.deltaTime;
            int ti = (int)timing;
            shield_timing.text = ti.ToString();
            if (timing >= 8f)
            {
                shield = false;
                timing = 0f;
                shield_icon.SetActive(false);
            }
        }*/
    }

    [System.Obsolete]
    public void replay_b()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    [System.Obsolete]
    public void start_menu()
    {
        Time.timeScale = 1;
        gameObject.transform.FindChild("ADMOB").GetComponent<GoogleMobileAdsDemoScript>().reset_close();
        SceneManager.LoadScene("START_1");

    }
    public void puse()
    {
        pause.Play();
        if (!replay.activeSelf) { replay.SetActive(true); Time.timeScale = 0; }
        else { replay.SetActive(false); Time.timeScale = 1; }
    }

    [System.Obsolete]
    public void finesh()
    {
        PlayerPrefs.SetInt("level_" + (SceneManager.GetActiveScene().buildIndex - 3).ToString(), score_num / 15);
        int bannan = PlayerPrefs.GetInt("banana");
        PlayerPrefs.SetInt("banana",bannan + score_num);
        PlayerPrefs.SetInt("bunos", 0);
        PlayerPrefs.SetInt("bunos", score_num);
        gameObject.GetComponent<player_controller>().play = false;
        gameObject.transform.FindChild("ADMOB").GetComponent<GoogleMobileAdsDemoScript>().reset_close();
        SceneManager.LoadScene("Bunos");

    }
    public void show_to_get_hart()
    {
        H++;
        hart_minus[H].SetActive(true);
        gameOver.SetActive(false);
        gameObject.SetActive(true);
        replay.SetActive(false);
        Time.timeScale = 1;
    }
}
