using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggArenaCheck : MonoBehaviour
{
    private enemy_beti enemyParent;
    private void Awake(){
        enemyParent =GetComponentInParent<enemy_beti>();
       
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")){
            gameObject.SetActive(false);
            enemyParent.target =collider.transform;
            enemyParent.inRange =true;
            enemyParent.hotZone.SetActive(true);
                     
        }
    }

}
