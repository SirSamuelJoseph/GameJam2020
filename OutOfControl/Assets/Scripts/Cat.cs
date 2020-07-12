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

                // Random spots
                this.nextCatPosition.x = Random.Range(0, 3);
                this.nextCatPosition.y = Random.Range(0, 3);

                string lettersToChoose = this.charsheet[(int)nextCatPosition.x, (int)nextCatPosition.y];
                char charToAdd = lettersToChoose[Random.Range(0, lettersToChoose.Length)];

                Debug.Log("X: " + nextCatPosition.x + " Y: " + nextCatPosition.y);
                Debug.Log("Char " + charToAdd);
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
            this.getCatReadyForJump();
        }
    }

    private void getCatReadyForJump()
    {
        if (this.catPosition.x < this.nextCatPosition.x)
        {
            // Show right facing cat
        }
        else if (this.catPosition.x > this.nextCatPosition.x)
        {
            // show left facing cat
        }
    }

}
