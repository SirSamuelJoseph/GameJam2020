using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Button titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        titleScreen.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
