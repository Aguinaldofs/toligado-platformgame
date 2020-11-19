using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Coletaveis_Canvas : MonoBehaviour
{
    public CanvasRenderer objCanvas;
    private Coletaveis coletaveis;
    public string objeto;
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        objCanvas.SetAlpha(0);              //Deixa item no canvas invisivel
    }

    // Update is called once per frame
    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        coletaveis = GameObject.Find(objeto).GetComponent<Coletaveis>(); //Salva as informações do item no cenario para o item do canvas

        if (sceneIndex == 12) {
            objCanvas.SetAlpha(0);
            coletaveis.canvasON = false;
        }

       // if (coletaveis.canvasON)
       // {
       //     objCanvas.SetAlpha(0.8f);                   //Opacidade do itme no canvas
       //     Destroy(GameObject.Find(objeto));         //Destroi item no cenario
       // }
    }
}