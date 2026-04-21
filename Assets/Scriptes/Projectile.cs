using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float speed = 7f;
    public float lifetime = 5f; // Чтобы пули не летели вечно и не нагружали ПК

    void Start()
    {
        // Удалить пулю через lifetime секунд
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Летим вперед (в ту сторону, куда смотрит пуля)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        // Пуля исчезает при столкновении со стеной (но не с самой пушкой)
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}