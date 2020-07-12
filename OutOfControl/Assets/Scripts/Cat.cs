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

    const int addCharacterChances = 10;
    const int changeEmailChances = 15;
    const int catNoiseNoAction = 10;
    const int emailSubmission = 15;

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
    public float catDelay;


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
        this.catDelay = 5;

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCatIncident += Time.deltaTime;
        if (catChaosModeActive && timeSinceLastCatIncident > this.catDelay)
        {
            int sum = addCharacterChances + changeEmailChances + catNoiseNoAction + emailSubmission;
            int catAction = Random.Range(0, sum);

            // Plays a random cat noise
            sound.playCatNoise();

            if (catAction < addCharacterChances)
            {
                StartCoroutine(MoveCat());

                string lettersToChoose = this.charsheet[(int)nextCatPosition.x, (int)nextCatPosition.y];
                char charToAdd = lettersToChoose[Random.Range(0, lettersToChoose.Length)];
                main.addCharToClient(charToAdd);

            }
            else if (catAction < addCharacterChances + changeEmailChances)
            {
                float upOrDown = Random.Range(0, 2);

                Vector2 arrowPos = GameObject.FindGameObjectWithTag(this.tagsheet[3, 1]).transform.position;

                StartCoroutine(MoveCat((int)arrowPos.x, (int)arrowPos.y));

            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction)
            {
                StartCoroutine(CatsMeow());
            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction + emailSubmission)
            {
                Vector2 enterPos = GameObject.FindGameObjectWithTag(this.tagsheet[3, 0]).transform.position;
                StartCoroutine(MoveCat((int)enterPos.x, (int)enterPos.y));

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

    public IEnumerator CatsMeow()
    {
        if (this.catSprites[0].GetComponent<SpriteRenderer>().enabled)
        {
            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[4].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[5].GetComponent<SpriteRenderer>().enabled = true;
        }

        yield return new WaitForSeconds(1f);

        if (this.catSprites[4].GetComponent<SpriteRenderer>().enabled)
        {
            this.catSprites[4].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            this.catSprites[5].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public IEnumerator MoveCat(int x = -1, int y = -1)
    {
        Vector2 newLocation;
        // If no values supplied, find a new spot
        if (x == -1)
        {
            // Random spots
            this.nextCatPosition.x = Random.Range(0, 3);
            this.nextCatPosition.y = Random.Range(0, 3);


            while(this.nextCatPosition.x == this.catSprite.transform.position.x)
            {
                this.nextCatPosition.x = (this.nextCatPosition.x + 1) % 3;
            }

            string locationTag = tagsheet[(int)nextCatPosition.x, (int)nextCatPosition.y];
            newLocation = GameObject.FindGameObjectWithTag(locationTag).transform.position;
        }
        else
        {
            this.nextCatPosition.x = x;
            this.nextCatPosition.y = y;
            newLocation = new Vector2(x, y);
        }


        if (this.nextCatPosition.x == this.catSprite.transform.position.x && this.nextCatPosition.y == this.catSprite.transform.position.y)
        {
            yield break;
        }

        this.getCatReadyForJump();
        Debug.Log("switchPosifShould");
        yield return new WaitForSeconds(this.catDelay / 5f);
        Debug.Log("changePos");
        Debug.Log("Coords: " + this.nextCatPosition.x + " " + this.nextCatPosition.y);

        this.catPosition = new Vector2(this.nextCatPosition.x, this.nextCatPosition.y);

        Vector2 oldPosition = this.catSprite.transform.position;

        if (this.catSprites[0].GetComponent<SpriteRenderer>().enabled)
        {
            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[2].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[3].GetComponent<SpriteRenderer>().enabled = true;
        }


        for(float f = 0; f < 1; f+= .05f)
        {
            Vector2 halfway = Vector2.Lerp(oldPosition, newLocation, f);
            this.catSprite.transform.position = halfway;
            yield return new WaitForSeconds(this.catDelay / 40f);
        }


        this.catSprite.transform.position = newLocation;
        if (this.catSprites[2].GetComponent<SpriteRenderer>().enabled)
        {
            this.catSprites[2].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            this.catSprites[3].GetComponent<SpriteRenderer>().enabled = false;
            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void speedUpCat()
    {
        this.catDelay -= .25f;
    }

}
