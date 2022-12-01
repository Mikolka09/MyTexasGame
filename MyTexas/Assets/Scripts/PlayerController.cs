using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//����� ��� �������� ����� ������ � ��������� ��� ������
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image playerImageHealth;
    private Animator animator; //��������� Animator ������
    [SerializeField] private int maxHp; //������������ ������� �����
    private float currentHp; //������� ������� �����
    private bool isDead; //�������� ������ ������

    void Start()
    {
        currentHp = maxHp; //������ ������� ������� �����
        animator = GetComponent<Animator>(); //�������� Animator ������
    }

    //����� ��������� ����� ������
    public void ChangeHp(float value)
    {
        //�������� ������� ������� �����
        currentHp += value;
        //��������� ������� ������� ����� � ������������, ���� ������� ������ ���� �������� �������� ������ � ������� ������
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
            playerImageHealth.fillAmount = currentHp;
        }
        else if (currentHp <= 0)
        {
            playerImageHealth.fillAmount = currentHp;
            isDead = true;
            animator.SetBool("Dead", isDead);
            StartCoroutine(MomentGame());
        }
    }

    //�������� 0,8 ������� � ����� ������������ �����
    private IEnumerator MomentGame()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
