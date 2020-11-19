using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasRenderer TextBox;
    public Collider2D hitBoxCollider;
    public bool botao = false;

    void Start()
    {
        TextBox.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitBoxCollider.IsTouchingLayers(LayerMask.GetMask("player")))
        {
            TextBox.SetAlpha(1);
            botao = true;
        }
    }

    public void Destruir() {
        if (botao == true)
        {
            //Destroy(GameObject.Find("BoxPanel"));
            TextBox.SetAlpha(0);
            botao = true;
        }
        else {
            botao = false;
        }

    }
}
