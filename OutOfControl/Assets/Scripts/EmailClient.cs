using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EmailClient
{
    // The list of emails left to respond to
    private Email[] inbox;

    // The email currently displayed in the inbox area
    private Email activeEmail;

    // The index of the current active email
    private int activeEmailIndex;

    public Initialization init;
    public GameObject main;

    public EmailClient(Initialization init)
    {
        this.inbox = new Email[2];
        this.activeEmail = null;
        this.init = init;
        main = GameObject.FindGameObjectWithTag("main");
    }

    /// <summary>
    /// Adds a character to the user inputted text
    /// </summary>
    /// <param name="character">The character to add</param>
    public void addCharacter(char character)
    {
        this.activeEmail.addCharacterToUserInput(character);
    }

    /// <summary>
    /// Sets the active email to be the given email
    /// </summary>
    /// <param name="e">The email to set active</param>
    public void setActiveEmail(Email e)
    {
        this.activeEmail = e;
        e.setOpened();
    }

    /// <summary>
    /// Sets the active email to be either one up or down
    /// </summary>
    /// <param name="up"></param>
    public void setNextEmailActive(bool up)
    {
        if (up && activeEmailIndex > 0 && this.inbox[activeEmailIndex - 1] != null)
        {
            activeEmailIndex--;
        }
        else if (!up && activeEmailIndex < this.inbox.Length - 1 && this.inbox[activeEmailIndex + 1] != null)
        {
            activeEmailIndex++;
        }
        this.setActiveEmail(inbox[activeEmailIndex]);
    }


    /// <summary>
    /// Gets the currently active email
    /// </summary>
    /// <returns>The active email</returns>
    public Email getActiveEmail()
    {
        return this.activeEmail;
    }

    /// <summary>
    /// Adds an email to the user's inbox
    /// </summary>
    /// <param name="e">The email to add to the box</param>
    public void addEmailToInbox(Email e)
    {
        int senderIndex = this.senderNameToInboxPosition(e.getSender());
        this.inbox[senderIndex] = e;
        if (this.activeEmail == null)
        {
            this.activeEmail = e;
        }
        main.GetComponent<main>().updateDisplay();
    }

    /// <summary>
    /// Submit the active email for evaluation
    /// </summary>
    public int submitEmail()
    {
        string userInput = this.activeEmail.getUserText();
        Email e = this.getActiveEmail();
        // Check to see if keywords are included
        bool keywordMatch = e.hasKeywords(userInput.ToLower());

        //Score this email
        int scoreModifier = e.scoreResponse(userInput.ToLower());

        e.setOpened();

        if (!keywordMatch && !e.hasBeenRepliedTo() && e.getBadResponseBody() != "")
        {
            // Add this email to the inbox so they have to deal with it again
            // Set replied 
            e.setReplied();
            e.resetUserText();
            init.waitAndSend(2f, e);
        }
        else
        {
            int senderIndex = this.senderNameToInboxPosition(e.getSender());
            init.setSenderReadyForNext(this.senderNameToInboxPosition(e.getSender()));
            e.resetUserText();

        }


        return scoreModifier;
    }

    private int senderNameToInboxPosition(string senderName)
    {
        switch(senderName)
        {
            case "Roomie":
                return 0;
            case "Bart Burly":
                return 1;
            case "Jasmine Shuratea":
                return 2;
            case "Jefferey I. Tee":
                return 3;
            case "Alexandra Ginsburg":
                return 4;
            default:
                return -1;
        }
    }

    public void backspace()
    {
        this.activeEmail.backspace();
    }

    public Email getEmailAtIndex(int index)
    {
        return this.inbox[index];
    }
}
