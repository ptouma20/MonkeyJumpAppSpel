using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LEVEL_selection : MonoBehaviour
{
    public Button easy;
    public Button medium;
    public Button hard;
    private PointerEventData pointer = new PointerEventData(EventSystem.current);
    void Start()
    {
        if(PlayerPrefs.GetString("level_select") == "E")
        {
            ExecuteEvents.Execute(easy.gameObject, pointer, ExecuteEvents.pointerClickHandler);
        }
        else if (PlayerPrefs.GetString("level_select") == "M")
        {
            ExecuteEvents.Execute(medium.gameObject, pointer, ExecuteEvents.pointerClickHandler);
        }
        else if (PlayerPrefs.GetString("level_select") == "H")
        {
            ExecuteEvents.Execute(hard.gameObject, pointer, ExecuteEvents.pointerClickHandler);
        }
        else { PlayerPrefs.SetString("level_select", "E"); }
    }
    public void Easy_button()
    {
        ExecuteEvents.Execute(medium.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(hard.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        PlayerPrefs.SetString("level_select", "E");
    }
    public void Medium_button()
    {
        ExecuteEvents.Execute(easy.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(hard.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        PlayerPrefs.SetString("level_select", "M");
    }
    public void Hard_button()
    {
        ExecuteEvents.Execute(medium.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(easy.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        PlayerPrefs.SetString("level_select", "H");
    }
}
