using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class work_list : MonoBehaviour
{
    public int list_number = 13; //리스트의 갯수
    public List<work> worklist;

    public work design_1;
    public work design_2;
    public work design_3;
    public work design_4;
    public work program_1;
    public work program_2;
    public work program_3;
    public work program_4;
    public work art_1;
    public work art_2;
    public work art_3;
    public work art_4;
    public work rest;
    

    // Start is called before the first frame update
    void Start()
    {
        worklist = new List<work>(list_number); //최초 리스트 생성.
        worklist.Add(design_1);
        worklist.Add(design_2);
        worklist.Add(design_3);
        worklist.Add(design_4);
        worklist.Add(program_1);
        worklist.Add(program_2);
        worklist.Add(program_3);
        worklist.Add(program_4);
        worklist.Add(art_1);
        worklist.Add(art_2);
        worklist.Add(art_3);
        worklist.Add(art_4);
        worklist.Add(rest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
