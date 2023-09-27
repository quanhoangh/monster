using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public Animator ani_door;
    private Animator myAni;
    // Start is called before the first frame update
    void Start()
    {
        myAni= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("attk")){
            ani_door.SetTrigger("open");
            myAni.SetTrigger("key");
        }
    }
}
