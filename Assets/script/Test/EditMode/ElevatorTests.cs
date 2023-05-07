using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Threading;

public class ElevatorTests
{
    [Test]
    public void TestDisplayFloor()
    {
        Elevator elevator = new Elevator();
        elevator.move(3, 5);
        Assert.AreEqual(elevator.display_floor(), 3);
        elevator.move();
        Assert.AreEqual(elevator.display_floor(), 4);
        elevator.move();
        Assert.AreEqual(elevator.display_floor(), 5);
    }

    [Test]
    public void TestElevatorMove()
    {
        Elevator elevator = new Elevator();
        elevator.move(1, 5);
        for (int i = 0; i < 10; i++)
        {
            //Thread.Sleep(1000);  // Wait for 1 second
            elevator.move();
        }
        Assert.AreEqual(elevator.display_floor(), 5);

        elevator.move(5, 2);
        for (int i = 0; i < 3; i++)
        {
            //Thread.Sleep(1000);  // Wait for 1 second
            elevator.move();
        }
        Assert.AreEqual(elevator.display_floor(), 2);
    }
}
