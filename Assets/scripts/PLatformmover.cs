using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformmover : MonoBehaviour
{

    public float rate = 2.6f;
    private float Tillspawn;
    public GameObject cherry1,cherry2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Tillspawn = rate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Tillspawn>0)
        {
            Tillspawn-=Time.deltaTime;
        }
        else
        {
             transform.position = new Vector2(transform.position.x,transform.position.y+19);
             cherry1.SetActive(true);
             cherry2.SetActive(true);
             if(Tillspawn>2.2)
             {
               Tillspawn = rate-0.01f;
             }
             else
             {
                 Tillspawn = rate;
             }
        }
    }
}
