using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float vel = 0.4f;
    private Vector2 dest = Vector2.zero;
    public int momentoDeInteracaou = 0;
    public int momentoDeInteracaod = 0;
    public int momentoDeInteracaol = 0;
    public int momentoDeInteracaor = 0;
	void Start () {

        dest = transform.position;
     
    }

    private void FixedUpdate()
    {
    
        Vector2 p = Vector2.MoveTowards(transform.position, dest, vel);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (momentoDeInteracaou == 0)
            {
              momentoDeInteracaou++;
              momentoDeInteracaod = 0;
              momentoDeInteracaol = 0;
            
              momentoDeInteracaor = 0;
              transform.eulerAngles = new Vector3(0, 0, 90);
            }
            dest = (Vector2)transform.position + Vector2.up;
          
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (momentoDeInteracaod == 0)
            {
                momentoDeInteracaod++;
                momentoDeInteracaou = 0;
                momentoDeInteracaol = 0;

                momentoDeInteracaor = 0;
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            dest = (Vector2)transform.position + Vector2.down;
           
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (momentoDeInteracaor == 0)
            {
                momentoDeInteracaor++;
                momentoDeInteracaou = 0;
                momentoDeInteracaol = 0;

                momentoDeInteracaod = 0;
                transform.eulerAngles = new Vector2(0, 0);
            }
            dest = (Vector2)transform.position + Vector2.right;
        
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (momentoDeInteracaol == 0)
            {
                momentoDeInteracaol++;
                momentoDeInteracaou = 0;
                momentoDeInteracaod = 0;

                momentoDeInteracaor = 0;
                transform.eulerAngles = new Vector2(0, 180);
            }
          
            dest = (Vector2)transform.position + Vector2.left;
            
        }
    }

    bool valid (Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    
}
