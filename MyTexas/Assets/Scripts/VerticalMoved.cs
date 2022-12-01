using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//Класс для перемещения пилы вверх и вних в определенном диапазоне
public class VerticalMoved : MonoBehaviour
{
    
    [SerializeField] private float speed; //скорость перемещения
    [SerializeField] private float range; //диапазон перемещения
    private Vector2 startPoint;
    private int direction = 1; //напрвление движения

    void Start()
    {
        startPoint = transform.position; //получаем начальную позицию пилы

    }

   
    void Update()
    {
        //проверка, если пила дошла до конца диапазона, то меняем ее направление
        if (transform.position.y - startPoint.y > range && direction > 0)
        {
            direction *= -1;
        }
        else if (startPoint.y - transform.position.y > range && direction < 0)
        {
            direction *= -1;
        }
        transform.Translate(0, speed * direction * Time.deltaTime, 0);
    }

    //Метод отрисовки пустого куба диапазона движения пилы
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, range * 2, 0));
    }
}
