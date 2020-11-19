using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falaPersonagem : MonoBehaviour
{

    public CanvasRenderer falaPers;
    public Collider2D falaCollider;
    private float tempo = 5;
    public bool timer = false;

    // Start is called before the first frame update
    void Start()
    {
        falaPers.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (falaCollider.IsTouchingLayers(LayerMask.GetMask("player")))
        {
            falaPers.SetAlpha(1);
            timer = true;

        }
        if (timer)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 0) {
                falaPers.SetAlpha(0);
                timer = false;
                tempo = 5;
            }
        }
    }

}
