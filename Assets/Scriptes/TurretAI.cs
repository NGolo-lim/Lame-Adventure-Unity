using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public GameObject bulletPrefab;  // Сюда перетащим префаб снаряда
    public Transform shootPoint;     // Точка, откуда вылетает пуля
    public float fireRate = 2f;      // Раз в сколько секунд стрелять
    public float range = 10f;        // Дистанция видимости

    private Transform _player;
    private float _nextFireTime;

    void Start()
    {
        // Ищем игрока по тегу
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) _player = playerObj.transform;
    }

    void Update()
    {
        if (_player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= range)
        {
            // Поворот в сторону игрока
            Vector2 direction = _player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Стрельба по таймеру
            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
    }
}