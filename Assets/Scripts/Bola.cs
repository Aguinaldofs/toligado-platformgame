using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour
{

    [SerializeField]
    float constante = 0.000000001f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * constante);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Destroy(this.gameObject);
    }
}
