using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int targetHealth;

    /// <summary>
    /// Makes the target take a certain amount of damage
    /// </summary>
    /// <param name="damage"> int, The target takes this amaount of damage</param>
    

    public void TakeDamage(int damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0)
        {
            PlayerDead();
            gameObject.GetComponent<PlayerMovement>().ResetToStartingPostion();
            targetHealth = 2;
        }
    }

    /// <summary>
    /// The target is destroyed and the score is increased
    /// </summary>
    void PlayerDead()
    {
        if(gameObject.name == "Player 1")
        {
            gameObject.GetComponent<PlayerMovement>().ResetToStartingPostion();
            gameObject.GetComponent<Scoring>().reset();
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
