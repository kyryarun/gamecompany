using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject //오브젝트에 추가할 필요가 없는 형태.
    //하나씩 아이템을 만들면 된다. 따로 파일로 관리함.
{
    public enum ITEM_SORT 
    {
        Small_potion,
        Normal_potion,
        Large_potion
    }

    public ITEM_SORT item_sort; //아이템의 종류. 몇가지 없는 아이템만 사용한다는 가정하에 이렇게 제작한다.
    public Sprite item_image; //일단 생성해두는 아이템의 이미지(스프라이트)
    public int item_price; //아이템의 가격
    
    [TextArea] //여러줄이 가능해진다.
    public string item_toltip; //아이템의 설명
}
