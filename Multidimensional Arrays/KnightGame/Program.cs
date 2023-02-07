
int size = int.Parse(Console.ReadLine());

string[,] board = new string[size,size];

if (size < 3)
{
    return;
}

for (int row = 0; row < size; row++)
{
	string input = Console.ReadLine();
	for (int col = 0; col < size; col++)
	{
		board[row, col] = input[col].ToString();
	}
}

int counter = 0;
int maxCounter = 0;
int mostAnnoyingKnightRow = 0;
int mostAnnoyingKnightCol = 0;
int totalMoves = 0;

while (true)
{
    maxCounter= 0;
    counter = 0;
    for (int row = 0; row < size; row++)
    {

        for (int col = 0; col < size; col++)
        {
            if (board[row, col] == "K")
            {
                counter = 0;

                if (isInbound(board, row - 2, col - 1) && board[row - 2, col - 1] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row - 2, col + 1) && board[row - 2, col + 1] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row - 1, col - 2) && board[row - 1, col - 2] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row - 1, col + 2) && board[row - 1, col + 2] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row + 1, col - 2) && board[row + 1, col - 2] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row + 1, col + 2) && board[row + 1, col + 2] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row + 2, col - 1) && board[row + 2, col - 1] == "K")
                {
                    counter++;
                }
                if (isInbound(board, row + 2, col + 1) && board[row + 2, col + 1] == "K")
                {
                    counter++;
                }
            }


            if (counter > maxCounter)
            {
                maxCounter = counter;
                mostAnnoyingKnightRow = row;
                mostAnnoyingKnightCol = col;
            }
        }
    }
    if (maxCounter == 0)
    {
        break;
    }
    board[mostAnnoyingKnightRow, mostAnnoyingKnightCol] = "0";
    totalMoves++;
}

Console.WriteLine(totalMoves);


static bool isInbound(string[,] board, int row, int col)
{
    bool isInbound = true;

    if (row < 0 || row >= board.GetLength(0) ||
        col < 0 || col >= board.GetLength(1))
    {
        isInbound = false;
    }
    return isInbound;
}