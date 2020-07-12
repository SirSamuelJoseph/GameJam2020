using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private EmailClient client;
    public Text userInputBox;
    public Text userPromptBox;
    public Text activeInboxMessage;
    public Text activeInboxSender;
    public int score;
    public Initialization init;
    public NoiseManager sounds;
    public GameObject[] newEmailIndicators;

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
            foreach(char c in Input.inputString)
            {
                if (c == '\b')
                {
                    this.client.backspace();
                }
                else if (c == '\r')
                {
                    this.submitCurrentEmail();
                }
                else
                {
                    this.client.addCharacter(c);
                }
            }

            userInputBox.text = this.client.getActiveEmail().getUserText();
        }

        userPromptBox.text = this.client.getActiveEmail().getResponseBody();
        activeInboxMessage.text = this.client.getActiveEmail().getEmailBody();
        activeInboxSender.text = "<b>FROM</b>: " + this.client.getActiveEmail().getSender();
        this.checkForNewEmailSymbol();

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

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && Input.GetKey(KeyCode.UpArrow))
        {
            this.setNextEmailActive(true);
        }
        else if (e.isKey && Input.GetKey(KeyCode.DownArrow))
        {
            this.setNextEmailActive(true);
        }
    }

    private void checkForNewEmailSymbol()
    {
        for(int i = 0; i < 2; i ++)
        {
            Email e = this.client.getEmailAtIndex(i);
            if (!e.hasBeenOpened())
            {
                this.newEmailIndicators[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                Debug.Log("opened");
                this.newEmailIndicators[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

}
