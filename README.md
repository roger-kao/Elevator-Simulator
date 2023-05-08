# Elevator-Simulator
This simulator is edited with Unity Engine
There is a .exe file in ElevatorSimulator

## Elevator.cs
In Asset/script， provides class elevator, which has 

### attribute 
current_floor
goto_floor, means the destination floor

### methods 
display_floor(), returns current floor
move(int current_floor, int goto_floor), from current_floor move to goto_floor
mone(), when calls it, current floor +1

## Main.cs
In Asset/script, create and initialize two elevators and control the movement

### Update
Control the speed of two elevators

## ElevatorTests.cs
In Asset/script/Test/EditMode, an unit test of elevator

## Server.cs
Initialize a server in Elevator, can receive message from client and control the elevators by the command

#### client is undone
 
