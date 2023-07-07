using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float score;
    public float timer;
    public float health;
    public float shield;

    public Boss boss;

    private void Awake()
    {
        Instance = this;
    }
}
