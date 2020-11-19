using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumaca : MonoBehaviour
{
    PolygonCollider2D fumacaPolygonCollider;
    SpriteRenderer fumacaSpriteRender;

    string spriteName;

    // Start is called before the first frame update
    void Start()
    {
        fumacaPolygonCollider = GetComponent<PolygonCollider2D>();
        fumacaSpriteRender = GetComponent<SpriteRenderer>();

        spriteName = fumacaSpriteRender.sprite.name;
        InvokeRepeating("checkSpriteChanged",0.05f,0.05f);

       
        //fumacaBoxCollider.offset = new Vector2((S.x / 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        fumacaPolygonCollider.autoTiling = true; 
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //print(collision.name);
    }

    void checkSpriteChanged() {

        if (!spriteName.Equals(fumacaSpriteRender.sprite.name)) {//Verifica se sprite alterou
            spriteName = fumacaSpriteRender.sprite.name;
            //Atualiza collider, pois mudou a imagem do sprite
            Destroy(fumacaPolygonCollider);
            fumacaPolygonCollider = gameObject.AddComponent<PolygonCollider2D>();
            fumacaPolygonCollider.isTrigger = true;
            fumacaPolygonCollider.autoTiling = true;
            //print("Mudou Sprite");

        }
    }
}
