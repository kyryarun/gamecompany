
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 

    public Slot[] slots;  // 슬롯들 배열

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //인벤내의 아이템정보 확인
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcquireItem(Item _item, int _count = 1) //상점에서 구매할때 이것을 사용하면 된다.
    {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
                {
                    if (slots[i].item.item_sort == _item.item_sort) //같은 아이템이 있다면. 사실 같은 아이템이 없을리가 없다. 그냥 같은 아이템인 슬롯을 파악하는 것
                    {
                        slots[i].Add_item(_count);
                        return;
                    }
                }
            }
    }

}
