using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggBoss : MonoBehaviour
{
    
     private BossMove bossMove; 
    private void Awake(){
        bossMove =GetComponentInParent<BossMove>();
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")){
           bossMove.GetComponent<BossMove>().check=true;
        }
        
    }
}
