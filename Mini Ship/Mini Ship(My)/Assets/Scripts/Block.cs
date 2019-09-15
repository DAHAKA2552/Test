using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public GameObject lose;    //канвас с результатом игры
    public GameObject trigger; //тригет отлавливающий нажатие по экрану
    public Counter counter;    //счетчик

    private int bestscore; //переменная для сравнивания счета

    void Start()
    {
        bestscore = PlayerPrefs.GetInt("Score"); //получение максимального счета
        counter = GameObject.Find("Counter").gameObject.GetComponent<Counter>(); //получение счетчика
        trigger = GameObject.Find("Trigger");//получение тригера
        lose = GameObject.Find("Lose");//получение канваса
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//если игрок столкнулся с "блоком"
        {
            Transform Shield = collision.gameObject.transform.Find("Shield_Bubble");
            if (!Shield.gameObject.activeSelf)//если щит не активирован
            {
                trigger.SetActive(false);//отключение тригера
                collision.gameObject.transform.Find("Explosion").gameObject.SetActive(true); //эфект взрыва
                this.gameObject.GetComponent<AudioSource>().enabled = true;//звук взрыва
                Destroy(collision.gameObject, 0.1f);//удаление объекта с задержкой
                Invoke("LoseScene", .5f);//вызов функции с задержкой
                GameObject.Find("Text").SetActive(false); //скрыть текст со счетом
            }
            else //если был щит
            {
                this.gameObject.GetComponent<AudioSource>().enabled = true; //звук взрыва
                Shield.gameObject.SetActive(false);//отлключение щита
                Destroy(this);//уничтожение скрипта на этом блоке
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;//"скрыть" объект
            }
        }
    }

    void LoseScene()
    {
        if(counter.playerscore > bestscore) //если текущий счет больше лучшего
        {
            PlayerPrefs.SetInt("Score", counter.playerscore);//замена лучшего счета
            PlayerPrefs.Save();//сохранение изменений
        }
        bestscore = PlayerPrefs.GetInt("Score");//получение счета
        lose.transform.Find("Replay").gameObject.SetActive(true);//отображени элементов GUI
        lose.transform.Find("LoseGame").gameObject.SetActive(true);
        lose.transform.Find("ScoreFrame").gameObject.SetActive(true);
        lose.transform.Find("ScoreFrame").gameObject.transform.Find("Score").gameObject.GetComponent<Text>().text = Convert.ToString(counter.playerscore);//отображение счета
        lose.transform.Find("ScoreFrame").gameObject.transform.Find("Best").gameObject.GetComponent<Text>().text = Convert.ToString(bestscore);//отображение лучшего счета
    }
}
