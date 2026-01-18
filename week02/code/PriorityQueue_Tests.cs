using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: Items are not removed from queue after dequeue. The Dequeue method returns the value
    // but does not call RemoveAt() to actually remove the item from the internal list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue them
    // Expected Result: Items with same priority should be dequeued in FIFO order (first in, first out)
    // Defect(s) Found: FIFO order is violated. The loop uses >= instead of > when comparing priorities,
    // causing later items with the same priority to be selected instead of the first one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities (some same, some different)
    // Expected Result: Highest priority first, then FIFO for same priority
    // Defect(s) Found: Same as TestPriorityQueue_2 - FIFO order violated due to >= comparison.
    // Also items are not removed from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // First item with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second item with priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First item with priority 3
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second item with priority 3
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Item with priority 1
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - empty queue exception handling works correctly.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Verify that items are actually removed from the queue
    // Expected Result: Queue should be empty after dequeuing all items
    // Defect(s) Found: Items are not removed from queue. The Dequeue method is missing the
    // _queue.RemoveAt(highPriorityIndex) call, so items remain in the queue after being dequeued.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);

        priorityQueue.Dequeue(); // Should remove Item2
        priorityQueue.Dequeue(); // Should remove Item1

        // Queue should now be empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Queue should be empty, exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Should return the single item
    // Defect(s) Found: The loop condition (index < _queue.Count - 1) prevents checking the last item.
    // When there's only one item at index 0, the loop never executes (1 < 0 is false), so
    // highPriorityIndex remains 0 by default, which works. However, if the highest priority item
    // is at the last position in a multi-item queue, it won't be found.
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 10);

        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Highest priority item is at the end of the queue
    // Expected Result: Should dequeue the last item first (highest priority)
    // Defect(s) Found: Loop condition (index < _queue.Count - 1) excludes the last item from being checked.
    // The highest priority item at the end is never considered, so a lower priority item is returned instead.
    public void TestPriorityQueue_7()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("Low2", 2);
        priorityQueue.Enqueue("Highest", 10);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}