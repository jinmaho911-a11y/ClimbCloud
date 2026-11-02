using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 300.0f;

    float walkForce = 15.0f;
    float maxWalkSpeed = 2.0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigid2D.linearVelocity.y) < 0.01f)
{
    animator.SetTrigger("jump");
    rigid2D.AddForce(Vector2.up * jumpForce);
}

    int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        if(transform.position.y <- 8f)
        {
            SceneManager.LoadScene("GameScene");
        }

        //플레이어 속도
        float speedx = Mathf.Abs(rigid2D.linearVelocity.x);


        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        animator.speed = speedx / 2.0f;
    }
// 골 도착

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골인!");
    }
}


//Physics 는 Rigidbody 컴포넌트와 Collider 컴포넌트로 구성됩니다 Rigidbody 컴포넌트는 '힘 계산(물체에 작용하는 중력이나 마찰 등의 힘 계산)' 을 담당하고 Collider 컴포넌트는 '물체의 충돌 판정'
//을 담당합니다 따라서 Physics를 사용해 물리적인 동작을 하면 오브젝트에는 Rigidbody 와 Collider라는 컴포넌트 두개가 적용된다
//플레이어에 Circle Collider 2D를 적용하면 플레이어를 둘러싼 녹색 원이 나타납니다 충돌 판정용 콜라이더임
//앞에서 설명한 충돌 판정용 원과 마찬가지로 다른 오브젝트에 콜라이더가 닿으면 플레이어가 닿았다고 간주함
//콜라이더는 Circle Collider 2D 외에ㅐ도 다음과 같은 모양이 있음 오브젝트 모양에 맞춰 선택하면 된다 원형이나 사각형 콜라이더 외에도 오브젝트에 잘 맞도록 콜라이더 모양을 자유롭게 편집할수 있는
//Polygon Collider 등이 있습니다
//Circle Collider 2D 원형
//Box Collider 2D 사각형
//Edge Collider 2D 선형 콜라이더 오브젝트 일부를 충돌 판정할떄 씀
//Polygon Collier 2D 다각형 콜라이더 정확히 맞도록 충돌할때 오브젝트랑 충돌 판정할때 씀
//플레이어에 콜라이더를 적용했으므로 플레이억 ㅏ다른 오브젝트랑 충돌해도 ㅇㅋ 이 효과 확인하고자 발밑 구름 배치하고 플레이어가 받아 보기
//플레이어에 힘을 가하려면 AddForce 메서드를 사용합니다
//Rigidbody2D 컴포넌트를 갖는 메서드를 사용하기 때문에 Strat 메서드에서 GetComponent메서드를 사용하 2D Rigidbody 그거 컴포넌트를 구해 멤버 변수에 저장해야 한다
//좌우 반전 3가지 방법
//1. SpriteRenderer 컴포넌트의 flip의 x를 true 한다
//2. y축을 기준으로 180도 회전한다
//3. Sclae를 -1로 바꾼다

//Physics 는 편리한 도구지만 사용 않해도 게임 제작 가능
//    물리동작에 따른 게임을 만들거나 충돌 판정 즐기고 싶으면 유효
//    사용자 입력 반영하려면 스크립트 작성해야 함
//    Physics를 사용해 오브젝트를 움직일때 좌표 조작 ㄴㄴ 힘을 조작


//메카님(Mecanim)은 애니메이션을 작성하고 실행할 때 유니티 에디터에서 일관되게 조작할 수 있는 기능입니다,
//    메카님을 사용하면, 게임을 설계할 때 스프라이트 애니메이션을 작성해 각 애니메이션의 교체 시기를 지정할수 있습니다
//    그러면 게임을 플레이할때 메카님이 오브젝트 상태를 판단하고 자동으로 애니메이션으로 바꿔 재생할수 있슴다