using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoved : MonoBehaviour
{
    [SerializeField] private float speed; //�������� �����������
    [SerializeField] private float range; //�������� �����������
    private Vector2 startPoint;
    private int direction = 1; //���������� ��������
    public int Direction
    {
        get { return direction; }
    }

    void Start()
    {
        startPoint = transform.position; //�������� ��������� ������� ����

    }


    void Update()
    {
        //��������, ���� ���� ����� �� ����� ���������, �� ������ �� �����������
        if (transform.position.x - startPoint.x > range && direction > 0)
        {
            direction *= -1;
        }
        else if (startPoint.x - transform.position.x > range && direction < 0)
        {
            direction *= -1;
        }
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
    }

    //����� ��������� ������� ���� ��������� �������� ����
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(range * 2, 0.3f, 0));
    }

}
