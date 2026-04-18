using UnityEngine;

public class CollectibleGold : MonoBehaviour
{
    public int goldAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GoldManager>().AddGold(goldAmount);
            Destroy(gameObject);
        }
    }
}