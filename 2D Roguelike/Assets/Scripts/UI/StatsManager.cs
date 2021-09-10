using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    // Variables
    public GameObject Player;
    private float playersDamageNumber;
    private float playersMovespeedNumber;
    private float playersFireRateNumber;
    public Text damageText;
    public Text movespeedText;
    public Text fireRateText;


    private void Update()
    {
        playersDamageNumber = Player.GetComponent<Player>().playerDamage;
        playersMovespeedNumber = Player.GetComponent<Player>().moveSpeed;
        playersFireRateNumber = Player.GetComponent<Player>().playerFireRate;
        damageText.text = "Damage: " + playersDamageNumber.ToString();
        movespeedText.text = "Movespeed: " + playersMovespeedNumber.ToString();
        fireRateText.text = "Firerate: " + playersFireRateNumber.ToString();
    }
}
