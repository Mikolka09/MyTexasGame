using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PCInputController : MonoBehaviour
{
    private MovementController playerMovement; //объ€вл€ем класс движени€ игрока
    private float move; //метод движени€
    private bool isJump; //проверка на прыжок

    private void Start()
    {
        playerMovement = GetComponent<MovementController>(); //получили компонент класса движени€ игрока
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal"); //отлавливаем нажати€ клавиши (возвращает от -1 до 1)
        if (Input.GetButtonUp("Jump")) //отлавливаем нажатие кнопки дл€ прижка (пробел)
        {
            isJump = true;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Space key was pressed.");
            Application.Quit();
        }
    }

    //‘ункци€, котра€ включаетс€ через некотрое количество кадров, не зависит от мощьности компьютера, можно настраивать
    private void FixedUpdate()
    {
        playerMovement.Move(move, isJump); //запускаем метод движени€ и передаем данные
        isJump = false;
       
    }
}
