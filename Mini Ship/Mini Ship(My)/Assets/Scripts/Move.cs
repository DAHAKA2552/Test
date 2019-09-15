using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; //скорость движения
    private bool check = false; //переключатель направления
    private float scale; //множитель для определения маршрута в зависимости от крана

    void Start()
    {
        scale = (1920f / 1080f) / ((float)Screen.height / Screen.width); //получение множителя исходя из размеров по умолчанию
    }

    void Update()
    {
        if (this.GetComponent<Transform>().position.x <= -2.45f * scale) //если игрок дошел до края
        {
            check = true; 
        }
        if (this.GetComponent<Transform>().position.x >= 2.45f * scale) //если игрок дошел до другого края
        {
            check = false; 
        }
        if(check) //если переключатель включен
        {
            this.GetComponent<Transform>().position = 
                Vector3.MoveTowards(this.GetComponent<Transform>().position, 
                new Vector3( 2.5f * scale, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z), 
                speed * Time.deltaTime); //передвижение вправо
        }
        else //иначе
        {
            this.GetComponent<Transform>().position = 
                Vector3.MoveTowards(this.GetComponent<Transform>().position,
                new Vector3(- 2.5f * scale, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z),
                speed * Time.deltaTime); //передвижение влево
        }
    }
}
