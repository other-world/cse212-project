public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            // Traverse to the left
            if (Left is null)
                return false;
            else if (Left.Contains(value))
                    return true;
        }
        else
        {
            // Traverse to the right
            if (Right is null)
                return false;
            else if (Right.Contains(value))
                    return true;
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // This turned out ugly. I talked to ChatGPT about improving it, and ChatGPT gave me a really clean version, but this is my own work, so it's what I'm turning in.
        if (Left is null && Right is null)
            return 1;
        else if (Left is null && Right is not null)
        {
            return Right.GetHeight() + 1;
        }
        else if (Right is null && Left is not null)
        {
            return Left.GetHeight() + 1;
        }
        else if (Left.GetHeight() > Right.GetHeight())
        {
            return Left.GetHeight() + 1;
        }
        else
        {
            return Right.GetHeight() + 1;
        }

        //return 0; // Replace this line with the correct return statement(s)
    }
}