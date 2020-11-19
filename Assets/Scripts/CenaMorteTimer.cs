using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenaMorteTimer : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public static float timer = 0f;
    void Start()
    {
        timer = TimerScript.timer;
        text = GetComponent<Text>();
        text.text = "" + timer.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
