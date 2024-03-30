using System;
using System.Collections.Generic;
using System.Threading;

public class Elevator
{
    public int ID;
    public int capacity;
    private int currentFloor;
    private bool movingUp;
    private bool movingDown;
    private Queue<int> requests;

    public Elevator(int ID)
    {
        this.ID = ID;
        capacity = 5;
        currentFloor = 1;
        movingUp = false;
        movingDown = false;
        requests = new Queue<int>();
    }

    public void RequestFloor(int floor)
    {
        lock (requests)
        {
            requests.Enqueue(floor);
            capacity -= 1;
            Monitor.Pulse(requests);
        }
    }

    public void Start()
    {
        while (true)
        {
            int nextFloor;
            lock (requests)
            {
                while (requests.Count == 0)
                {
                    Monitor.Wait(requests);
                }
                nextFloor = requests.Dequeue();
                capacity++;
            }

            if (nextFloor > currentFloor)
            {
                movingUp = true;
                movingDown = false;
                Console.WriteLine("Moving up to floor " + nextFloor + " Elevator " + ID);
                while (currentFloor < nextFloor)
                {
                    Thread.Sleep(1000); // Simulating travel time
                    currentFloor++;
                    //Console.WriteLine("Current floor: " + currentFloor + " current Elevator " + ID);
                    CheckForNewRequests();
                }
                movingUp = false;
            }
            else if (nextFloor < currentFloor)
            {
                movingDown = true;
                movingUp = false;
                Console.WriteLine("Moving down to floor " + nextFloor + " Elevator " + ID);
                while (currentFloor > nextFloor)
                {
                    Thread.Sleep(1000); // Simulating travel time
                    currentFloor--;
                    //Console.WriteLine("Current floor: " + currentFloor + " current Elevator " + ID);
                    CheckForNewRequests();
                }
                movingDown = false;
            }

            Console.WriteLine($"Elevator {ID} Arrived at floor {currentFloor}");
        }
    }

    private void CheckForNewRequests()
    {
        lock (requests)
        {
            if (requests.Count > 0 && ((movingUp && requests.Peek() > currentFloor) || (movingDown && requests.Peek() < currentFloor)))
            {
                int nextFloor = requests.Dequeue();
                capacity++;
                Console.WriteLine($"Request for floor {nextFloor} dequeued while in motion. by elevator {ID}");
            }
        }
    }
}


class Controller
{
    Queue<int> requests = new Queue<int>();
    private readonly object lockObject = new object();
    List<Elevator> elevators;

    public Controller()
    {
        elevators = new List<Elevator>() { new Elevator(1), new Elevator(2) };
        foreach(var elevator in elevators)
        {
            Thread elevatorTh = new Thread(elevator.Start);
            elevatorTh.Start();
        }
    }
    public void Start()
    {
        while (true)
        {
            int nextFloor;
            lock (lockObject)
            {
                if (requests.Count > 0)
                {
                    var selectedElevator = elevators.Where(x => x.capacity > 0).ToList();
                    if (selectedElevator.Count > 0)
                    {
                        nextFloor = requests.Dequeue();
                        selectedElevator[0].RequestFloor(nextFloor);
                    }
                }
            }
        }
    }
    public void RequestFloor(int floor)
    {
        lock (lockObject)
        {
            requests.Enqueue(floor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Controller cont = new Controller();
        
        Thread contThread = new Thread(cont.Start);
        contThread.Start();

        // Example requests
        cont.RequestFloor(6);
        cont.RequestFloor(2);
        cont.RequestFloor(3);
        cont.RequestFloor(6);
        cont.RequestFloor(8);
        cont.RequestFloor(2);
        cont.RequestFloor(18);
        cont.RequestFloor(12);

        cont.RequestFloor(28);
        cont.RequestFloor(21);
        cont.RequestFloor(8);
        cont.RequestFloor(9);

        cont.RequestFloor(2);
        cont.RequestFloor(1);
        cont.RequestFloor(8);
        cont.RequestFloor(19);
        cont.RequestFloor(12);
        cont.RequestFloor(21);
        cont.RequestFloor(23);
        cont.RequestFloor(11);
    }
}
