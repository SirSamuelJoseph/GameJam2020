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
    public Initialization init;
    public NoiseManager sounds;

    const int NUMBER_OF_CONTACTS = 2;



    // Start is called before the first frame update
    void Start()
    {
        this.score = 100;
        this.client = new EmailClient(init);
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
        Debug.Log(score);
    }

    /// <summary>
    /// Called when the user's score goes below 0
    /// </summary>
    public void gameOver()
    {

    }

    public void addEmailToEmailClientInbox(Email e)
    {
        this.client.addEmailToInbox(e);
        sounds.playNewEmailNoise();
        Debug.Log(e.hasBeenRepliedTo());
    }

    public void setNextEmailActive(bool up)
    {
        this.client.setNextEmailActive(up);
    }

}
