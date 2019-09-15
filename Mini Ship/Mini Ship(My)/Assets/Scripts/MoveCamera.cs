using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Camera;

    [SerializeField]
    private float speed = 10f; //скорочть движения

    void Start()
    {
        this.GetComponent<BoxCollider2D>().size = new Vector2(Screen.width, Screen.height); //изменение размера тригера
    }

    void OnMouseDrag()
    {
        Camera.position = Vector2.MoveTowards(Camera.position, new Vector2(Camera.position.x, Camera.position.y + 2.5f), speed * Time.deltaTime); //продолжать движени пока зажата кнопка
    }
}
