using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{

    public CanvasRenderer imgCanvas;
    private ButtonHistory botao;
    public int pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (pos == 0)
            imgCanvas.SetAlpha(1);
        else
            imgCanvas.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        botao = GameObject.Find("Button").GetComponent<ButtonHistory>(); //Salva as informações do item no cenario para o item do canvas
        if (pos == botao.pos)
            imgCanvas.SetAlpha(1);
        else
            imgCanvas.SetAlpha(0);
    }
}
