using UnityEngine;
using UnityEngine.UI;


public class CoinManager : MonoBehaviour
{
    public GameObject Player;
    private int playersCoinCount;
    public Text coinText;


    private void Update()
    {
        playersCoinCount = Player.GetComponent<Player>().playerCoins;
        coinText.text = "Coins: " + playersCoinCount.ToString();
    }


}
