using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform start;
    private Transform end;
    public float speed;
    public Transform[] platfromTransform;
    private int lastElement;
    private int i;

    private float current;  // от 0.0 до 1.0
    private float dir;

    // Start is called before the first frame update
    void Start()
    {
        current = 0.0f;
        dir = 1.0f;
        lastElement = platfromTransform.Length-1;
        i = 0;
        start = platfromTransform[i];
        end = platfromTransform[i + 1];
    }

    // Update is called once per frame
    void Update()
    {
        current += dir * speed * Time.deltaTime / Vector3.Distance(start.position, end.position);
        if (current > 1.0f)
        {
           
            current = 0;
            if (++i == lastElement)
            {
                start = platfromTransform[lastElement];
                end = platfromTransform[0];
                i = -1;
            }
            else
            { 
                start = platfromTransform[i];
                end = platfromTransform[i+1];
            
            }
        }
        


        transform.position = Vector3.Lerp(start.position, end.position, current);
        //transform.position = Vector3.Lerp(Vector3.Normalize(start.position), Vector3.Normalize(end.position), current);
    }

    void test()
    {
        current += dir * speed * Time.deltaTime;
        if (current > 1.0f)
        {
            current = 1.0f;
            dir = -1.0f;
        }
        else if (current < 0.0f)
        {
            current = 0.0f;
            dir = 1.0f;
        }
 


        transform.position = Vector3.Lerp(start.position, end.position, current);
    }


}
