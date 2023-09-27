using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private float vertical;
    private bool isLadder=false;
    public bool isClimbing;
    public float speed;
  [SerializeField]  private Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {   
      rb=GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    { 
        vertical =Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical)>0f){
            isClimbing= true;
               
        }
        
        if(isClimbing){
            rb.gravityScale=0f;
            rb.velocity =new Vector2(rb.velocity.x,vertical * speed);
        }
       
           
           
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("ladder")){
            isLadder=true;
        
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
          if(collider.CompareTag("ladder")){
            isLadder=false;
            isClimbing=false;
        }
    }
}
