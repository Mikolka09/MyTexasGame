using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoved : MonoBehaviour
{
    [SerializeField] private float speed; //скорость перемещения
    [SerializeField] private float range; //диапазон перемещения
    private Vector2 startPoint;
    private int direction = 1; //напрвление движения
    public int Direction
    {
        get { return direction; }
    }

    void Start()
    {
        startPoint = transform.position; //получаем начальную позицию пилы

    }


    void Update()
    {
        //проверка, если пила дошла до конца диапазона, то меняем ее направление
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

    //Метод отрисовки пустого куба диапазона движения пилы
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(range * 2, 0.3f, 0));
    }

}
