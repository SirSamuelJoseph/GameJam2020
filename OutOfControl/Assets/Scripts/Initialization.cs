using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{

    private bool tutorialEmailsFinished;

    private int[] emailIndexes;
    private List<Email>[] emailMasterList;

    private List<Email> bartBurley;
    private List<Email> boss;
    private List<Email> roomie;

    private int activeContacts;

    public main main;

    public int numberOfEmailsSent = 0;

    // Start is called before the first frame update
    void Start()
    {
        tutorialEmailsFinished = false;
        this.emailIndexes = new int[] { 0, 0 };
        this.emailMasterList = new List<Email>[2];
        bartBurley = new List<Email>();

        this.emailMasterList[1] = bartBurley;
        activeContacts = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (bartBurley.Count == 0)
        {
            initializeBart();
        }

        if (!tutorialEmailsFinished)
        {
            Email t1;

            t1 = new Email("Roomie", "Welcome to the office! Here are some instructions.", "I'm <b><color=red>excited</color></b> to <b><color=red>start</color></b> learning and <b><color=red>working</color></b>!", "", new string[] { "excited", "start", "working" });

            //this.sendNextEmailToInbox(t1);

            Email t2;
        } else
        {
            if (numberOfEmailsSent == 2)
            {
                this.activeContacts += 1;
            }
            else if (numberOfEmailsSent == 5)
            {
                this.activeContacts += 1;
            }
            else if (numberOfEmailsSent == 9)
            {
                this.activeContacts += 1;
            }
            else if (numberOfEmailsSent > 9)
            {
                this.activeContacts = 6;
            }
        }
    }

    public void sendNextEmailInChain(int indexOfSender)
    {
        this.emailIndexes[indexOfSender]++;
        this.waitAndSend(2, emailMasterList[indexOfSender][this.emailIndexes[indexOfSender]]);
    }

    public void initializeBart()
    {

    }

    public void sendNextEmailToInbox(Email e)
    {
        main.addEmailToEmailClientInbox(e);
        this.numberOfEmailsSent++;
    }

    public void waitAndSend(float delay, Email e)
    {
        StartCoroutine(waitAndSendHelper(delay, e));
        this.numberOfEmailsSent++;
    }

    public IEnumerator waitAndSendHelper(float delay,Email e)
    {
        yield return new WaitForSeconds(delay);

        main.addEmailToEmailClientInbox(e);
    }


}
