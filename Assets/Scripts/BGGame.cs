using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGame : MonoBehaviour
{
    public static BGGame instance;
    

    void Awake()
    {

        if (instance != null)
            Destroy(gameObject);
        else
        {
          
                instance = this;
        }
    }
}
