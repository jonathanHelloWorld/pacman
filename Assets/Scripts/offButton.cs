using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offButton : MonoBehaviour {

    public GameObject btn;

	public void off()
    {
        btn.gameObject.SetActive(false);
    }

}
