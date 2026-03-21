using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add an items to the back of the queue. Use the same priority to show they go in and out in order.
    // Expected Result: High1, High2, High3
    // Defect(s) Found: Queue is not returning FIFO: Queue mismatch, Found: High2, expected: High1. Either the elements are going in in the wrong order, or coming out in the wrong order.
    public void TestPriorityQueue_InitialQueueOrder()
    {
        List<string> prioties = new List<string> {"High1", "High2", "High3"};

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("High2", 3);
        priorityQueue.Enqueue("High3", 3);

        for (int i = 0; i<3; i++)
        {
            string priorityCheck = priorityQueue.Dequeue();
            if (priorityCheck != prioties[i])
                Assert.Fail("Queue mismatch, Found: " + priorityCheck + ", expected: " + prioties[i]);
        }
    }

    [TestMethod]
    // Scenario: Check to see if hte queue will return higher priorities before lower priorities. 
    // Expected Result: "High1", "High2", "High3", "Medium", "Low"
    // Defect1 Found: High2 came out first. The good news is that it was prioritized over the Medium. The bad news is that is came out before High1.
    // Defect 2 Found: After fixing the code by adding a removal to dequeue and adjusting a comparison, the code is now failing later. It's pulling Medium before High3. 
    public void TestPriorityQueue_ProperPriorityResults()
    {
        List<string> prioties = new List<string> {"High1", "High2", "High3", "Medium", "Low"};

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("High2", 3);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High3", 3);

        for (int i = 0; i<5; i++)
        {
            string priorityCheck = priorityQueue.Dequeue();
            if (priorityCheck != prioties[i])
                Assert.Fail("Queue mismatch, Found: " + priorityCheck + ", expected: " + prioties[i]);
        }
    }

    [TestMethod]
    // Scenario: Check to see if error is thrown for empy queue.
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try 
        {
            priorityQueue.Dequeue();
            Assert.Fail("Empty Queue not detected.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

}