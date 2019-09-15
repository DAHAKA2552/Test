using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Counter : MonoBehaviour
{
    public int playerscore; //счет
    public GameObject textScore;

    void Start()
    {
        playerscore = 0; //сброс счета

        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(Screen.width,10); //установка размера тригера
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Block" /*&& collision.gameObject.GetComponent<SpriteRenderer>().enabled*/) //если из тригера вышел блок с объектом/объектами
        {
            playerscore++; //+ к счету (игрок прошел препятствие)
            textScore.GetComponent<Text>().text = Convert.ToString(playerscore); //обновление счета
        }
    }
}
