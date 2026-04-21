using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для смены сцен

public class MainMenuLogic : MonoBehaviour
{
    public void StartGame()
    {
        // Загружаем сцену под индексом 1 (твой первый уровень)
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // Закрыть игру (работает только в собранной .exe версии)
        Debug.Log("Выход из игры...");
        Application.Quit();
    }
}