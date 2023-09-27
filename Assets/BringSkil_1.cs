using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringSkil_1 : MonoBehaviour
{
      public int dameSkil_1;
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
    if(collider.gameObject.CompareTag("Player")){
        collider.GetComponent<HeathPlayer>().takeDame(dameSkil_1); 
    }
}
}