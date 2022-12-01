using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D playerRB; //��������� Rigidbody2D ������
    private Animator playerAnimator; //��������� Animator ������

    //���������� ��� ��������������� ����������� (��������) ������
    [Header("Horizontal movement")]
    [SerializeField] private float speed; //�������� ��������
    private bool faceRight = true; //��������, ���� ������� ����� ��� ��������

    //���������� ��� ������������� ����������� (������) ������
    [Header("Jumping")]
    [SerializeField] private float radius; //������ ��������� �� ����� ������, ��� �������� ��� ������� � �����
    [SerializeField] private bool isAirControll; //�������� � ������� �� ����� (� ������)
    [SerializeField] private float jumpForce; //���� ������ ������
    [SerializeField] private LayerMask whatIsGround; //��������� ����, ����� ����
    [SerializeField] private Transform groundCheck; //��������� ������� �������� � ������ ������
    private bool isGrounded;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();//�������� Rigidbody2D ������
        playerAnimator = GetComponent<Animator>();//�������� Animator ������
    }

    //������������ ������ ���� ��� ������� �������� �������� � ������
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius); 
    }

    //�����, ������� ������������ ������ � ����������� �� ����������� ��������
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    //����� � ������� ��������� �������� ������ (�������������� � ������������)
    public void Move(float move, bool isJump)
    {
        #region Movement
        //��������� �������� �� ����� ������������� � ��������� �� ��� � �������
        if (move != 0 && (isGrounded || isAirControll))
            //���� ����� �������� (� ����� ������) � �� ��������� �� ����� ��� � �������, �� ���������� ��� �� �����������
            playerRB.velocity = new Vector2(speed * move, playerRB.velocity.y);

        //���� ����� �������� � ���� �������, � ���� ������� � ������, �� ������������ ��� �� 180 ��������
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
        //��������� ����� �� � �������� ���� �����, ������ ���� ������� � ������
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        //��������, ���� ������ ������� ������ � ����� �� �����.
        if (isJump && isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpForce);//������ ����������� ������ � ����� � ����� ������
        }

        #endregion

        #region Animation
        playerAnimator.SetFloat("Speed", Mathf.Abs(move));//��������� �������� ��������������� ��������
        playerAnimator.SetBool("Jump", !isGrounded);//��������� �������� ������
        #endregion
    }
}
