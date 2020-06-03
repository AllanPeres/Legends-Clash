using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject myCastle;
    [SerializeField] private GameObject enemyCastle;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (!myCastle)
        {
            FindObjectOfType<LevelLoader>().LoadLoseScene();
        }
        if (!enemyCastle)
        {
            FindObjectOfType<LevelLoader>().LoadWinScene();
        }
    }
}
