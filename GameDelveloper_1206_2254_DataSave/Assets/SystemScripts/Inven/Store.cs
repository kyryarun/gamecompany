using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 

    public Slot[] slots;  // 슬롯들 배열

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //상점내의 판매아이템정보 확인
        set_store();//한번만 하도록.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_store()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].onstore = true; //하위 슬롯들을 상점용으로 세팅.
        }
    }

    public void cal_gold(Item item)
    {
        Gamemanager gamemanager = Gamemanager.GetInstance();
        if (item.item_price <= gamemanager.player_gold)
        {
            gamemanager.inventory.AcquireItem(item);
            Debug.Log("아이템을 구매하였다.");
            gamemanager.player_gold -= item.item_price;
            gamemanager.set_gold();
        }
        else
        {
            Debug.Log("골드가 부족하다.");
        }
    }


}
