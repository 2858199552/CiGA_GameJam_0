using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMask : MonoBehaviour
{
    public float speed;
    public bool isOpen;

    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;

    public float showTimer;
    public float showTimeMax;

    public Prop prop;
    public List<Prop> props = new List<Prop>();
    public Transform content;

    public float eatMoveSpeed;

    private void Start()
    {
        OnOpenStart(false);
    }

    void Update()
    {
        if (isOpen)
        {
            if (transform.position.y < endPoint.transform.position.y)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                isOpen = false;
                OnOpenStart(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPull();
        }

        if (GameManager.Instance.boss.food < 15)
        {
            speed = 1;
        }
        else if (GameManager.Instance.boss.food < 25)
        {
            speed = 1.3f;
        }
        else if (GameManager.Instance.boss.food < 35)
        {
            speed = 1.6f;
        }
        else if (GameManager.Instance.boss.food < 45)
        {
            speed = 1.9f;
        }
        else if (GameManager.Instance.boss.food < 55)
        {
            speed = 2.1f;
        }
    }

    public void OnOpenStart(bool isEat)
    {
        isOpen = true;
        showTimer = 0;
        transform.position = startPoint.position;

        if (!isEat && prop)
        {
            Destroy(prop.gameObject);
        }
        var newProp = props[Random.Range(0, props.Count)];
        prop = Instantiate(newProp, content);
    }

    public void OnPull()
    {
        prop.OnGet();
        StartCoroutine(OnEat(prop.gameObject));
        OnOpenStart(true);
    }

    private IEnumerator OnEat(GameObject prop)
    {
        while (Vector2.Distance(prop.transform.position, GameManager.Instance.boss.transform.position) > 1)
        {
            prop.transform.position = Vector3.Lerp(prop.transform.position, GameManager.Instance.boss.transform.position, Time.deltaTime * eatMoveSpeed);
            yield return null;
        }
        Destroy(prop);
    }
}
