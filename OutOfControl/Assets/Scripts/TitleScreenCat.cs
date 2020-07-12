using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TitleScreenCat : MonoBehaviour
{
    public GameObject[] catSprites;

    private void getCatReadyForJump()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (this.transform.position.x > mousePosition.x)
        {
            foreach (GameObject g in this.catSprites)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }

            this.catSprites[0].GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (this.transform.position.x < mousePosition.x)
        {

            foreach (GameObject g in this.catSprites)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }

            this.catSprites[1].GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    public IEnumerator MoveCat()
    {

        while (true)
        {
            Vector2 startPosition = this.transform.position;
            Vector2 newLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.getCatReadyForJump();

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


            for (float f = 0; f < 1; f += .05f)
            {
                Vector2 halfway = Vector2.Lerp(startPosition, newLocation, f);
                this.transform.position = halfway;
                yield return new WaitForSeconds(.005f);
            }


            this.transform.position = newLocation;
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

            yield return new WaitForSeconds(.25f);
            this.getCatReadyForJump();
            yield return new WaitForSeconds(.75f);
        }
    }

    public void enableCat()
    {

        this.catSprites[1].GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(MoveCat());
    }

    public void disableCat()
    {
        StopAllCoroutines();
        foreach (GameObject g in this.catSprites)
        {
            g.GetComponent<SpriteRenderer>().enabled = false;
        }
        this.transform.position = new Vector2(-6, -3.5f);

    }

        
}
