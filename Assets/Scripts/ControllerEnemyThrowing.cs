using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemyThrowing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject cerveja;
    static float timer = 0;
    public float tempoinicial = 1.2f;
    public float tempofinal = 2.5f;
    void Start()
    {
        //Instantiate(cerveja);
        InvokeRepeating("JogaBola", tempoinicial, tempofinal);
        //InvokeRepeating("JogaBola", 1.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void JogaBola()
    {
        //print("Jogando a Bola");
        //Debug.Log(transform.localScale.x);
        Quaternion targetRotation = transform.rotation;
        if (transform.localScale.x == -1)
            targetRotation = targetRotation * Quaternion.Euler(0, 180f, 0);
        Instantiate(cerveja,transform.position,targetRotation);
        

    }
}
