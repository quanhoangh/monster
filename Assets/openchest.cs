using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openchest : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("attk")){
            ani.SetTrigger("open");
        }
    }
}
