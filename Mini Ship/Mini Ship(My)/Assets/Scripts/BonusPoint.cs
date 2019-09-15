using UnityEngine;
using System;
using UnityEngine.UI;

public class BonusPoint : MonoBehaviour
{
    public Counter counter; //скрип отвечающий за счет

    private void Start()
    {
        counter = GameObject.Find("Counter").gameObject.GetComponent<Counter>(); //находим счетчик
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //если игрок подобрал
        {
            counter.playerscore++; //прибавляем к счету
            counter.textScore.GetComponent<Text>().text = Convert.ToString(counter.playerscore); //обновление счета
            Destroy(this);  //уничтажаем скрипт
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //"прячем" бонус
        }
    }
}
