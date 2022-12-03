using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PCInputController : MonoBehaviour
{
    private MovementController playerMovement; //��������� ����� �������� ������
    private float move; //����� ��������
    private bool isJump; //�������� �� ������

    private void Start()
    {
        playerMovement = GetComponent<MovementController>(); //�������� ��������� ������ �������� ������
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal"); //����������� ������� ������� (���������� �� -1 �� 1)
        if (Input.GetButtonUp("Jump")) //����������� ������� ������ ��� ������ (������)
        {
            isJump = true;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Space key was pressed.");
            Application.Quit();
        }
    }

    //�������, ������ ���������� ����� �������� ���������� ������, �� ������� �� ��������� ����������, ����� �����������
    private void FixedUpdate()
    {
        playerMovement.Move(move, isJump); //��������� ����� �������� � �������� ������
        isJump = false;
       
    }
}
