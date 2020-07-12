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
    public float score;
    public Slider scoreSlider;
    public Initialization init;
    public NoiseManager sounds;
    public Cat cat;

    const int NUMBER_OF_CONTACTS = 2;



    // Start is called before the first frame update
    void Start()
    {
        this.score = 100f;
        this.client = new EmailClient(init);
        StartCoroutine(UpdateScoreSlider());
    }

    // Update is called once per frame
    void Update()
    {

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
                    Debug.Log("submit attempt");
                    this.submitCurrentEmail();
                    cat.speedUpCat();
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

        this.updateDisplay();
    }

    /// <summary>
    /// Submits the current email and updates the user's score accordingly
    /// </summary>
    public void submitCurrentEmail()
    {
        int mod = this.client.submitEmail();
        score += mod;
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
    }

    public void setNextEmailActive(bool up)
    {
        this.client.setNextEmailActive(up);
        this.updateDisplay();
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
            this.setNextEmailActive(false);
        }
    }

    public IEnumerator UpdateScoreSlider()
    {

        while (score > 0)
        {
            int numOfEmails = init.numberOfEmailsSent;
            float dropRatePerSecond = ((float)numOfEmails) / 3;
            this.score -= dropRatePerSecond;
            this.scoreSlider.value = 100f - this.score;
            yield return new WaitForSeconds(1);
        }


    }

    public void addCharToClient(char c)
    {
        this.client.addCharacter(c);
    }

    public void updateDisplay()
    {
        userPromptBox.text = this.client.getActiveEmail().getResponseBody();

        if (!this.client.getActiveEmail().hasBeenRepliedTo())
        {
            activeInboxMessage.text = this.client.getActiveEmail().getEmailBody();
        }
        else
        {
            activeInboxMessage.text = this.client.getActiveEmail().getBadResponseBody();
        }


        activeInboxSender.text = "<b>FROM</b>: " + this.client.getActiveEmail().getSender();
    }
}
