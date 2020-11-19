using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocidade;
    private Transform player;
    public float smoothTimeX;
    public float smoothTimeY;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();    
    }
    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocidade.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocidade.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
