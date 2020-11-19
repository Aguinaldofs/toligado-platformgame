using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScriptIntro : MonoBehaviour
{
    public Button button;
    public Sprite Image1;
    float currCountdownValue;

    GameControlScript gameCtrl;
    private void OnMouseUpAsButton()
    {
        ChangeScene("#1");
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button11))
        {
            this.GetComponent<Image>().sprite = Image1;
            StartCoroutine(StartCountdown());
            ChangeScene("#1");

        }
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(3.0f);
            currCountdownValue--;
        }
    }
}
