using UnityEngine;

public class GoldItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Находим выход и говорим ему, что монетка собрана
            ExitDoor exit = Object.FindFirstObjectByType<ExitDoor>();
            if (exit != null)
            {
                exit.CollectGold();
            }

            Destroy(gameObject);
        }
    }
}