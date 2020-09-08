
public class Archivo
{

    public static Celula[,]LeerTablero(string url)
    {
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');
        Celula[,] board = new Celula[contentLines.Length, contentLines[0].Length];
        for (int  y=0; y<contentLines.Length;y++)
        {
            for (int x=0; x<contentLines[y].Length; x++)
            {
                board=new Celula(false);
                if(contentLines[y][x]=='1')
                {
                    board[x,y].IsLive=true;
                }
            }
        }
        return board;
    }
}
