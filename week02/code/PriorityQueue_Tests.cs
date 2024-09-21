using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Metals ordered by price. Metals of lower price have a lower value. All metals in this test have unique values.
    // Expected Result: Diamond, White Gold, Gold, Silver, Bronze
    // Defect(s) Found:
    // Inside method Dequeue of PriorityQueue:
    // Index should start at 0 and be less than _queue.Count
    // _queue[index].Priority should be > and not >=
    // After var value = _queue[highPriorityIndex].Value;, the following should be added _queue.RemoveAt(highPriorityIndex);
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Silver", 2);
        priorityQueue.Enqueue("Gold", 3);
        priorityQueue.Enqueue("White Gold", 4);
        priorityQueue.Enqueue("Bronze", 1);
        priorityQueue.Enqueue("Diamond", 5);

        var item1 = priorityQueue.Dequeue();
        Assert.AreEqual(item1, "Diamond");

        var item2 = priorityQueue.Dequeue();
        Assert.AreEqual(item2, "White Gold");

        var item3 = priorityQueue.Dequeue();
        Assert.AreEqual(item3, "Gold");

        var item4 = priorityQueue.Dequeue();
        Assert.AreEqual(item4, "Silver");

        var item5 = priorityQueue.Dequeue();
        Assert.AreEqual(item5, "Bronze");
    }

    [TestMethod]
    // Scenario: Metals ordered by price. Metals of lower price have a lower value. Some mentals in thus test share the same value
    // Expected Result: Diamond, Gold, White Gold, Silver, Bronze
    // Defect(s) Found:
    // Inside method Dequeue of PriorityQueue:
    // Index should start at 0 and be less than _queue.Count
    // _queue[index].Priority should be > and not >=
    // After var value = _queue[highPriorityIndex].Value;, the following should be added _queue.RemoveAt(highPriorityIndex);
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Silver", 1);
        priorityQueue.Enqueue("Gold", 2);
        priorityQueue.Enqueue("White Gold", 2);
        priorityQueue.Enqueue("Bronze", 1);
        priorityQueue.Enqueue("Diamond", 3);

        var item1 = priorityQueue.Dequeue();
        Assert.AreEqual(item1, "Diamond");
        
        var item2 = priorityQueue.Dequeue();
        Assert.AreEqual(item2, "Gold");

        var item3 = priorityQueue.Dequeue();
        Assert.AreEqual(item3, "White Gold");

        var item4 = priorityQueue.Dequeue();
        Assert.AreEqual(item4, "Silver");

        var item5 = priorityQueue.Dequeue();
        Assert.AreEqual(item5, "Bronze");
    }

    // Add more test cases as needed below.
}