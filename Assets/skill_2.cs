using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_2 : MonoBehaviour
{
    public float bulletSpeed;  
    public float aliveTime;
    public int dameSkil_2;
    Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake() {
         rb=GetComponent<Rigidbody2D>();
        Destroy(gameObject,aliveTime);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.y==0){
            rb.AddForce(new Vector2 (1,0)*bulletSpeed,ForceMode2D.Impulse);
        }
        else{
            rb.AddForce(new Vector2 ( -1,0)*bulletSpeed,ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.CompareTag("enemy")){
        collider.GetComponent<Enemy>().takeDamage(dameSkil_2);  
    }
    if(collider.gameObject.CompareTag("enemy_Fly")){
        collider.GetComponent<enemy_hp_Fly>().takeDamage(dameSkil_2);
    }
    if(collider.gameObject.CompareTag("boss")){
        collider.GetComponent<hp_boss>().takeDamage(dameSkil_2);
    }
    }
}
