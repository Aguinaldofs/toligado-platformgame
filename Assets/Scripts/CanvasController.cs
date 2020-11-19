using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController canvasController = null;

    //[SerializeField]
    //GameObject[] coletaveis;

    GameObject[] coletaveis;

    //Implementacao do singleton. Faz o canvas nao se destruido
    void Awake() {
        
        if(canvasController != null) {
           Destroy(gameObject);
        } else {
            canvasController = this;
            DontDestroyOnLoad(gameObject);
        }

        coletaveis = GameObject.FindGameObjectsWithTag("ColetavelCanvas");

    }

    //Desligar o canvas durante as telas de transicao
    public void CanvasLoaded() {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Contains("Transicao") || sceneName.Contains("Menu") || sceneName.Contains("DeathScene") || sceneName.Contains("ComoJogar")
            || sceneName.Contains("Intro") || sceneName.Contains("Final") || sceneName.Contains("CDG") || sceneName.Contains("ToLigado"))
        {
            gameObject.SetActive(false);
        } else
            gameObject.SetActive(true);

    }

    //Metodo para ativar os coletaveis
    public void AtivarColetavel(string nomeColetavel)
    {
        foreach (GameObject coletavel in coletaveis)
        {
            if (coletavel.name.Equals(nomeColetavel))
            {
                coletavel.GetComponent<Image>().enabled = true;
            }
        }
    }
    public void DesativarColetavel()
    {
        foreach (GameObject coletavel in coletaveis)
        {
                coletavel.GetComponent<Image>().enabled = false;
        }
    }
}