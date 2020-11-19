using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch: MonoBehaviour
{
    public BoxCollider2D colisor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colisor.IsTouchingLayers(LayerMask.GetMask("player"))) { 
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex+1);
        } 
    }
}
