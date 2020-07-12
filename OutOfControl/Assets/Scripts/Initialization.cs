using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{

    private bool tutorialEmailsFinished;

    private int[] emailIndexes;
    private List<Email>[] emailMasterList;

    private List<Email> bartBurley;

    public main main;

    private int numberOfEmailsSent = 0;

    // Start is called before the first frame update
    void Start()
    {
        tutorialEmailsFinished = false;
        this.emailIndexes = new int[] { 0, 0 };
        this.emailMasterList = new List<Email>[2];
        bartBurley = new List<Email>();

        this.emailMasterList[1] = bartBurley;

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

            t1 = new Email("Roomie", "Welcome!", "Welcome to the office! Here are some instructions.", "I'm <b><color=red>excited</color></b> to <b><color=red>start</color></b> learning and <b><color=red>working</color></b>!", "", "", new string[] { "excited", "start", "working" });

            this.sendNextEmailToInbox(t1);

            Email t2;
        }
    }

    public void sendNextEmailInChain(int indexOfSender)
    {
        this.emailIndexes[indexOfSender]++;
        this.waitAndSend(2, emailMasterList[indexOfSender][this.emailIndexes[indexOfSender]]);
    }

    public void initializeBart()
    {

        Email b1 = new Email("Bart Burly", "", "I know you’re new here, and working from home, but don’t you dare come into the office and take my burritos out of the fridge. They're mine! I love burritos! Promise you won’t take my burritos! Sincerely, Bart Burly", "Bart, I solemnly swear to not eat your burritos! I’m excited to be on the time and look forward to working with you. Sincerely, Link", "My Burritos", "", new string[] { "swear", "eat", "burritos", "not" });
        Email b2 = new Email("Bart Burly", "", "Hey, so I know you are work from home and all, but I just want you to know how much burritos mean to me. All I can think about is the sweet smell of peppers, the oozy cheese. I can’t focus on work now! You better not take my burritos!", "Bart, I can assure you that as I work from home, I will not come into the office and take your burritos. I too partake in the occasional burrito at my own behest. Best, Link.", "My Burritos", "What kind of professionalism is this? You think it reasonable to respond with typos?!? To a topic so important as flour tortillas and sweet sweet salsa? You need to promise me you’re not going to take my burritos!", new string[] {"not", "office", "eat", "your", "burrito" });


        bartBurley.Add(b1);
        bartBurley.Add(b2);

        sendNextEmailToInbox(b1);
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

        Debug.Log("Waited for it");
        Debug.Log(e.getEmailBody());
        main.addEmailToEmailClientInbox(e);
    }


}
