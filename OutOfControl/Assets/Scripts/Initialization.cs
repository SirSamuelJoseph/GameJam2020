using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{

    private int[] emailIndexes;
    private bool[] readyForNextEmail;
    private List<Email>[] emailMasterList;

    private List<Email> bartBurley;
    private List<Email> boss;
    private List<Email> roomie;
    private List<Email> jeffs;
    private List<Email> alex;
    private List<Email> jasmines;

    private int activeContacts;

    public main main;
    public Cat cat;

    public int numberOfEmailsSent = 0;

    public bool startEmailFlood = false;

    // Start is called before the first frame update
    void Start()
    {
        this.emailIndexes = new int[] { 0, 0, 0, 0, 0, 0 };
        this.readyForNextEmail = new bool[] { true, true, true, true, true, true };
        this.emailMasterList = new List<Email>[6];
        this.emailMasterList[0] = roomie;
        bartBurley = new List<Email>();
        roomie = new List<Email>();
        alex = new List<Email>();
        jeffs = new List<Email>();
        jasmines = new List<Email>();

        initializeBart();
        initializeRoomie();

        this.emailMasterList[0] = roomie;
        this.emailMasterList[1] = bartBurley;
        this.emailMasterList[2] = jasmines;
        this.emailMasterList[3] = jeffs;
        this.emailMasterList[4] = alex;
        activeContacts = 2;

    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfEmailsSent == 0)
        {
            sendNextEmailInChain(0, 0);
        }
        if (numberOfEmailsSent == 1)
        {
            sendNextEmailInChain(1, 0);
        }
        else if (numberOfEmailsSent > 1)
        {
            if (!startEmailFlood)
            {
                startEmailFlood = true;
                StartCoroutine(SendNextEmail());
                cat.catChaosModeActive = true;
            }

            if (numberOfEmailsSent == 3)
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

    public void sendNextEmailInChain(int indexOfSender, float delay)
    {
        this.waitAndSend(delay, emailMasterList[indexOfSender][this.emailIndexes[indexOfSender]]);
        this.readyForNextEmail[indexOfSender] = false;
        this.emailIndexes[indexOfSender]++;
        main.updateDisplay();
    }

    public void initializeBart()
    {
        string name = "Bart Burly";
        string badResponse = "Please reply with less typos and professionalism. My burritos shall not be underlooked!";
        Email b1 = new Email(name,
                            "I know you’re new here, and working from home, but don’t you dare come into the office and take my burritos out of the fridge. There mine! I love burritos! Promise you won’t take my burritos! Sincerely, Bart Burly",
                            "Bart, I solemnly <b><color=red>swear to not eat</color></b> your <b><color=red>burritos</color></b>! I’m excited to be on the time and look forward to working with you. Sincerely, Link",
                            badResponse,
                            new string[] { "swear", "to", "not", "eat", "burritos" });
        Email b2 = new Email(name,
                            "Hey, so I know you are work from home and all, but I just want you to know how much burritos mean to me. All I can think about is the sweet smell of peppers, the oozy cheese. I can’t focus on work now! You better not take my burritos!",
                            "Bart, I can assure you that as I work from home, I will <b><color=red>not come into</color></b> the <b><color=red>office</color></b> and take your burritos. I too partake in the occasional burrito at my own behest. Best, Link",
                            badResponse,
                            new string[] { "not", "come", "into", "office" });
        Email b3 = new Email(name,
                            "Well if you ever take a burrito out of the burrito fridge I demand you refill the burrito fridge, which is a fridge specifically for my burritos! It’s not the same as the break room fridge, it’s different!",
                            "As per my last email, I am work-from-home and will not take your burritos. I’m sorry that you are experiencing this stress. Warm regards, Link.",
                            badResponse,
                            new string[] { "last", "email", "will", "not", "take", "burritos", "sorry" });
        Email b4 = new Email(name,
                            "What kind of professionalism is this? That’s a poor response! To a topic so important as flour tortillas and sweet sweet salsa? You need to promise me you’re not going to take my burritos!",
                            " Bart, I can assure you that as I work from home, I will <b><color=red>not come into</color></b> the <b><color=red>office</color></b> and take your burritos. I too partake in the occasional burrito at my own behest. Best, Link.",
                            badResponse,
                            new string[] { "not", "come", "into", "office" });
        Email b5 = new Email(name,
                            "Hello Email Company. I am trying to get to the bottom of a vulgar and heinous crime. Someone has taken my burritos out of the fridge. Now I am saddened, hungry, and frankly a little scared. Please reply with any news about the burrito thief, and I promise not to be mad.",
                            "Bart, I did <b><color=red>not take</color></b> your burritos, and hope you can get to the <b><color=red>bottom</color></b> of this <b><color=red>soon</color></b>. With gratitude, Link",
                            badResponse,
                            new string[] { "not", "take", "burritos", "bottom", "soon" });
        Email b6 = new Email(name,
                            "This doesn’t seem heartfelt at all! Burritos are my only solace in a world so mundane as this. There was once a burrito, and now there is not!",
                            "My <b><color=red>heart</color></b> goes out to the <b><color=red>fate</color></b> of the <b><color=red>burrito</color></b>, but I can assure you that it was <b><color=red>not me</color></b>! I’m new, and don’t even know where the burrito fridge is. Even if I did, once again I state that I am <b><color=red>working from home</color></b>. Many thanks, Link",
                            badResponse,
                            new string[] { "heart", "fate", "burrito", "not", "me", "working", "from", "home" });
        Email b7 = new Email(name,
                            "Alright listen here you little shit, we here an Emails Incorporate take bride in our emails, and have passions of our own. I for one love foods that can be picked up with the ease of one or two hands. Do not patronize me with misspelled and half assed emails or I will report you to HR!",
                            "Bart, I am <b><color=red>sorry</color></b>. I <b><color=red>didn’t mean anything by it</color></b>. Hopefully you can see I am of <b><color=red>good</color></b> character. Respectfully, Link",
                            badResponse,
                            new string[] { "sorry", "didn't", "mean", "anything", "by", "it", "good", "character" });
        Email b8 = new Email(name,
                            "Someone tipped me off to the fact that you may or may not have a liking for burritos too! And listen I get it! There is so much variety, customization. My mother used to say “burritos and their fillings are a reflection of one’s soul.” Normally I would be ecstatic about having a new employee with shared interests, however, YOU STOLE MY BURRITO!!!",
                            "Bart, I’m <b><color=red>disheartened</color></b> to <b><color=red>hear</color></b> that you think I <b><color=red>wronged you</color></b>. I cannot repeat this enough, but I have <b><color=red>not been</color></b> in the <b><color=red>office physically</color></b> yet, and therefore <b><color=red>couldn’t</color></b> possibly have <b><color=red>stolen</color></b> from <b><color=red>you</color></b>. Yours truly, Link",
                            badResponse,
                            new string[] { "disheartened", "hear", "wronged", "you", "not", "been", "office", "physically", "couldn’t", "stolen", "you" });
        Email b9 = new Email(name,
                            "I like to think that everyone in our world is truthful, but I have had a difficult past with untrustworthy burrito connoisseurs that have wronged me and my family. I cannot let this go, and will not let this slide.",
                            "You should <b><color=red>not</color></b> let this <b><color=red>slide</color></b>! I want to <b><color=red>make sure</color></b> that <b><color=red>my food</color></b> is <b><color=red>safe</color></b> in the communal fridge as well, <b><color=red>whenever</color></b> I move to the <b><color=red>office</color></b>. Your friend, Link",
                            badResponse,
                            new string[] { "not", "slide", "make", "sure", "my", "food", "safe", "whenever", "office" });
        Email b10 = new Email(name,
                            "No one’s food will be safe with a burrito thief on the loose! You should know this best! I have half a mind to steal your lunch out of the fridge right now!",
                            "Bart, <b><color=red>once again</color></b>, I do <b><color=red>not</color></b> have <b><color=red>anything</color></b> in the <b><color=red>fridge</color></b> because I am working from home. I will do my best to <b><color=red>remotely get</color></b> to the <b><color=red>bottom</color></b> of <b><color=red>this</color></b>. Cheers, Link",
                            badResponse,
                            new string[] { "once", "again", "not", "anything", "fridge", "remotely", "get", "bottom", "this" });
        Email b11 = new Email(name,
                            "Your insincerity is like a ripped burrito, fillings spread cold and lonely through the wind. I will come to your house and fill your socks with pickled jalapenos for your transgression. Be warned!",
                            "<b><color=red>Please do not come to my house</color></b>! My <b><color=red>roommate</color></b> is very <b><color=red>shy</color></b> and we just got a <b><color=red>cat</color></b> that does <b><color=red>not</color></b> take <b><color=red>kindly</color></b> to <b><color=red>strangers</color></b>. Also, what? <b><color=red>Don’t</color></b> put <b><color=red>peppers</color></b> in my <b><color=red>socks</color></b>!",
                            badResponse,
                            new string[] { "Please", "do", "not", "come", "to", "my", "house", "roommate", "shy", "cat", "kindly", "strangers", "Don't", "peppers", "socks" });
        Email b12 = new Email(name,
                            "I will spare you this once. Be warned.",
                            "<b><color=red>Thank you</color></b>?",
                            badResponse,
                            new string[] { "Thank", "you" });

        bartBurley.Add(b1);
        bartBurley.Add(b2);
        bartBurley.Add(b3);
        bartBurley.Add(b4);
        bartBurley.Add(b5);
        bartBurley.Add(b6);
        bartBurley.Add(b7);
        bartBurley.Add(b8);
        bartBurley.Add(b9);
        bartBurley.Add(b10);
        bartBurley.Add(b11);
        bartBurley.Add(b12);
    }


    public void sendNextEmailToInbox(Email e)
    {
        main.addEmailToEmailClientInbox(e);
        this.numberOfEmailsSent++;
    }

    public void waitAndSend(float delay, Email e)
    {
        Debug.Log(e.getEmailBody());
        StartCoroutine(waitAndSendHelper(delay, e));
        this.numberOfEmailsSent++;
    }

    public void initializeRoomie()
    {
        string name = "Roomie";
        string badresonse = "I’m not really sure what you mean but I’ll take that as a yes unless you respond otherwise!";
        Email r1 = new Email(name,
        "Sup person I live with! I called your work to get your email, and surprisingly they just gave it to me! I know we live together, but I’m shy and wanted to know if I could get a cat. She’s really cute and basically just likes to cuddle. Low maintenance and will stay out of your hair. Let me know if that’s cool or not. - Roomie",
        "This <b><color=red>should</color></b> be <b><color=red>fine</color></b>, as long as the <b><color=red>cat doesn’t interfere</color></b> with my daily work!",
        badresonse,
        new string[] { "should", "fine", "cat", "doesn't", "interfere" });

        roomie.Add(r1);

    }


    public void initializeJeff()
    {
        string name = "Jefferey I. Tee";
        string badResponse = "This is an automated message. Mr. Jefferey I. Tee does not read emails with typos exceeding a certain undisclosed number. Please reply again.";

        Email j1 = new Email(name,
                            "Hello and welcome to the esteemed world of emails! My name is Jeff Tee, and I’m the world’s best IT debugger. Ain’t nobody better than me. I have eyes like a cat, and no bug can get through my defenses! But we are only as strong as our weakest link, so be vigilant!",
                            "<b><color=red>Thanks</color></b> so much Mr. Tee! I look forward to <b><color=red>emailing</color></b> and watching out for <b><color=red>bugs</color></b>. Sincerely, Link",
                            badResponse,
                            new string[] { "Thanks", "emailing", "bugs" });
        Email j2 = new Email(name,
                            "I can see you are having a successful string of emails! Well done! However, I, the greatest IT person to ever exist, needs to reset your password. Please remind me what your current password is so we can figure out next steps.",
                            "Jeff, are you sure it is <b><color=red>safe</color></b> to <b><color=red>type</color></b> my <b><color=red>password</color></b> through an <b><color=red>email</color></b>? I’m not familiar with our <b><color=red>security</color></b> being new and all, but wanted to double <b><color=red>check</color></b> before doing something wrong. Warm regards, Link",
                            badResponse,
                            new string[] { "safe", "type", "password", "email", "security", "check" });
        Email j3 = new Email(name,
                            "Link, what do I look like, the second best IT personale to ever grace this company? Of course not! I am the first! Send that password, it will be totally safe!",
                            "Here you go! My <b><color=red>password</color></b> is <b><color=red>password123</color></b>. Let me know if you need <b><color=red>anything</color></b> else! Sincerely, Link",
                            badResponse,
                            new string[] { "password", "password123", "anything" });
        Email j4 = new Email(name,
                            "Attention company, it appears there was a data breach. I don’t know how it happened, but I am the best IT personnel on this side of the Mississippi, and I will use my detective skills to converge on the source! Please respond with your employee name so that I can trace back the breach.",
                            "My <b><color=red>name</color></b> is <b><color=red>Link</color></b>. Hope you can find the <b><color=redd>source</color></b> of the <b><color=red>breach soon</color></b> and patch that up!",
                            badResponse,
                            new string[] { "name", "Link", "source", "breach", "soon" });
        Email j5 = new Email(name,
                            "Aha! I found the source! It was you. YOU YOU YOU. I’ve gone 13 years without a data breach, and then you come along and BOOM. Record over! I can’t believe this. What am I gonna tell my kids? They only want to be as great of an IT worker as I. I’m ruined.",
                            "Jeff, I’m <b><color=red>not sure</color></b> how I was responsible. Is it <b><color=red>possible</color></b> that the <b><color=red>security breach</color></b> came from me sending my <b><color=red>password</color></b> over email? I just want to be upfront so we can solve this <b><color=red>computer</color></b> issue. Best, Link.",
                            badResponse,
                            new string[] { "not", "sure", "possible", "security", "breach", "password", "computer" });
        Email j6 = new Email(name,
                            "Yes that must have been it! Good thinking.Since you were the one that led to the breach, I can do nothing besides blame this whole mess on you. I’m sorry, best of luck in the future.",
                            "Mr. I. Tee, I don’t mean to be <b><color=red>rude</color></b>, however you were the one that told me to <b><color=red>send</color></b> you the <b><color=red>password</color></b> over <b><color=red>email</color></b>. I even <b><color=red>checked</color></b> to make sure it was <b><color=red>secure</color></b> with you. Please respond asap. I have the <b><color=red>email saved</color></b>.",
                            badResponse,
                            new string[] { "rude", "send", "password", "email", "checked", "secure", "email", "saved" });
        Email j7 = new Email(name,
                            "No no no. Oh my goodness, you can’t do this to me! I’m sure you’re a hard worker but I cannot have this mess tainting my record or my marriage. What will my husband think if I go home and am not the greatest programmer and debugger? He’ll leave me for another programmer tomorrow! My life is ruined!",
                            "Jeff, don’t <b><color=red>worry</color></b> it’s <b><color=red>okay</color></b>, we’ll get to the <b><color=red>bottom</color></b> of this if we <b><color=red>work together</color></b>!",
                            badResponse,
                            new string[] { "worry", "okay", "bottom", "work", "together" });
        Email j8 = new Email(name,
                            "Link, I’m writing to you personally. This data breach has taken a toll on me. I no longer feel like the greatest IT man to ever pick up the old monitor and keyboard. What do I do? You’re the best email responder I’ve seen in my 46 years of emailing. Please respond I need you!",
                            "Hey keep your <b><color=red>head up</color></b>! Remember you are the best <b><color=red>programmer</color></b> out there, and your family is lucky to have you in their lives. Might I also <b><color=red>recommend</color></b> speaking with HR about this <b><color=red>issue</color></b>? Warmth and love, Link",
                            badResponse,
                            new string[] { "head", "up", "programmer", "recommend", "issue" });
        Email j9 = new Email(name,
                            "This is too big for HR! No one can know except you and me!",
                            "Then let's <b><color=red>tighten our security</color></b> and fix this <b><color=red>issue</color></b>! We can do it!",
                            badResponse,
                            new string[] { "tighten", "our", "security", "issue" });
        Email j10 = new Email(name,
                            " Link, you’re the best friend an IT man could ask for! Your words have inspired me to pursue a career in Cyber Security for the US Government. I will recommend you for my position, I know you’re new, but honestly all I do is respond to emails all day so the actual security shouldn’t be that hard. Good luck!",
                            "Wait, <b><color=red>don’t leave</color></b>! How do I <b><color=red>secure</color></b> the <b><color=red>servers</color></b>? When can I <b><color=red>reset</color></b> my <b><color=red>password</color></b>? How do I <b><color=red>fix bugs</color></b>? Hello?",
                            badResponse,
                            new string[] { "don't", "leave", "secure", "servers", "reset", "password", "fix", "bugs" });

        jeffs.Add(j1);
        jeffs.Add(j2);
        jeffs.Add(j3);
        jeffs.Add(j4);
        jeffs.Add(j5);
        jeffs.Add(j6);
        jeffs.Add(j7);
        jeffs.Add(j8);
        jeffs.Add(j9);
        jeffs.Add(j10);
    }


    public IEnumerator waitAndSendHelper(float delay,Email e)
    {
        yield return new WaitForSeconds(delay);

        main.addEmailToEmailClientInbox(e);
    }

    public void sendNextRandomEmail()
    {
        for(int i =0; i < this.activeContacts; i++)
        {
            if (this.readyForNextEmail[i])
            {
                Debug.Log("NEXT INDEX SENDER:" + i);
                this.sendNextEmailInChain(i, Random.Range(0, 4));
                this.emailIndexes[i]++;
            }
        }
    }

    public IEnumerator SendNextEmail()
    {

        while (true)
        {
            Debug.Log("shouldbe sending");
            this.sendNextRandomEmail();
            yield return new WaitForSeconds(Random.Range(0, 5) + 1);
        }


    }

    public void initializeAlexandra()
    {
        string name = "Alexandra Ginsburg";
        string badResponse = "Your performance review is coming up. Please respond again with less typos.";

        Email a1 = new Email(name,
                            "Link, I’m the boss of The Email Company. I hope you have a smooth first day. Don’t be afraid to reach out to me. We are all happy to have you on board!",
                            "<b><color=red>Thank you for the warm welcome. I’m happy</color></b> to be <b><color>here</color></b>! Cheers, Link",
                            badResponse,
                            new string[] { "Thank", "you", "for", "the", "warm", "welcome", "I'm", "happy", "here" });
        Email a2 = new Email(name,
                            "Link, I’ve been hearing a lot of buzz around the office about your work. Remember, you are always being reviewed for your efforts. And please, call me Alexandra.",
                            "I <b><color=red>understand, thank you for the encouragement</color></b> and <b><color=red>reaching out</color></b>. Warmly, Link",
                            badResponse,
                            new string[] { "understand", "thank", "you", "for", "the", "encouragement", "reaching", "out" });
        Email a3 = new Email(name,
                            "Link, Bart is very upset. Did you really take his burrito out of the burrito fridge? We have a rule here!",
                            "<b><color=red>No, I did not take his burrito. I</color></b> am working from home right now, and <b><color=red>have not been in the office</color></b>. Sincerely, Link",
                            badResponse,
                            new string[] { "No", "I", "did", "not", "take", "his", "burrito", "I", "have", "not", "been", "in", "the", "office" });
        Email a4 = new Email(name,
                            "John I. Tee just submitted his resignation letter and appointed you the head of IT. Do you know anything about this?",
                            "<b><color=red>He was having difficulties</color></b> with a <b><color=red>security breach</color></b> and was <b><color=red>blaming me for it</color></b>. I tried to <b><color=red>console</color></b> him <b><color=red>and</color></b> he <b><color=red>left</color></b>. Best, Link",
                            badResponse,
                            new string[] { "He", "was", "having", "difficulties", "security", "breach", "blaming", "me", "for", "it", "console", "and", "left" });
        Email a5 = new Email(name,
                            "And Jasmine tells me you aren’t pulling your wait on the team. This will not look good for your performance review.",
                            "Alexandra, <b><color=red>Jasmine was giving me her work to do rather than collaborating</color></b>. And even so, <b><color=red>I was responding to her emails</color></b>. Truly, Link",
                            badResponse,
                            new string[] { "Jasmine", "was", "giving", "me", "her", "work", "to", "do", "rather", "than", "collaborating", "I", "was", "responding", "to", "her", "emails" });
        Email a6 = new Email(name,
                            "Please, call me Ms. Ginsburg. Between the burritos, the security breach, and poor teamwork, I’m seriously considering letting you go. How do you plea?",
                            "<b><color=red>Ms. Ginsburg, I must defend myself. Almost everyone has been accusing me of falsehoods all day! All I’ve been doing is answering emails, and I’m not even sure what this company does. But I also need this job, and am open to critiques and improvements</color></b>9. Sincerely, Link",
                            badResponse,
                            new string[] { "Ms.", "Ginsburg", "I", "must", "defend", "myself", "Almost", "everyone", "has", "been", "accusing", "me", "of", "falsehoods", "all", "day", "All", "I've", "been", "doing", "is", "answering", "emails", "and", "I'm", "not", "even", "sure", "what", "this", "company", "does", "But", "I", "also", "need", "this", "job", "and", "am", "open", "to", "critiques", "and", "improvements" });

        alex.Add(a1);
        alex.Add(a2);
        alex.Add(a3);
        alex.Add(a4);
        alex.Add(a5);
        alex.Add(a6);

    }

    public void intitializeJasmine()
    {
        string name = "Jasmine Shuratea";
        string badresponse = "As the winner of the SEMJWHSPC Spelling Bee, I request you retype your response with less typos before we engage in jolly-cooperation!";

        Email j1 = new Email(name,
        "Welcome aboard Link! My name is Jasmine and I will be working with you alongside you. I’m really passionate about teamwork, music, and spelling! I was actually the Regional Champion of the Sub Eastern Minor Junior Western High School Pre College Spelling Bee! It’s a title I hold close to my heart. Anyway, happy first day!",
        "<b><color=red>Jasmine</color></b>, thank you for making your <b><color=red>welcome</color></b> so warm! I am an <b><color=red>astute</color></b> typer, and love to <b><color=red>collaborate</color></b> as a <b><color=red>team</color></b> at <b><color=red>work</color></b>. Looking forward to this experience. Warmly, Link. Link",
        badresponse,
        new string[] { "jasmine", "welcome", "astute", "collaborate", "team", "work" });

        Email j2 = new Email(name,
        "Hey there teammate! Can you send me the formula for a straight line? I know someone with your experience probably has it written down somewhere on your computer. Thanks! Also, what’s your favorite musician right now?",
        "Sure, the <b><color=red>formula</color></b> is y <b><color=red>equals</color></b> m x <b><color=red>plus</color></b> b. Happy to <b><color=red>collaborate</color></b> at any time! And I’m listening to a lot of Flap Jack Jackson.",
        badresponse,
        new string[] { "formula", "equals", "plus", "collaborate" });

        Email j3 = new Email(name,
        "Thanks for the formula! Do you mind also doing this whole regression analysis? I need it in the next 30 minutes, thanks! Yayy happy cooperation!",
        "Um, I'm not exactly sure what you mean. I'm <b><color=red>happy</color></b> to <b><color=red>work together</color></b> as a <b><color=red>team</color></b>, but this hardly seems like <b><color=red>collaboration</color></b>.",
        badresponse,
        new string[] { "happy", "work", "together", "team", "collaboration" });

        Email j4 = new Email(name,
        "This is collaboration! I have so many emails to reply to and send, and so much new music to listen to! Anyway thanks for understanding! Please get that report to me in 30 minutes. You the best!",
        "I'm <b><color=red>not sure</color></b> what I'm <b><color=red>supposed</color></b> to <b><color=red>do</color></b>! Can you help me <b><color=red>collaborate</color></b> with me?",
        badresponse,
        new string[] { "not", "sure", "supposed", "do", "collaborate" });


       Email j5 = new Email(name,
       "Grrr you really let me down! I was supposed to have this analysis done for my meeting with the boss lady! Now she’s super pissed that someone didn’t hold up their end of the teamwork. Collaboration is a two way street!",
       "<b><color=red>Collaboration</color></b> is a two way <b><color=red>street</color></b>, but I wasn’t really sure what I was <b><color=red>supposed</color></b> to <b><color=red>do</color></b>!",
       badresponse,
       new string[] { "collaboration", "street", "supposed", "do" });

        Email j6 = new Email(name,
        "Lets not hark on the past, as a team we should want to move forward! Why don’t you help me out by responding to some more email? I’ll forward them to you! This will be good and redeeming! Isn’t collaboration great?",
        "Jasmine, I would prefer <b><color=red>not responding</color></b> for you, and as a new <b><color=red>work</color></b> from <b><color=red>home</color></b> employee I already have a ton of emails myself.",
        badresponse,
        new string[] { "not", "responding", "work", "home" });

        Email j7 = new Email(name,
        "FW: Jasmine, are you okay? I haven’t heard from you in a while. Please respond with an update, we have to respond to clients before this weekend!",
        "This is Link, <b><color=red>Jasmine</color></b> appears to be <b><color=red>busy</color></b> and so I’m responding on her behalf. She <b><color=red>forwarded</color></b> this <b><color=red>email</color></b> to me. Let me know if I can be of <b><color=red>assistance</color></b>. Sincerely, Link",
        badresponse,
        new string[] { "Jasmine", "busy", "forwarded", "email", "assistance" });

        Email j8 = new Email(name,
        "FW:FW: Jasmine you can’t keep doing this to the new employees! Collaboration is assisting other people, not passing off your workload. And now you’re just forwarding this new employee your emails? Please respond.",
        "To <b><color=red>whom</color></b> it <b><color=red>may concern</color></b>, This is Link again. Let me know if I can be of any <b><color=red>help</color></b>. It <b><color=red>appears</color></b> Jasmine must be really <b><color=red>busy</color></b>. Best, Link",
        badresponse,
        new string[] { "whom", "may", "concern", "help", "appears", "busy" });

        Email j9 = new Email(name,
        "Link, stop responding as if it was you! If I forward you an email, respond as if it’s coming from me!!! That’s the true spirit of teamwork! We need to work together on this!",
        "<b><color=red>Jasmine, I hardly see this as beneficial for either of us. I don’t know <b><color=red>how to <b><color=red>respond</color></b> to the <b><color=red>forwarded emails meant</color></b> for <b><color=red>you</color></b>. Please let me know your <b><color=red>thoughts</color></b>. Warmly, Link",
        badresponse,
        new string[] { "Jasmine", "how", "respond", "forwarded", "emails", "meant", "you", "thoughts" });

        Email j10 = new Email(name,
        "Ugh you’re such a meany! I’m gonna have a few words with the boss lady. And I already had so much else to do today!",
        "Jasmine, I’m sorry if I upset you. I was just <b><color=red>hoping for a <b><color=red>little more help or <b><color=red>collaboration</color></b> on <b><color=red>projects</color></b>. Please don’t file a complaint, I’m <b><color=red>ready</color></b> to <b><color=red>help</color></b> with more <b><color=red>emails</color></b>. Sincerely, Link.",
        badresponse,
        new string[] { "hoping", "little", "more", "help", "collaboration", "projects", "ready", "help", "emails" });

        jasmines.Add(j1);
        jasmines.Add(j2);
        jasmines.Add(j3);
        jasmines.Add(j4);
        jasmines.Add(j5);
        jasmines.Add(j6);
        jasmines.Add(j7);
        jasmines.Add(j8);
        jasmines.Add(j9);
        jasmines.Add(j10);
    }




    public void setSenderReadyForNext(int senderIndex)
    {
        this.readyForNextEmail[senderIndex] = true;
    }
}
