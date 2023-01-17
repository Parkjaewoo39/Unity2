using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //이동 속력

    public int JumpPower;
    private bool IsJumping;

    Vector3 lookDirection;
    //bool Input.GetKey(KeyCode key);
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        IsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftArrow)  || 
            Input.GetKey (KeyCode.RightArrow) || 
            Input.GetKey (KeyCode.UpArrow)    || 
            Input.GetKey (KeyCode.DownArrow))  
        { 
            float xx = Input.GetAxisRaw ("Vertical"); 
            float zz = Input.GetAxisRaw ("Horizontal");     
            lookDirection = xx * Vector3.forward + zz * Vector3.right;         
             
            this.transform.rotation = Quaternion.LookRotation (lookDirection); 
            this.transform.Translate (Vector3.forward * speed * Time.deltaTime);    
        }
        //수평축과 수직축의 입력값을 감지하여 저장
        // float xInput = Input.GetAxis("Horizontal");
        // float zInput = Input.GetAxis("Vertical");

        // lookDirection = xInput*Vector3.forward + zInput*Vector3.right;

        // //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        // float xSpeed = xInput*speed;
        // float zSpeed = zInput*speed;

        // //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        // Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        
        // //리지드바디의 속도에 newVelocity 할당
        // playerRigidbody.velocity = newVelocity;

        // if(Input.GetKey(KeyCode.UpArrow) == true)
        // //위쪽 방향키 입력이감지된 경우 z 방향 힘 주기
        // {
        //     playerRigidbody.AddForce(0f,0f,speed);
        // }

        // if(Input.GetKey(KeyCode.DownArrow) == true)
        // //아래쪽 방향키 입력이감지된 경우 z 방향 힘 주기
        // {
        //     playerRigidbody.AddForce(0f,0f,-speed);
        // }

        // if(Input.GetKey(KeyCode.RightArrow) == true)
        // //오른쪽 방향키 입력이감지된 경우 z 방향 힘 주기
        // {
        //     playerRigidbody.AddForce(speed,0f,0f);
        // }

        // if(Input.GetKey(KeyCode.LeftArrow) == true)
        // //왼쪽 방향키 입력이감지된 경우 z 방향 힘 주기
        // {
        //     playerRigidbody.AddForce(-speed,0f,0f);
        // }

        // this.transform.rotation = Quaternion.LookRotation(lookDirection);
       // this.transform.Translate (Vector3.forward*speed*Time.deltaTime);
    }
    // void Jump()
    // {
    //     transform.Translate((new Vector3 (0, JumpPower, 0)));

    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         if(!IsJumping)
    //         {
    //             //pring("점프가능 !");
    //             IsJumping = true;
    //         playerRigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    //         }
    //         else
    //         {
    //             return;
    //         }
    //     }
    // }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     // 바닥에 닿으면
    //     if(collision.gameObject.CompareTag("Ground"))
    //     {
    //         IsJumping = false;
    //     }
    // }

    public void Die()
    {

        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();

        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}

