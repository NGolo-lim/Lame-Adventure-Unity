using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Слово public перед void — САМОЕ ВАЖНОЕ. Без него Unity не найдет метод.
    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu"); // Проверь, что имя сцены совпадает с твоим
    }
}