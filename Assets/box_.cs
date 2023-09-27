using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_ : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector] public Transform target;
    public Transform leftLimt;
    public Transform rightLimt;
    public bool x=false;
    public bool y=false;
    private bool isY=false;
    // Start is called before the first frame update
    void Start()
    {
        SelectTarget();
        SelectTarget_Y();
    }

    // Update is called once per frame
    void Update()
    {
        if(x){
            Move();
        if(!insideofLmits()){
             SelectTarget();
        }
        }

        if(y){
            if(isY){
               Move_Y(); 
               if(!insideofLmits_Y()){
                SelectTarget_Y();
               }
               
            }
            
        }    
         
        
    }
    void Move(){   
    Vector2 targetPosition =new Vector2(target.position.x,transform.position.y);
        transform.position=Vector2.MoveTowards(transform.position,targetPosition,moveSpeed*Time.deltaTime);
    }
      public void SelectTarget(){
        float distanceToleft=Vector2.Distance(transform.position,leftLimt.position);
        float distancetoRight=Vector2.Distance(transform.position,rightLimt.position);
        if(distanceToleft>distancetoRight){
            target =leftLimt;
        }else{
            target=rightLimt;
        }
    }
     private bool insideofLmits(){

        return transform.position.x > leftLimt.position.x && transform.position.x <rightLimt.position.x;
    }private bool insideofLmits_Y(){

        return transform.position.y > leftLimt.position.y && transform.position.y <rightLimt.position.y;
    }
    void Move_Y(){
        Vector2 targetPo= new Vector2(transform.position.x,target.position.y);
        transform.position=Vector2.MoveTowards(transform.position,targetPo,moveSpeed*Time.deltaTime);
    }
    public void SelectTarget_Y(){
        float distanceToleft=Vector2.Distance(transform.position,leftLimt.position);
        float distancetoRight=Vector2.Distance(transform.position,rightLimt.position);
        if(distanceToleft>distancetoRight){
            target =leftLimt;
        }else{
            target=rightLimt;
        }
        }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")){
            isY=true;
              
        }
    }
}
