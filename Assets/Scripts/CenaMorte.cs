using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaMorte : MonoBehaviour
{
    public bool timer = false;
    private float tempo = 10;
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
                tempo = 10;
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
