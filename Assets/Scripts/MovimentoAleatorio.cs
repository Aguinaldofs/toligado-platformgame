using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAleatorio : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anime;
    public Transform Enemy;
    public bool andar = false;
    private int direcao;
    private int cont = 0;

    void Start()
    {

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        cont++;
        if (cont > 75) {
            direcao = Random.RandomRange(0, 5);
            cont = 0;
        }


        if (direcao == 1 || direcao == 3){
            Enemy.localScale = new Vector3(-1, 1, 1);
            andar = true;
            Enemy.position -= new Vector3(0.03f, 0, 0);
        }
        else if (direcao == 2 || direcao == 4){
            Enemy.localScale = new Vector3(1, 1, 1);
            andar = true;
            Enemy.position += new Vector3(0.03f, 0, 0);
        }
        else{
            andar = false;
        }

        if (Enemy.position.x >= 4.7f) {
            Enemy.position = new Vector3(4.7f, transform.position.y, 0);
            andar = false;
        }

        if (Enemy.position.x <= -1)
        {
            Enemy.position = new Vector3(-1, transform.position.y, 0);
            andar = false;
        }

        anime.SetBool("Andar", andar);
    }
}
