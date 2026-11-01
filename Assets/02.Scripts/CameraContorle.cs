using UnityEngine;

public class CameraContorle : MonoBehaviour
{
    public GameObject cat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 catPos = cat.transform.position;
        transform.position = new Vector3(catPos.x, catPos.y, transform.position.z);
    }
}


// physics를 사용한 충돌 판정 종류에는 Collision 모드(충돌 모드)와 Trigger 모드 (통과 모드)가 있습니다 Collision 모드는 오브젝트가 닿았을때 충돌 판정을 물론 충돌했을때 ㅜ주변에 미치는 영향까지 포함해 충돌 반응 실행 한편 Trigger 모드는 오브젝트가 닿았을때 충돌 판정만 하고 충돌 반응은 실행하지 않습니다 따라서 Trigger 모드로 설정된 오브젝트는 다른 오브젝트와 충돌해도 서로 밀리거나 튕기지 않습니다

//Collision 모드를 예로 들면 오브젝트들이 충돌한 순간에는 OnCollisionEnter2D 메서드가 한번만 호출됨(3D라면 OncollisionEnter 이 오고)충돌 중에는 OnCollisionStay2D 메서드가 호출됩니다
//    충돌한 오브젝트가 떨어지는 순간 OnCollisionExit2D 메서드가 한번만 호출됩니다 