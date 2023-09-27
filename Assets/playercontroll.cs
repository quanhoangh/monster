using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{   // jump
    public int jumppMax =2;
    public int jumpCount=0; 
    public int extrajump=1;
    public float jumpHeight;
    float jumpCollDown;

    //di chuyen
    private float Horizontal;
    public float speed;
    //dash
    private bool canDash=true;
    private bool isdashing;
    public float dashingPower=24f;
    public float dashingTime=0.1f;
    public float dashingCoolDown=0.1f;
    public Animator animator;
    public bool facingcheck =true;
    public bool grounded;
    public ghost ghost;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] protected Vector2 diretion;

    public float colldown;
    private float  colldown_attk=0;
    private bool isAttk;
    public bool canReceiveInput;
    public bool InputReceived;
    public static playercontroll instance;
    public bool isAttk_combo=false;

    private void Awake() {
        instance=this;
    }
    private void Start() 
    {
    }
    // Update is called once per frame
    void Update()
    {   
        flip();
        if(isdashing){
             rb.gravityScale =0f;
            return;
        }
        
        if(isAttk){
            rb.velocity=Vector2.zero;
            return;
        }
       
        Horizontal=Input.GetAxis("Horizontal");
        animator.SetFloat("status",Mathf.Abs(Horizontal));

        isground();
       
        if(Input.GetKey(KeyCode.S)&&Input.GetKeyDown(KeyCode.U)&&grounded==true){
            if(Time.time>colldown_attk){          
                animator.SetTrigger("dash_attk");
                GetComponent<Playerskill>().skill_dash();
                colldown_attk =Time.time +colldown;
             
            }
            
        }
        if(Input.GetKeyDown(KeyCode.J)&&Input.GetKey(KeyCode.S)&&grounded==true){
            if(Time.time>colldown_attk){
                animator.SetTrigger("attk_3");
                StartCoroutine(atkk_up());
                GetComponent<Playerskill>().skill_up();
                colldown_attk =Time.time +colldown;
                
            }
        }
        if(Input.GetKeyDown(KeyCode.U)&&grounded==true){
            if(Time.time>colldown_attk){
                GetComponent<Playerskill>().skill_2();
                StartCoroutine(atkkCheck());
                animator.SetTrigger("dash_attk");
                colldown_attk=Time.time + colldown;
             }
               
        }
        if(Input.GetKeyDown(KeyCode.I)){
            if(Time.time>colldown_attk){
            GetComponent<Playerskill>().skill_3();
            StartCoroutine(atkkCheck_3());
            animator.SetTrigger("attk_4");
            colldown_attk=Time.time +colldown;
            }
            
        }

        if(Input.GetKeyDown(KeyCode.E)){
            ghost.makeGhost=true;
        }
        
        if(Input.GetKeyDown(KeyCode.L)&&canDash){
            StartCoroutine(Dash()); 
        }
      
        else if(Input.GetKey(KeyCode.J)&&grounded==true&&!isAttk_combo){
        
       
           if(Time.time>colldown_attk){
                  isAttk_combo=true;
                colldown_attk=Time.time +colldown;
            }

        }
    if(GetComponent<ladder>().isClimbing){
        animator.SetTrigger("ladder");
    } else if(Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.K)||Input.GetKeyDown(KeyCode.W)){ 
            jump();
        }
    }
    
  
    private void FixedUpdate() {
        if(isdashing){
             rb.gravityScale =0f;
            return;
        }
        if(isAttk){
            rb.velocity=Vector2.zero;
            return;
        }
        animator.SetFloat("vetcoY",rb.velocity.y);
        
        rb.velocity =new UnityEngine.Vector2(Horizontal * speed,rb.velocity.y);  
           
        
        animator.SetBool("ground",grounded);
        isground();

    }
    // hàm

    //jump 
void jump(){
       if(grounded||jumpCollDown<extrajump){
        if(GetComponent<ladder>().isClimbing==false){
            rb.velocity =new Vector2(rb.velocity.x,jumpHeight);
            animator.SetTrigger("jump");
            jumpCount++;
        }
         
            
           }
}

    //check ground
  void isground(){
    if(Physics2D.OverlapCircle(groundCheck.position,0.5f,groundlayer)){
        grounded=true;
        jumpCount=0;
        jumpCollDown=Time.time + 0.2f;
    }else if(Time.time <jumpCollDown){
        grounded=true;
    }else{
        grounded=false;
        
    }

  }
 
  //check quay mặt
    private void flip(){
        if(facingcheck && Horizontal <0f|| !facingcheck && Horizontal >0f)
        {
            facingcheck = !facingcheck;
           UnityEngine.Vector3 localsacle=transform.localScale;
            localsacle.x *= -1f;
            transform.localScale =localsacle;
        }
    }
    private IEnumerator Dash(){
        canDash =false;
        isdashing=true;
        rb.velocity =new Vector2(transform.localScale.x*dashingPower,0f);
        tr.emitting=true;
        animator.SetTrigger("dash");
        yield return new WaitForSeconds(dashingTime);
        isdashing=false;
        tr.emitting=false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash=true;

    }
   public IEnumerator atkkCheck(){
    isAttk=true;
    yield return new WaitForSeconds(0.5f);
    isAttk=false;
    }
    public IEnumerator atkkCheck_3(){
        isAttk=true;
    yield return new WaitForSeconds(4f);
    isAttk=false;
    }
    public IEnumerator atkk_up(){
    isAttk=true;
    yield return new WaitForSeconds(0.4f);
    isAttk=false;
    }
    public void Attack(InputAction.CallbackContext context){
        if(context.performed){
            if(canReceiveInput){
                InputReceived =true;
                canReceiveInput =false;
            }
            else{
                return;
            }
        }
    }

}
