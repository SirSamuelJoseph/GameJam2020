using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private EmailClient client;
    public Text activeEmailBodyLocation;
    public Text activeEmailSenderLocation;
    public Text activeEmailSubjectLocation;
    public Text userInputBox;
    public int score;



    // Start is called before the first frame update
    void Start()
    {
        this.client = new EmailClient();
        this.client.addEmailToInbox(new Email());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string s = Input.inputString;
            Debug.Log(s.Length);

            if (s == "\r") {
                this.submitCurrentEmail();
                Debug.Log("Submitted");
            }

            foreach(char c in s)
            {
                this.client.addCharacter(c);
            }
        }

        if (score < 0)
        {
            gameOver();
        }
    }

    /// <summary>
    /// Submits the current email and updates the user's score accordingly
    /// </summary>
    public void submitCurrentEmail()
    {
        score += this.client.submitEmail();
    }

    /// <summary>
    /// Called when the user's score goes below 0
    /// </summary>
    public void gameOver()
    {

    }
}
