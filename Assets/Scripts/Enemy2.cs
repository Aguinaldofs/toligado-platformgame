using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Animator anime;
    public Transform Enemy;
    private bool andar = false, correr = false;
    private int direcao;
    public float posInicial = 0, posFinal;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = Enemy.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (direcao == 1)
        {
            Enemy.localScale = new Vector3(-1, 1, 1);
            andar = true;
            correr = false;

            if (Enemy.position.x <= (posInicial - posFinal*0.20))
            {
                correr = true;
                andar = false;
                Enemy.position -= new Vector3(0.30f, 0, 0);
            }
            else
            {
                Enemy.position -= new Vector3(0.10f, 0, 0);
            }
        }
        else if (direcao == 0)
        {
            Enemy.localScale = new Vector3(1, 1, 1);
            andar = true;
            correr = false;

            if (Enemy.position.x >= (posInicial - posFinal*0.80))
            {
                correr = true;
                andar = false;
                Enemy.position += new Vector3(0.30f, 0, 0);
            }
            else
            {
                Enemy.position += new Vector3(0.10f, 0, 0);
            }
        }

        if (Enemy.position.x >= posInicial)
        {
            direcao = 1;
        }

        if (Enemy.position.x <= (posInicial - posFinal))
        {
            direcao = 0;
        }

        anime.SetBool("Andar", andar);
        anime.SetBool("Correr", correr);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);        
    }
}
