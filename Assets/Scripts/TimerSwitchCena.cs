using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSwitchCena : MonoBehaviour
{
    public bool timer = false;
    public float tempo = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = true;
        if (timer)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 0)
            {
                timer = false;
                tempo = 5;
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex + 1);
            }
        }
    }
}
