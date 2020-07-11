using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // The amount of time, in seconds, since the last time the cat interfered with stuff
    private float timeSinceLastCatIncident;
    // True if the cat is able to affect the game right now
    public bool catChaosModeActive;
    // The email client the cat is futzing around with
    public EmailClient client;

    public NoiseManager sound;

    const int addCharacterChances = 50;
    const int changeEmailChances = 35;
    const int catNoiseNoAction = 10;
    const int emailSubmission = 5;


    // Start is called before the first frame update
    void Start()
    {
        catChaosModeActive = false;
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

            if (catAction < addCharacterChances)
            {
                Debug.Log("Char");
            }
            else if (catAction < addCharacterChances + changeEmailChances)
            {
                float upOrDown = Random.Range(0, 2);
                this.client.setNextEmailActive(upOrDown == 1);
                Debug.Log("Change email");
            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction)
            {
                Debug.Log("Noise");
            }
            else if (catAction < addCharacterChances + changeEmailChances + catNoiseNoAction + emailSubmission)
            {
                Debug.Log("Submit");
                //this.client.submitEmail();
            }

            timeSinceLastCatIncident = 0;
        }
    }
}
