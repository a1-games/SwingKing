using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPos;

    [SerializeField] private Transform point_1;
    [SerializeField] private Transform point_2;
    public float platformSpeed = 1.6f;
    [SerializeField] private float minimumDistanceBeforeTurnaround = 0.02f;

    public void Start()
    {
        transform.position = point_1.position;
        targetPos = point_2.position;
    }

    void LateUpdate()
    {
        transform.position += (targetPos - transform.position).normalized * Time.deltaTime * platformSpeed;

        if (Vector3.Distance(transform.position, targetPos) < minimumDistanceBeforeTurnaround)
        {
            ChangeTargetPos();
        }
    }

    public void ChangeTargetPos()
    {
        if (Vector3.Distance(transform.position, point_1.position) < Vector3.Distance(transform.position, point_2.position))
        {
            targetPos = point_2.position;
        }
        else if (Vector3.Distance(transform.position, point_1.position) > Vector3.Distance(transform.position, point_2.position))
        {
            targetPos = point_1.position;
        }
    }

}
