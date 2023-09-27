using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotzoneCheck : MonoBehaviour
{
    private enemy_beti enemyParent_;
    private Enemy die;
    private bool inRange_;
    private Animator anim;
    private void Awake(){
        enemyParent_=GetComponentInParent<enemy_beti>();
        anim=GetComponentInParent<Animator>();
    }
    private void Update() {
    if(inRange_&&!anim.GetCurrentAnimatorStateInfo(0).IsName("attk")){
        if(enemyParent_.GetComponent<enemy_beti>().enabled==true)
        enemyParent_.flip();
    }    
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")){
            inRange_ =true;
        }
    }
  private void OnTriggerExit2D(Collider2D collider) {
    if(collider.gameObject.CompareTag("Player")){
        inRange_=false;
        gameObject.SetActive(false);
        enemyParent_.triggerArea.SetActive(true);
        enemyParent_.inRange=false;
        enemyParent_.SelectTarget();
    }
  }
}
