using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Control;
using UnityEngine.SceneManagement;

public class Pacman : MonoBehaviour, IPlayer
{

    public Text ganhou;
    public GameObject _btn;
    public GameObject ghost1, ghost2;
    // public GameObject prefab;
    public AudioSource musicEatGhost;
    public AudioSource music; 
    //Image pac;

    private void Start()
    {

        //pac = prefab.GetComponent<Image>();

    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("pacdot"))
        {

            Destroy(outro.gameObject);
            if (ControlPadCats.Instance.level == 0)
            {
                ControlPadCats.Instance.level1--;
            }
            else if (ControlPadCats.Instance.level == 1)
            {
                ControlPadCats.Instance.level2--;
            }

        }

        if (outro.gameObject.CompareTag("enemy") && ControlPadCats.Instance.EatGhost)
        {
            Debug.Log("PASSOU");
            Destroy(outro.gameObject);
        }

        if (outro.gameObject.CompareTag("eatghost"))
        {
            Destroy(outro.gameObject);
            ControlPadCats.Instance.EatGhost = true;
            musicEatGhost.Play();
            //  pac.color = Color.green;
            StartCoroutine(eatGhostOn());

        }

        if (ControlPadCats.Instance.level1 <= 0)
        {

            StartCoroutine(youYin());

        }

        if (ControlPadCats.Instance.level2 < 0)
        {
            ganhou.text = "YOU WIN";
            ControlPadCats.Instance.level1 = 336;
            ControlPadCats.Instance.level2 = 290;
            Destroy(ghost1.gameObject);
            Destroy(ghost2.gameObject);
            _btn.SetActive(true);

        }
    }

    IEnumerator youYin()
    {
        yield return new WaitForSeconds(1f);
        ControlPadCats.Instance.ToCall(ControlPadCats.Instance.level);
        ControlPadCats.Instance.level1 = 336;

    }

    IEnumerator eatGhostOn()
    {
        yield return new WaitForSeconds(3.0f);
        ControlPadCats.Instance.EatGhost = false;
        //pac.color = Color.white;
        musicEatGhost.Stop();

    }

    public void Movimentacao()
    {
        throw new System.NotImplementedException();
    }
    private void OnDestroy()
    {
        Debug.Log("Morreu");
        Morreu();
    }

    public bool FoiAtacado(IEnemy enemy)
    {
        throw new System.NotImplementedException();
    }

    public void TentarComer(IEnemy alvo)
    {
        throw new System.NotImplementedException();
    }

    public void Morreu()
    {
        music.Play();
    }

    public bool Nasceu()
    {
        throw new System.NotImplementedException();
    }
}
