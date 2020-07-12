using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private EmailClient client;
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
        userInputBox.text = this.client.getActiveEmail().getUserText();
        if (Input.anyKeyDown)
        {
            while (Input.GetKey(KeyCode.Backspace))
            {
                this.client.backspace();
            }

            foreach(char c in Input.inputString)
            {
                if (c == '\b')
                {
                    this.client.backspace();
                    Debug.Log("back");
                }
                else if (c == '\r')
                {
                    this.submitCurrentEmail();
                    Debug.Log("Submitted");
                }
                else
                {
                    this.client.addCharacter(c);
                }
            }

            userInputBox.text = this.client.getActiveEmail().getUserText();
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
