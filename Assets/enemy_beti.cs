using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_beti : MonoBehaviour

{
    #region Public variavles
    public int attackdame_;
    public float attackDistance;
    public float moveSpeed;
    public float attackRange_=0.5f;
    public float timer;
    public Transform leftLimt;
    public Transform rightLimt;
    public Transform attk_hitbox;
    public LayerMask PlayerLayer;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    #endregion

    #region Private Variables 

    public Animator animator;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion 
    private void Awake() {
        SelectTarget();
        intTimer=timer;

        
    }
    void Update()
    {
        if(!attackMode){
            Move();
        }
        if(!insideofLmits()&&!inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("attk")){
            SelectTarget();
        }
       
       
        if(inRange){
           
            EnemyLogic();
            
        }
        
    }
    void EnemyLogic(){
        distance =Vector2.Distance(transform.position,target.position);
        if(distance >attackDistance){
           
            stopAttack();
        }
        else if(attackDistance>=distance&&cooling==false)
        {
             Attack_();             
            
        }
        if(cooling){
            colldown();
            animator.SetBool("attk",false);
        }

    }
    void colldown(){
        timer -=Time.deltaTime;
        if(timer <=0&&cooling&&attackMode){
            cooling=false;
            timer=intTimer;
        }
    }
    
    void Move(){
        animator.SetBool("canwail",true);
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("attk")){
        Vector2 targetPosition =new Vector2(target.position.x,transform.position.y);
        transform.position=Vector2.MoveTowards(transform.position,targetPosition,moveSpeed*Time.deltaTime);
        }
    }
    void Attack_(){
        timer=intTimer;
        attackMode=true;
        animator.SetBool("canwail",false);
        animator.SetBool("attk",true);
    }

    void stopAttack(){
        cooling =false;
        attackMode=false;
        animator.SetBool("attk",false);
    }

    public void triggerCooling(){
        cooling =true;
    }
    private bool insideofLmits(){

        return transform.position.x > leftLimt.position.x && transform.position.x <rightLimt.position.x;
    }
    public void SelectTarget(){
        float distanceToleft=Vector2.Distance(transform.position,leftLimt.position);
        float distancetoRight=Vector2.Distance(transform.position,rightLimt.position);
        if(distanceToleft>distancetoRight){
            target =leftLimt;
        }else{
            target=rightLimt;
        }
        flip();
    }
    public void flip(){
        Vector3 rotation=transform.eulerAngles;
        if(transform.position.x >target.position.x){
            rotation.y=180f;
        }else{
            rotation.y=0f;
        }
        transform.eulerAngles=rotation;
    }
}
