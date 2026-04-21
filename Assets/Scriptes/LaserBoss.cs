using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBoss : MonoBehaviour
{
    public Transform laserPoint;
    public LineRenderer lineRenderer;
    public float rotationSpeed = 2f;
    public float laserDuration = 1f; // Сколько длится сам выстрел
    public float chargeTime = 2f;    // Сколько времени он наводится

    private Transform _player;
    private float _timer;
    private bool _isFiring;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;
    }

    void Update()
    {
        if (_player == null) return;

        if (!_isFiring)
        {
            // 1. Поворот за игроком
            Vector2 direction = _player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 2. Рисуем тонкий "прицельный" луч
            DrawLaser(0.05f);

            // Таймер до выстрела
            _timer += Time.deltaTime;
            if (_timer >= chargeTime) StartFiring();
        }
        else
        {
            // 3. Состояние выстрела
            DrawLaser(0.4f); // Толстый луч
            CheckPlayerHit();

            _timer -= Time.deltaTime;
            if (_timer <= 0) StopFiring();
        }
    }

    void DrawLaser(float width)
{
    lineRenderer.startWidth = width;
    lineRenderer.endWidth = width;
    lineRenderer.SetPosition(0, laserPoint.position);
    
    // Увеличиваем визуальную длину до 500
    Vector3 direction = laserPoint.rotation * Vector3.right;
    lineRenderer.SetPosition(1, laserPoint.position + direction * 500f);
}

    void StartFiring()
    {
        _isFiring = true;
        _timer = laserDuration;
        lineRenderer.startColor = Color.white; // Вспышка перед выстрелом
    }

    void StopFiring()
    {
        _isFiring = false;
        _timer = 0;
        lineRenderer.startColor = Color.red;
    }

    void CheckPlayerHit()
{
    // Увеличиваем физическую длину луча до 500
    Vector2 direction = laserPoint.rotation * Vector2.right;
    RaycastHit2D hit = Physics2D.Raycast(laserPoint.position, direction, 500f);
    
    if (hit.collider != null && hit.collider.CompareTag("Player"))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
}