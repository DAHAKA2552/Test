using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject[] objects; //массив объектов для спавна
    public GameObject spawnPoint;//местоспавна
    public Counter counter;//счет

    private void Start()
    {
        counter = GameObject.Find("Counter").gameObject.GetComponent<Counter>();//определение счета
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Block") //если это "Блок"
        {
            Destroy(other.gameObject); //уничтожение объекта
            int rand = Random.Range(0, 100); //рандом, для рандомного спавна "блоков"
            if (counter.playerscore % 10 == 0) //если кол-во очков кратно 10
            {
                Instantiate(objects[4], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
            }//спавн щита
            else if (counter.playerscore % 5 == 0)//кратно 5
            {
                Instantiate(objects[3], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
            }//спавл бонуса
            else
            {
                if (rand <= 33)
                {
                    Instantiate(objects[0], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                }//первый "блок"
                else if (rand > 33 && rand < 66)
                {
                    Instantiate(objects[1], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                }//второй "блок"
                else
                {
                    Instantiate(objects[2], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                }//третий "блок"
            }
        }
    }
}
