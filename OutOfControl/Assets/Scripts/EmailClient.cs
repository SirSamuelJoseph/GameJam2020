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

    // The text that the user has typed. Updates in real time
    private StringBuilder userTypedText;

    // The current position of the user's cursor
    private int cursorPosition;

    public EmailClient()
    {
        this.inbox = new List<Email>();
        this.activeEmail = null;
        this.userTypedText = new StringBuilder();
        this.cursorPosition = 0;
    }

    /// <summary>
    /// Adds a character to the user inputted text
    /// </summary>
    /// <param name="character">The character to add</param>
    public void addCharacter(char character)
    {
        this.userTypedText.Append(character);
    }

    /// <summary>
    /// Moves the user's cursor one spot, as long as it isn't at either end
    /// </summary>
    /// <param name="left"></param>
    public void moveCursor(bool left)
    {
        if (left && this.cursorPosition > 0)
        {
            this.cursorPosition -= 1;
        }
        else if (this.cursorPosition < this.userTypedText.Length)
        {
            this.cursorPosition += 1;
        }
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
    /// Sets the active email to the first email in the inbox
    /// </summary>
    public void setActiveEmailToFirstEmail()
    {
        this.activeEmail = inbox[0];
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
        string userInput = this.userTypedText.ToString();
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

        // Make the first remaining email the active email
        this.setActiveEmailToFirstEmail();

        // Clear the user's typed area
        this.userTypedText = new StringBuilder();

        return scoreModifier;
    }

    /// <summary>
    /// Returns the text the user has typed
    /// </summary>
    /// <returns>The string representation of what the user typed</returns>
    public string getUserText()
    {
        return this.userTypedText.ToString();
    }
}
