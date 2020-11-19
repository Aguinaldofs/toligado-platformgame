using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomPhrases : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        string myString = animalDescriptions[Random.Range(0, animalDescriptions.Length)];
        myText.text = myString;
    }
    public string[] animalDescriptions =
{
    "Tome cuidado 'meu bom', não caia na labia deles !",
    "'Cê' se meteu em uma enrascada hein bro, mas pode tentar denovo !",
    "'Fica Frio ai', a gente tá contigo, tente fazer a escolha certa desta vez !",
};
    // Update is called once per frame
    void Update()
    {
        
    }
}
