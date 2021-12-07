using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_list : MonoBehaviour
{
    public int list_number = 25; //리스트의 갯수
    public List<Event> event_List;

    public Event p_design_1;
    public Event p_design_2;
    public Event p_design_3;
    public Event p_design_4;
    public Event p_program_1;
    public Event p_program_2;
    public Event p_program_3;
    public Event p_program_4;
    public Event p_art_1;
    public Event p_art_2;
    public Event p_art_3;
    public Event p_art_4;
    public Event n_design_1;
    public Event n_design_2;
    public Event n_design_3;
    public Event n_design_4;
    public Event n_program_1;
    public Event n_program_2;
    public Event n_program_3;
    public Event n_program_4;
    public Event n_art_1;
    public Event n_art_2;
    public Event n_art_3;
    public Event n_art_4;
    public Event nothing;
    public Event Revive;
    // Start is called before the first frame update
    void Start()
    {
        event_List = new List<Event>(list_number);
        event_List.Add(p_design_1);
        event_List.Add(p_design_2);
        event_List.Add(p_design_3);
        event_List.Add(p_design_4);
        event_List.Add(p_program_1);
        event_List.Add(p_program_2);
        event_List.Add(p_program_3);
        event_List.Add(p_program_4);
        event_List.Add(p_art_1);
        event_List.Add(p_art_2);
        event_List.Add(p_art_3);
        event_List.Add(p_art_4);
        event_List.Add(n_design_1);
        event_List.Add(n_design_2);
        event_List.Add(n_design_3);
        event_List.Add(n_design_4);
        event_List.Add(n_program_1);
        event_List.Add(n_program_2);
        event_List.Add(n_program_3);
        event_List.Add(n_program_4);
        event_List.Add(n_art_1);
        event_List.Add(n_art_2);
        event_List.Add(n_art_3);
        event_List.Add(n_art_4);
        event_List.Add(nothing);
        event_List.Add(Revive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
