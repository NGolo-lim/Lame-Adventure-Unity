using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public TextMeshProUGUI statusText;      // Для сообщений типа "Победа"
    public TextMeshProUGUI goldCounterText; // Для счетчика 0/5

    private int _totalGold;
    private int _collectedGold;

    void Start()
    {
        // Считаем, сколько золота на уровне в самом начале
        _totalGold = GameObject.FindGameObjectsWithTag("Gold").Length;
        UpdateGoldUI();
    }

    // Этот метод вызывает каждая монетка при подборе
    public void CollectGold()
    {
        _collectedGold++;
        UpdateGoldUI();
    }

    void UpdateGoldUI()
    {
        if (goldCounterText != null)
        {
            goldCounterText.text = $"Золото: {_collectedGold} / {_totalGold}";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (_collectedGold >= _totalGold)
        {
            other.GetComponent<Collider2D>().enabled = false;

            var movement = other.GetComponent<PlayerMovement>();
            if (movement != null) movement.enabled = false;

            Debug.Log("Победа! Ты в безопасности.");
            if (_collectedGold >= _totalGold)
            {
                NextLevel(); 
            }
        }
    }
}

    void NextLevel()
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

  
    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    else
    {
        SceneManager.LoadScene(0); 
    }
}
}