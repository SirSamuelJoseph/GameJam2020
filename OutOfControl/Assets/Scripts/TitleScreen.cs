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

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        });

        credits.onClick.AddListener(() =>
        {

        });

        gimmeCat.onClick.AddListener(() =>
        {

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
