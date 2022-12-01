using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D playerRB; //объявляем Rigidbody2D игрока
    private Animator playerAnimator; //объявляем Animator игрока

    //Переменные для горизонтального перемещение (движения) игрока
    [Header("Horizontal movement")]
    [SerializeField] private float speed; //скорость движения
    private bool faceRight = true; //проверка, куда смотрит игрок при движении

    //Переменные для вертикального перемещения (прыжок) игрока
    [Header("Jumping")]
    [SerializeField] private float radius; //радиус Колайдера на ногах игрока, для контроля его касания к земле
    [SerializeField] private bool isAirControll; //проверка в воздухе ли игрок (в прыжке)
    [SerializeField] private float jumpForce; //сила прыжка игрока
    [SerializeField] private LayerMask whatIsGround; //получение слоя, какой слой
    [SerializeField] private Transform groundCheck; //получение позиции контакта с землей игрока
    private bool isGrounded;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();//получаем Rigidbody2D игрока
        playerAnimator = GetComponent<Animator>();//получаем Animator игрока
    }

    //Отрисовываем пустой круг для радиуса контроля контакта с землей
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius); 
    }

    //Метод, который поворачивает игрока в зависимости от направления движения
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    //Метод в котором описываем движение игрока (горизонтальное и вертикальное)
    public void Move(float move, bool isJump)
    {
        #region Movement
        //Проверяем движется ли игрок горизонтально и находится он или в воздухе
        if (move != 0 && (isGrounded || isAirControll))
            //если игрок движется (в любую стоону) и он находится на земле или в воздухе, то перемещаем его по координатам
            playerRB.velocity = new Vector2(speed * move, playerRB.velocity.y);

        //если игрок движется в одну сторону, а лицо сморрит в другую, то поварачиваем его на 180 градусов
        if (move > 0 && !faceRight)
        {
            Flip();
        }
        else if (move < 0 && faceRight)
        {
            Flip();
        }
        #endregion

        #region Jumping
        //Проверяем попал ли в колайдер слой земля, значит есть контакт с землей
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        //Проверка, если нажата клавиша прижка и игрок на земле.
        if (isJump && isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpForce);//задает перемещение игрока в вверх с силой прыжка
        }

        #endregion

        #region Animation
        playerAnimator.SetFloat("Speed", Mathf.Abs(move));//запускаем анимацию горизонтального движения
        playerAnimator.SetBool("Jump", !isGrounded);//запускаем анимацию прижка
        #endregion
    }
}
