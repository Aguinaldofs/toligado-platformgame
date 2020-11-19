using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHistory : MonoBehaviour
{
    public int pos = 0,max;


    public void Proximo() {
        pos++;
        if (pos == max) {
            Destroy(GameObject.Find("HistoryPanel"));
        }
    }
}
