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

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        if (value > Data)
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
        if(value == Data) {
            return true;
        }
        else if(value > Data && Right is not null) {
            return Right.Contains(value);
        }
        else if(value < Data && Left is not null) {
            return Left.Contains(value);
        }
        else {
            return false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        int sizeOfLeft = 0, sizeOfRight = 0;

        if(Left is not null) {
            sizeOfLeft = Left.GetHeight();
        }

        if(Right is not null) {
            sizeOfRight = Right.GetHeight();
        }

        if(sizeOfLeft > sizeOfRight) {
            return sizeOfLeft + 1;
        }
        else {
            return sizeOfRight + 1;
        }
    }
}