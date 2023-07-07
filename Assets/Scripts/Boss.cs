using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float food;
    public float eatSpeed;

    public float health;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        food += Time.deltaTime * eatSpeed;
        if (food <= 0 || health <= 0)
        {
            gameObject.SetActive(false);
            MainCanvas.Instance.OnGameOver();
        }
    }
}
