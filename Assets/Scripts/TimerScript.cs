using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //Create timer
    public static float timer = 0.0f;

    //Bool
    bool stopTimer = false;

    //Create displayed timer
    Text text;

    void Awake()
    {
        //Load Text class
        text = GetComponent<Text>();
            DontDestroyOnLoad(this.gameObject);
        

        //Reset the timer
        //timer = 0f;

    }

    void Update()
    {
        //Start the timer and keep it going
        if (!(Application.loadedLevelName.Contains("Transicao")))
        {
            timer += Time.deltaTime;
            text.enabled = true;
        }
        //Write out the timer on the screen
        text.text = "" + timer.ToString("F1");

        /* if (Application.loadedLevelName == "Death Scene")
        {
            text.text = timer.ToString("F1") + " Points";
        }
        */
        if (Application.loadedLevelName == "Menu" || Application.loadedLevelName == "ComoJogar" || Application.loadedLevelName == "Intro" || (Application.loadedLevelName == "CDG"))
        {
            timer = 0.0f;
            text.enabled = false;
            Destroy(GameObject.Find("Canvas Timer"));
        }
        if(Application.loadedLevelName == "DeathScene" || Application.loadedLevelName.Contains("Transicao") || Application.loadedLevelName == "Final")
        {
            text.enabled = false;
        }
    }

}