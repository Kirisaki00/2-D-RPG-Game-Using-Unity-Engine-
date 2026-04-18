using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;

    private bool isPlayerNearby = false;
    private bool isOpened = false;

    void Update()
    {
        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.F))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpened = true;
        animator.SetTrigger("Open");

        FindObjectOfType<GoldManager>().AddGold(100);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = false;
    }
}