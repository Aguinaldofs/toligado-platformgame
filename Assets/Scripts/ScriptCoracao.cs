using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCoracao : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocidade;
    private Transform player;

    public float smoothTimeX;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocidade.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.position.x, ref velocidade.x, smoothTimeX);
        transform.position = new Vector3(posX, posy, transform.position.z);
        
    }
}

