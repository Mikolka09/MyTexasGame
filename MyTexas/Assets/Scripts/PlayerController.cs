using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Класс для контроля жизни игрока с анимацией его смерти
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image playerImageHealth;
    private Animator animator; //объявляем Animator игрока
    [SerializeField] private int maxHp; //максимальный уровень жизни
    private float currentHp; //текущий уровень жизни
    private bool isDead; //проверка смерти игрока

    void Start()
    {
        currentHp = maxHp; //задаем текущий уровень жизни
        animator = GetComponent<Animator>(); //получаем Animator игрока
    }

    //Метод изменения жизни игрока
    public void ChangeHp(float value)
    {
        //изменяем текущий уровень жизни
        currentHp += value;
        //проверяем текущий уровень жизни с максимальным, если уровень меньше нуля запускам анимацию сметри и удалаем игрока
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

    //Задержка 0,8 секунды и потом перезагрузка сцены
    private IEnumerator MomentGame()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
