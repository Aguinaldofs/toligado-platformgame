using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public Transform objTransform;
    public BoxCollider2D objCollider;

    public float posInicial, posFinal;
    bool op = false;
    public bool canvasON = false;
    public bool cena = false;

    CanvasController canvasController;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = objTransform.position.y;
        posFinal = posInicial + 2;

        canvasController = FindObjectOfType<CanvasController>();
        if(cena)
            canvasController.DesativarColetavel();
    }

    // Update is called once per frame
    void Update()
    {
        moveObj();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvasController.AtivarColetavel(gameObject.tag);
            TimerScript.timer = TimerScript.timer - 30;
            Destroy(gameObject);
        }
    }

    
    private void moveObj()
    {
        if (op)
        {
            objTransform.position -= new Vector3(0, 0.03f, 0);
        }
        else
        {
            objTransform.position += new Vector3(0, 0.03f, 0);
        }

        if (objTransform.position.y >= posFinal)
        {
            op = true;
        }
        if (objTransform.position.y <= posInicial)
        {
            op = false;
        }
    }
}
