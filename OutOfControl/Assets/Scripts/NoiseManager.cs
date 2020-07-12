using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{

    public AudioSource[] catNoises;
    public AudioSource newEmailNoise;


    /// <summary>
    /// Play a random noise from the given list of noises
    /// </summary>
    /// <param name="noises">The list of noises to choose from</param>
    private void playNoise(AudioSource[] noises)
    {
        int index = Random.Range(0, catNoises.Length);
        AudioSource chosenNoise = noises[index];
        chosenNoise.Play();
    }

    /// <summary>
    /// Play a randomly chosen cat noise
    /// </summary>
    public void playCatNoise()
    {
        this.playNoise(catNoises);
    }

    public void playNewEmailNoise()
    {
        this.newEmailNoise.Play();
        
    }


}
