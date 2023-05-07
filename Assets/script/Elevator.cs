using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Elevator
{
    private int current_floor = 0;
    private int goto_floor = 0;

    public int display_floor()
    {
        return current_floor;
    }

    public void move(int current_floor, int goto_floor)
    {
        this.current_floor = current_floor;  
        this.goto_floor = goto_floor;      
    }

    public void move()
    {
        if(current_floor != goto_floor)
        {
            if(current_floor > goto_floor)
            {
                current_floor--;
            }
            else
            {
                current_floor++;
            }
        }
    }

}
