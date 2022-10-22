using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float scaleFactor = 1;
    public EnemySize enemySize;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUp()
    {
        switch (enemySize)
        {
            case EnemySize.Small:
                scaleFactor = 1;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case EnemySize.Medium:
                scaleFactor = 2;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case EnemySize.Large:
                scaleFactor = 3;
                transform.localScale = Vector3.one * scaleFactor;
                break;
        }
    }
}
