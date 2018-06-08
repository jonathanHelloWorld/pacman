using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Control;

public class Ghost : MonoBehaviour, IEnemy
{

    public Transform[] waiPoints;
    public float speed = 0.3f;
    public GameObject prefab;
    public GameObject _btn;
    public Transform local;
    public Text GameOver;
    int c = 0; int cc = 2;
    private int cur = 0;

    private void Start()
    {
        GameOver.text = "Vidas: " + cc.ToString();


    }

    private void FixedUpdate()
    {
        if (transform.position.x != waiPoints[cur].position.x || transform.position.y != waiPoints[cur].position.y)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waiPoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
        {
            cur = (cur + 1) % waiPoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (ControlPadCats.Instance.EatGhost == false)
        {
            if (outro.CompareTag("pac"))
            {

                Destroy(outro.gameObject);
                cc--;
                c++;

                if (c < 2)
                {
                    GameOver.text = "Vidas: " + cc.ToString();
                    StartCoroutine(s1());
                }
                if (c == 2)
                {
                    _btn.SetActive(true);
                    ControlPadCats.Instance.level1 = 336;
                    ControlPadCats.Instance.level2 = 290;
                    GameOver.text = "Game Over";

                }
            }
        }
    }

    public bool Vuneravel()
    {
        return true;
    }

    public bool Morreu()
    {
        return true;
    }

    public bool Nasceu()
    {
        return true;
    }

    public void Andar()
    {

    }

    public void Atacar()
    {

    }


    IEnumerator s1()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(prefab, local.position, local.rotation);
    }

    IEnumerator twoSeconds()
    {
        yield return new WaitForSeconds(2.0f);
    }



}
