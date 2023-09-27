using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_3 : MonoBehaviour
{
    public int dameSkil_3;
    public float aliveTime;
    // Start is called before the first frame update
    private void Awake() {
        Destroy(gameObject,aliveTime);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.CompareTag("enemy")){
        collider.GetComponent<Enemy>().takeDamage(dameSkil_3);  
    }if(collider.gameObject.CompareTag("enemy_Fly")){
        collider.GetComponent<enemy_hp_Fly>().takeDamage(dameSkil_3);
    }
    if(collider.gameObject.CompareTag("boss")){
        collider.GetComponent<hp_boss>().takeDamage(dameSkil_3);
    }
    }
}
