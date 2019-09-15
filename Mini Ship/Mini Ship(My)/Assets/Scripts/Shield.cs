using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //если игрок подобрал щит
        {
            Destroy(this); //кничтажаем скрипт
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //"прячем" шит

            Transform Shiel = collision.gameObject.transform.Find("Shield_Bubble"); //получаем объект у игрока
            Shiel.gameObject.SetActive(true); //активируем щит
        }
    }
}
