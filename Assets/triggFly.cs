using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggFly : MonoBehaviour
{
     private  enemyFyli enemyFyli; 
    private void Awake(){
        enemyFyli =GetComponentInParent<enemyFyli>();
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")){
            
           enemyFyli.GetComponent<enemyFyli>().check=true;
        }
        
    }
}
