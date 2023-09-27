using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public float poinOpen;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        opendoor();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void opendoor(){
       rb.position = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
    }
}
