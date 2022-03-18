using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    //public GameObject scoreText;
    private int theScore;
    public Text playerScoreText;
    public AudioSource collectSound;

    public void OnTriggerEnter2D(Collider2D Collectables)
    {
        if (Collectables.tag == "collectable")
        {
            collectSound.Play();
            theScore += 25;
            Destroy(Collectables.gameObject);
            playerScoreText.text = "Score: " + theScore;
        }
    }

    public void reset()
    {
     
            //theScore += 25;
            playerScoreText.text = "Score: " + 0;
    }



}
