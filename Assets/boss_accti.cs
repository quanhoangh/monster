using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_accti : MonoBehaviour
{
    public GameObject boss;
    public GameObject boss_UI;
    public GameObject wall_boss;
    public float time=3f;
    public Animator animator;
    public BossMove bossMove;
    public BringSkil bringSkil;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.gameObject.CompareTag("Player")){
        boss_UI.SetActive(true);
        wall_boss.SetActive(true);
        StartCoroutine(waitForboss());
        Start_boss();
        }
    }
   public IEnumerator waitForboss(){
        playercontroll.instance.speed =0f;
        yield return new  WaitForSeconds(time);
        playercontroll.instance.speed =12;
        bossMove.GetComponent<BossMove>().enabled=true;
        bringSkil.GetComponent<BringSkil>().enabled=true;
        Destroy(gameObject);
    }
  private void Start_boss(){
    boss.SetActive(true);
    animator.SetTrigger("start");

  }
}
