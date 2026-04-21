using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;
    private Transform pointA; 
    private Transform pointB;
    private Vector3 target;

    void Start()
    {
        // Враг сам ищет объекты с именами PointA и PointB среди своих "соседей"
        pointA = transform.parent.Find("PointA");
        pointB = transform.parent.Find("PointB");

        if (pointA != null && pointB != null)
            target = pointB.position;
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointB.position) ? pointA.position : pointB.position;
        }
    }
}