using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button startGame;
    public Button credits;
    public Button gimmeCat;
    public TitleScreenCat cat;

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        });

        credits.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        });

        gimmeCat.onClick.AddListener(() =>
        {
            cat.enableCat();

            if (gimmeCat.GetComponentInChildren<Text>().text == "Gimme Cat now")
            {
                cat.enableCat();
                gimmeCat.GetComponentInChildren<Text>().text = "Scat, cat!";
            }
            else
            {
                gimmeCat.GetComponentInChildren<Text>().text = "Gimme Cat now";
                cat.disableCat();
            }

            
        });
    }

}
