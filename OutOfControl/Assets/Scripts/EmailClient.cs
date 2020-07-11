using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EmailClient
{
    // The list of emails left to respond to
    private List<Email> inbox;

    // The email currently displayed in the inbox area
    private Email activeEmail;

    // The index of the current active email
    private int activeEmailIndex;

    public EmailClient()
    {
        this.inbox = new List<Email>();
        this.activeEmail = null;
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
    }

    /// <summary>
    /// Sets the active email to be either one up or down
    /// </summary>
    /// <param name="up"></param>
    public void setNextEmailActive(bool up)
    {
        if (up && activeEmailIndex > 0)
        {
            activeEmailIndex--;
        }
        else if (!up && activeEmailIndex < this.inbox.Count)
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
        this.inbox.Add(e);
        if (this.activeEmail == null)
        {
            this.activeEmail = e;
        }
    }

    /// <summary>
    /// Submit the active email for evaluation
    /// </summary>
    public int submitEmail()
    {
        string userInput = this.activeEmail.getUserText();
        Email e = this.getActiveEmail();
        // Check to see if keywords are included
        bool keywordMatch = e.hasKeywords(userInput);

        //Score this email
        int scoreModifier = e.scoreResponse(userInput);
        //TODO: Do something with the score

        // Remove it from the inbox
        inbox.Remove(e);

        if (!keywordMatch)
        {
            // Set replied 
            e.setReplied();
            // Add this email to the inbox so they have to deal with it again
            this.inbox.Add(e);
        }

        return scoreModifier;
    }
}
