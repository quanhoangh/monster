    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float attackDistance;
    public Transform target; 
    public float speed =5f;
    public float colldown;
    private float currenColldown;
    public float colldown_skill_1;
    private float curren_Skill_1;
    public float Time_skill_1;
    private float curren_Time_skill_1;
    public int skill_1_cast;
    private int curren_Skill_1_cast=0;
    private bool cast=true;
    Rigidbody2D rb;
    Animator animator;
    private float distance;
    public float start_;
    public bool check=false;

    private bool attackMode;
    private bool checkflip;

    // private int startTimer=1;

    // Start is called before the first frame update
    void Start()
    {
         rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
         
    }
    
    // Update is called once per frame
    void Update()
    { 
        if(start_>Time.time){
            rb.velocity=Vector2.zero;
           
                 animator.SetTrigger("start");
            
           
            return;
        }
        if(Time.time<currenColldown){
            rb.velocity=Vector2.zero;
            checkflip=false;
            return;
        }else if(Time.time>currenColldown){
            checkflip=true;
        } 
        if(check){
            
            EnemyLogic();
            if(!attackMode){
            move();
            }
            Skill_bring_1();
        } 
    }
    void Skill_bring_1(){
        if(Time.time>curren_Skill_1){ 
        if(cast){
        animator.SetTrigger("cast");
        cast=false;
        }
         curren_Skill_1=colldown_skill_1+Time.time;
        }
         
        if(cast==false){
            if(Time.time>curren_Time_skill_1){
            GetComponent<BringSkil>().Skill_1();
            curren_Skill_1_cast++; 
            curren_Time_skill_1=Time_skill_1+Time.time;
            
            }
            checkCast();
        }
        
    }
    void checkCast(){
         if(skill_1_cast <=curren_Skill_1_cast){
            curren_Skill_1_cast=0;
            cast=true;
        }
    }
      void EnemyLogic(){
        
        distance =Vector2.Distance(transform.position,target.position);
        if(distance >attackDistance){
           
            stopAttack();
        }
        else if(attackDistance>=distance)
        {
            if(Time.time >currenColldown){
                 Attack_(); 
                currenColldown=Time.time +colldown;
            }
        }
        

    }
        void Attack_(){
        attackMode=true;
        animator.SetBool("walk",false);
        animator.SetBool("attk",true);
    }
    
    void stopAttack(){
        attackMode=false;
      
        animator.SetBool("attk",false);
    }
   
    private void move(){
        animator.SetBool("walk",true);  
         animator.SetBool("attk",false);
       Vector2 targetPosition =new Vector2(target.position.x,transform.position.y);
        transform.position=Vector2.MoveTowards(transform.position,targetPosition,speed*Time.deltaTime);
            flip();
        
        
    }
     public void flip(){
        Vector3 rotation=transform.eulerAngles;
        if(checkflip){
             if(transform.position.x >target.position.x){
            rotation.y=180f;
        }else{
            rotation.y=0f;
        }
        }
        transform.eulerAngles=rotation;
    }
}
