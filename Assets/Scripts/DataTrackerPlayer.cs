using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTrackerPlayer : MonoBehaviour
{
    //Singleton
    //Coisas de que só queremos 1
    public int TotalScore = 0;
    public static DataTrackerPlayer Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
