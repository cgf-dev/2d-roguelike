using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public GameObject Player;
    private int playersHealthCount;
    public Text healthText;


    private void Update()
    {
        playersHealthCount = Player.GetComponent<Player>().playerHealth;
        if (playersHealthCount <= 0)
            playersHealthCount = 0;
        healthText.text = "Health: " + playersHealthCount.ToString();
    }
}
