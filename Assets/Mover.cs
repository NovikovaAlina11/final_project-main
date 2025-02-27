using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.0f; // �������� ��������
    public float returnDelay = 2.0f; // �������� ����� ���������
    private Vector3 initialPosition; // ��������� �������
    private Vector3 targetPosition; // �������� �������
    private bool isMoving = false;

    void Start()
    {
        // ��������� ��������� �������
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
                Invoke("ReturnToInitialPosition", returnDelay); // �������� ������� ����� ��������
            }
        }
    }

    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    void ReturnToInitialPosition()
    {
        MoveTo(initialPosition); // ������������ �� ��������� �������
    }
}
