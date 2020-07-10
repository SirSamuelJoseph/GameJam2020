using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email
{
    // The person sending the email
    private string sender;
    // True if the email has been opened
    private bool opened;
    // True if the user has replied to the email
    private bool replied;
    // Preview text displayed before email is opened
    private string previewText;
    // The subject of the email
    private string subject;
    // Email body content
    private string emailBody;
    // Response guide that the user types along to
    private string responseBody;
    // The keywords which must be in the email for the response to be considered acceptable
    private string[] keywords;
    // If the user sends a response without the keywords, the email re-appears in the inbox with this body
    private string badResponseBody;


    private int counter = 0;

    /// <summary>
    /// Creates a new email, assumed to be unopened and unreplied-to
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="previewText"></param>
    /// <param name="emailBody"></param>
    /// <param name="responseBody"></param>
    /// <param name="badResponseBody"></param>
    public Email(string sender, string previewText, string emailBody, string responseBody, string badResponseBody, string subject)
    {
        this.sender = sender;
        this.opened = false;
        this.replied = false;
        this.previewText = previewText;
        this.emailBody = emailBody;
        this.responseBody = responseBody;
        this.badResponseBody = badResponseBody;
        this.subject = subject;

    }

    public Email()
    {
        this.sender = "A";
        this.opened = false;
        this.replied = false;
        this.previewText = "prev";
        this.emailBody = "bod";
        this.responseBody = "type this";
        this.badResponseBody = "bad boy";
        this.subject = "facts";

    }

    public Email(bool t)
    {
        this.sender = "B";
        this.opened = false;
        this.replied = false;
        this.previewText = "prev";
        this.emailBody = "bod";
        this.responseBody = "type this";
        this.badResponseBody = "bad boy";
        this.subject = "facts";

    }

    /// <summary>
    /// Gets the sender of this email
    /// </summary>
    /// <returns>The string name of the sender of this email</returns>
    public string getSender()
    {
        return this.sender;
    }

    /// <summary>
    /// Gets the preview text for this email
    /// </summary>
    /// <returns></returns>
    public string getPreviewText()
    {
        return this.previewText;
    }

    /// <summary>
    /// Gets the body of the email sent to the player
    /// </summary>
    /// <returns>The body of the email</returns>
    public string getEmailBody()
    {
        return this.emailBody;
    }

    /// <summary>
    /// Gets the subject of this email
    /// </summary>
    /// <returns>The subject of the email</returns>
    public string getSubject()
    {
        return this.subject;
    }

    /// <summary>
    /// Returns true if the user inputted string has the required keywords
    /// </summary>
    /// <param name="userInput">The string the user inputted</param>
    /// <returns></returns>
    public bool hasKeywords(string userInput)
    {
        foreach(string key in this.keywords)
        {
            if (!userInput.Contains(key))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Scores the user response for correctness
    /// </summary>
    /// <param name="userInput"> The string the user inputted</param>
    /// <returns></returns>
    public int scoreResponse(string userInput)
    {
        return 1;
    }

    /// <summary>
    /// Mark this email as submitted
    /// </summary>
    public void setReplied()
    {
        this.replied = true;
    }
}
