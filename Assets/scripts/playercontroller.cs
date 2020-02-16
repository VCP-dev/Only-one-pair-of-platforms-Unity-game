using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
     
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isgrounded;
    private bool scorecheck;
    public Transform ScorePlat;
    public Transform groundCheck;
    public LayerMask whatIsscoreadder;
    public float checkradius;
    public LayerMask whatIsGround;

     private Animator anim;
    

    private int extraJumps;

    
    public int extraJumpsValue=-1;

    public GameObject Plat,HIGH,title,score;
   
 

    // Start is called before the first frame update
    void Start()
    {
       score.SetActive(false);
        anim=GetComponent<Animator>();
        Plat.SetActive(false);
        extraJumps = extraJumpsValue;
        rb=GetComponent<Rigidbody2D>();
        HIGH.SetActive(true);
        ScoreScript.scorevalue=0;
                     
    }

    

   

    // Update is called once per frame
    void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundCheck.position,checkradius,whatIsGround);
       // scorecheck = Physics2D.OverlapCircle(ScorePlat.position,checkradius,whatIsscoreadder);
        moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed,rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight ==true && moveInput<0)
        {
            Flip();
        }
       /*  if(scorecheck==true)
        {
            ScoreScript.scorevalue+=1;
        }*/
    }

    void OnCollisionEnter2D(Collision2D col)
       {
           if(col.gameObject.CompareTag("cherry"))
           {
              ScoreScript.scorevalue+=1; 
              col.gameObject.SetActive(false);
              audioscript.PlaySound();
              
           }
           if(col.gameObject.CompareTag("Spike"))
           {
               gameObject.SetActive(false);
               Plat.SetActive(false);
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               HIGH.SetActive(true);
               
            
           }
       }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x*=-1;
        transform.localScale = Scaler;    
    }

    void Update()
    {
        anim.SetBool("isblinking",true);
        if(Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)/* Input.GetMouseButtonDown(0) */)
        {
            Plat.SetActive(true);
            HIGH.SetActive(false);
             title.SetActive(false);
             score.SetActive(true);
        }
 
           if(isgrounded == true)
           {
               extraJumps = extraJumpsValue;
           }

        if((/* CrossPlatformInputManager.GetButtonDown("JUMP") ||*/ Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps>0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
       

        else if(Input.GetKeyDown(KeyCode.UpArrow)/* && extraJumps == 0*/ && isgrounded==true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        
    }

    
          
    
      
    
    
    
       

   
}
