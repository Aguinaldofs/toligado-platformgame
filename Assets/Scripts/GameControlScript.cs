using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    //Visible in the editor
    [SerializeField]
    CanvasController mainCanvas;
    Scene m_Scene;
    string sceneName;
    public static GameObject xisde;

    //Singleton
    public static GameControlScript gameControlScript = null;

    public static List<GameObject> hearts;
    // gameOver;
    public static int health;
    ControllerPlayer playerControl;
    
    private bool isCoroutineExecuting = false;

    private int maxHealth = 3;

    private void Awake()
    {
        if (gameControlScript != null) {
            Destroy(gameObject);
        } else {
            gameControlScript = this;
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += Loadedscene;

    }

    void Loadedscene(Scene scene, LoadSceneMode mode) {

        playerControl = FindObjectOfType<ControllerPlayer>();
        mainCanvas.CanvasLoaded();
       
    }
    private void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
            {
                print("joystick 1 button " + i);
            }
        }
        for (int i = 0; i < maxHealth; i++)
        {
            mainCanvas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }
        sceneName = SceneManager.GetActiveScene().name;
        if (!(sceneName.Contains("Transicao") || sceneName.Contains("Menu") || sceneName.Contains("DeathScene") || sceneName.Contains("ComoJogar") || sceneName.Contains("Intro")))
        {
            for (int i = 0; i < health; i++)
            {
                mainCanvas.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);

            }
        }
        
    }
    void Start()
    {
        health = 3;
        //Buscar vida na Scene
        //PreencheListaVida();
    }

    public void DeleteHeart()
    { 
        if (health > 0)
        {
            health--;
            //hearts[health].SetActive(false);
        }
        if (health < 1) {
            //playerControl.playerMorreu();
            //StartCoroutine(Example());
            health = 3;
            //PreencheListaVida();
            SceneManager.LoadScene("DeathScene");
            //Destroy(gameObject);
        }
    }

    public void PreencheListaVida() {
        hearts.Clear();
        for (int i = 1; i < health + 1; i++) {
             hearts.Add(GameObject.Find("Vida" + i));
            
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(10000000);
        print(Time.time);
    }
}
