# Game-of-Life

Code Snippets:

A continuación se presentan fragmentos de código suelto (snippets) que podrás reutilizar en tu solución.

⚠️ Atención!! Estos fragmentos de código son genéricos y no funcionaran simplemente haciendo copy/paste. Si bien la estructura general y la mayoría del código no debería ser necesario modificarlo, deberan ser adaptados a tu solución propuesta.

Lógica de juego:

El siguiente code snippet contiene la lógica necesaria para procesar una generación del juego. Se asume:

Que el tablero es un array de 2 dimensiones de booleanos, donde true indica una célula viva y false indica una célula muerta.
El objeto gameBoard contiene un tablero ya cargado con todos los valores asignados.
bool[,] gameBoard = /* contenido del tablero */;
int boardWidth = gameBoard.GetLength(0);
int boardHeight = gameBoard.GetLength(1);

bool[,] cloneboard = new bool[boardWidth, boardHeight];
for (int x = 0; x < boardWidth; x++)
{
    for (int y = 0; y < boardHeight; y++)
    {
        int aliveNeighbors = 0;
        for (int i = x-1; i<=x+1;i++)
        {
            for (int j = y-1;j<=y+1;j++)
            {
                if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                {
                    aliveNeighbors++;
                }
            }
        }
        if(gameBoard[x,y])
        {
            aliveNeighbors--;
        }
        if (gameBoard[x,y] && aliveNeighbors < 2) 
        {
            //Celula muere por baja población
            cloneboard[x,y] = false; 
        }
        else if (gameBoard[x,y] && aliveNeighbors > 3) 
        {
            //Celula muere por sobrepoblación
            cloneboard[x,y] = false; 
        }
        else if (!gameBoard[x,y] && aliveNeighbors == 3) 
        {
            //Celula nace por reproducción 
            cloneboard[x,y] = true; 
        }
        else
        {
            //Celula mantiene el estado que tenía
            cloneboard[x,y] = gameBoard[x,y];
        }
    }
}
gameBoard = cloneboard;
cloneboard = new bool[boardWidth, boardHeight];
Leer Archivo
Este snippet muestra como leer un archivo y crear un array bi-dimensional de booleanos (bool[,]) con el contenido. Se asume que cada linea del archivo corresponde a una fila de la matriz y cada caracter de la fila corresponde a un elemento de la fila correspondiente de la matriz. Tambien se asume que el archivo contiene solamente los caracteres 1 y 0 correspondientes a true y false respectivamente y que todas las filas son de igual largo. Por ejemplo, el siguiente archivo de texto:

100
011
110
se convierte en la siguiente matriz:

bool[3,3] {
    {true, false, false},
    {false, true, true},
    {true, true, false}
};
Esta forma incluso tiene nombre y se llama glider



Snippet de código:

string url = "ruta del archivo";
string content = File.ReadAllText(url);
string[] contentLines = content.Split('\n');
bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
for (int  y=0; y<contentLines.Length;y++)
{
    for (int x=0; x<contentLines[y].Length; x++)
    {
        if(contentLines[y][x]=='1')
        {
            board[x,y]=true;
        }
    }
}

Imprimir Tablero:

Aqui se muestra como imprimir un tablero por consola. Observa que este código requiere invocar el snippet la lógica de Juego

bool[,] b //variable que representa el tablero
int width //variabe que representa el ancho del tablero
int height //variabe que representa altura del tablero
While (true)
{
    Console.Clear();
    StringBuilder s = new StringBuilder();
    for (int y = 0; y<height;y++)
    {
        for (int x = 0; x<width; x++)
        {
            if(b[x,y])
            {
                s.Append("|X|");
            }
            else
            {
                s.Append("___");
            }
        }
        s.Append("\n");
    }
    Console.WriteLine(s.ToString());
    //=================================================
    //Invocar método para calcular siguiente generación
    //=================================================
    Thread.Sleep(300);
}
