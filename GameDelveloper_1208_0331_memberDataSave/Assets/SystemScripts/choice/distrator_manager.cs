using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distrator_manager : MonoBehaviour
{
    public int choice_number; //선택한 선택지의 결과를 의미한다.
    public int event_number; //현재 이벤트의 번호를 판단한다.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //이벤트 리스트가 필요하다. 이벤트의 위쪽 선택지(1)일때의 효과
    //아래쪽 선택지(2)일때의 효과가 나오도록. 물론 대사도 마찬가지다.

   public void reset_choice() //선택지에 대한 결과가 끝나면 선택한것을 리셋해주는 함수. 결과반영후에 사용하면 된다.
    {
        choice_number = 0;
    }

}
