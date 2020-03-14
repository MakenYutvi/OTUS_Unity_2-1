using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera; //Камера на основе которой будем определять вышел ли объект за ее границы
    EndOfGameMenu endOfGameMenu;
    private bool theEndOfGameOnce;
    void Start()
    {
        endOfGameMenu = FindObjectOfType<EndOfGameMenu>();
        theEndOfGameOnce = false;
       // mainCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = mainCamera.WorldToViewportPoint(transform.position); //Записываем положение объекта к границам камеры, X и Y это будут как раз верхние и нижние границы камеры
        if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f)
        {
            Debug.Log("вышел за границу");
           if (theEndOfGameOnce == false)
            {
                endOfGameMenu.TheEndOfGame("Поражение");
            }
            
            theEndOfGameOnce = true;
        }
    }

}
