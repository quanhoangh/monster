// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class hotzone_Fly : MonoBehaviour
// {
//     private enemyFly_Attk enemyFly_Attk;
//     private bool inRange_;
//     private Animator anim;
//     private void Awake(){
//         enemyFly_Attk=GetComponentInParent<enemyFly_Attk>();
//         anim=GetComponentInParent<Animator>();
//     }
//     private void Update() {
//     if(inRange_&&!anim.GetCurrentAnimatorStateInfo(0).IsName("attk")){
        
//     }
//     private void OnTriggerEnter2D(Collider2D collider) {
//         if(collider.gameObject.CompareTag("Player")){
//             inRange_ =true;
//         }
//     }
//   private void OnTriggerExit2D(Collider2D collider) {
//     if(collider.gameObject.CompareTag("Player")){
//         inRange_=false;
//         gameObject.SetActive(false);
//         enemyFly_Attk.triggerArea.SetActive(true);
//         enemyFly_Attk.inRange=false;
//     }
//   }
// }
