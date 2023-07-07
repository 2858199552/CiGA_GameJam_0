using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public float score;
    public float food;
    public float health;

    public void OnGet()
    {
        GameManager.Instance.score += score;
        GameManager.Instance.boss.food += food;
        GameManager.Instance.boss.health += health;

        if (score > 0 || food > 0 || health > 0)
        {
            GameManager.Instance.boss.animator.SetTrigger("isLove");
        }
        else if (score < 0 || food < 0 || health < 0)
        {
            GameManager.Instance.boss.animator.SetTrigger("isHurt");
        }
    }
}
