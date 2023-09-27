using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFly_Attk : MonoBehaviour
{
  #region Public variavles
    public float attackDistance;
    public float timer;
    public GameObject triggerArea;
    #endregion

    #region Private Variables 

    public Animator animator;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    public float colldown_;
    private float currenCodown=0;
    public enemyFyli enemyFyli;
    #endregion 
    private void Awake() {
        intTimer=timer;
    }
    void Update()
    {
         EnemyLogic();
    }
    void EnemyLogic(){

        distance =Vector2.Distance(transform.position,enemyFyli.target.position);
        
        if(distance >attackDistance){
           
            stopAttack();
        }
        else if(attackDistance>=distance&&cooling==false)
        {           
                if(Time.time >currenCodown){
                    Attack_();   
                    currenCodown=Time.time +colldown_;
                }else if(Time.time <currenCodown){
                    stopAttack();
                }
                         
            
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
    
    void Attack_(){
        timer=intTimer;
        attackMode=true;
        animator.SetBool("attk",true);
    }

    void stopAttack(){
        cooling =false;
        attackMode=false;
        animator.SetBool("attk",false);
    } 
 
}
