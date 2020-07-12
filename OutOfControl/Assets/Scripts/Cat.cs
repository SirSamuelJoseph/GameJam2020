using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // The amount of time, in seconds, since the last time the cat interfered with stuff
    private float timeSinceLastCatIncident;
    // True if the cat is able to affect the game right now
    public bool catChaosModeActive;

    public main main;

    public NoiseManager sound;

    const int addCharacterChances = 50;
    const int changeEmailChances = 35;
    const int catNoiseNoAction = 10;
    const int emailSubmission = 5;

    private Vector2 catPosition;
    private Vector2 nextCatPosition;

    private GameObject catSprite;

    private string charleftbottom = "asdzxc";
    private string charleftcenter = "qweasd";
    private string charleftup = "1234qwe";
    private string charcenterbottom = "dfghcvbn";
    private string charcentercenter = "dfghjrvtbyn";
    private string charcenterup = "rtyu45678";
    private string charrightbottom = "bnm,jkl;";
    private string charrightcenter = "hjkl;nimo";
    private string charrighttop = "uiop[7890";

    private string[,] charsheet;
    private string[,] tagsheet;

    public GameObject[] catSprites;


    // Start is called before the first frame update
    void Start()
    {
        catChaosModeActive = false;
        string[] charSheetLeft = new string[] { charleftbottom, charleftcenter, charleftup };
        string[] charSheetCenter = new string[] { charcenterbottom, charcentercenter, charcenterup };
        string[] charSheetRight = new string[] { charrightbottom, charrightcenter, charrighttop };
        string[,] charsheet2 = {
            { charleftbottom , charleftcenter, charleftup },
            { charcenterbottom, charcentercenter, charcenterup },
            { charrightbottom, charrightcenter, charrighttop}
        };
        // No idea why I need to do it like this but apparently I do
        charsheet = charsheet2;
        
        catSprite = GameObject.FindGameObjectWithTag("catPosition");

        string[,] tagsheet = {
            { "leftBottom", "leftCenter", "leftTop" },
            { "centerBottom", "centerCenter", "centerTop" },
            { "rightBottom", "rightCenter", "rightTop" },
            { "Enter", "Arrows", "capsLock" }
        };

        this.tagsheet = tagsheet;

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCatIncident += Time.deltaTime;
        if (catChaosModeActive && timeSinceLastCatIncident > 5)
        {
            int sum = addCharacterChances + changeEmailChances + catNoiseNoAction + emailSubmission;
            int catAction = Random.Range(0, sum);

            // Plays a random cat noise
            sound.playCatNoise();

            //if (catAction < addCharacterChances)
            if (true)
            {
                StartCoroutine(MoveCat());

                string lettersToChoose = this.charsheet[(int)nextCatPosition.x, (int)nextCatPosition.y];
                char charToAdd = lettersToChoose[Random.Range(0, lettersToChoose.Length)];

                Debug.Log("X: " + nextCatPosition.x + " Y: " + nextCatPosition.y);
                //Debug.Log("Char " + charToAdd);
            }
            else if (catAction < addCharacterChances + changeEmailChances)
            {
                float upOrDown = Random.Range(0, 2);

                // The furthest right spot
                this.nextCatPosition.x = 5;
                this.nextCatPosition.y = 1;

                this.main.setNextEmailActive(upOrDown == 1);
                Debug.Log("Change email");
            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction)
            {
                Debug.Log("Noise");
            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction + emailSubmission)
            {
                Debug.Log("Submit");
                // The furthest right spot
                this.nextCatPosition.x = 5;
                this.nextCatPosition.y = 1;

                //this.client.submitEmail();
            }

            timeSinceLastCatIncident = 0;
        }
    }

    private void getCatReadyForJump()
    {

        if (this.catPosition.x > this.nextCatPosition.x)
        {
            Debug.Log("Left");
            foreach (GameObject g in this.catSprites)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }

            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (this.catPosition.x < this.nextCatPosition.x)
        {
            Debug.Log("right");

            foreach (GameObject g in this.catSprites)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }

            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public IEnumerator MoveCat()
    {

        // Random spots
        this.nextCatPosition.x = Random.Range(0, 3);
        this.nextCatPosition.y = Random.Range(0, 3);

        this.getCatReadyForJump();
        Debug.Log("switchPosifShould");
        yield return new WaitForSeconds(2f);
        Debug.Log("changePos");

        this.catPosition = new Vector2(this.nextCatPosition.x, this.nextCatPosition.y);

        string locationTag = tagsheet[(int)nextCatPosition.x, (int)nextCatPosition.y];
        Vector2 location = GameObject.FindGameObjectWithTag(locationTag).transform.position;
        this.catSprite.transform.position = location;
    }

}
