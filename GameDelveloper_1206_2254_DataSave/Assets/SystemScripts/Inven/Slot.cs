using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool onstore; //상점의 것인지 파악
    public Item item; //슬롯에 해당되는 아이템. 여기서는 지정되어져 있기때문에 그냥 수동추가다.
    public int itemCount = 0; // 슬롯 아이템의 개수. 최초에는 0개로 표시해야한다.
    public Image itemImage;  // 아이템의 이미지

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    public void Add_item(int item_count = 1) //상점에서 아이템을 구매했을때 사용하는 함수. 인벤토리(퀵슬롯)에 개수를 증가시켜준다.
    {
        itemCount += item_count; //개수 증가
        text_Count.text = "x" + itemCount.ToString(); //개수를 텍스트에 적용.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onstore == false)
        {
            if (eventData.button == PointerEventData.InputButton.Left) //왼쪽 마우스라면
            {
                if (item != null)//사실 아이템이 없을리가 없다.
                {
                    Debug.Log("마우스가 된다.");
                    if (itemCount != 0)
                    {
                        Debug.Log("아이템을 사용했다.");
                        itemCount--;
                        text_Count.text = "x" + itemCount.ToString(); //개수를 텍스트에 적용.
                    }
                }
                else
                {
                    Debug.Log("아이템이 없다.");
                }
            }
        }
        else if (onstore == true)
        {
            if (eventData.button == PointerEventData.InputButton.Left) //왼쪽 마우스라면
            {
                if (item != null)//사실 아이템이 없을리가 없다.
                {
                    Gamemanager.GetInstance().store.cal_gold(item);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //툴팁이 뜨도록 하는 마우스가 입장했을때
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData) //툴팁이 사라지도록 하는 마우스가 나갔을때
    {
        //throw new System.NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        text_Count.text = "x" + itemCount.ToString(); //최초에 개수 적용
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
