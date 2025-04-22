using UnityEngine;
using UnityEngine.UI;

public class SeatingChartController : MonoBehaviour
{
    public int numRows = 5;
    public int numCols = 8;

    private string[,] seatingChart;

    public Text display;
    
    void Start()
    {
        seatingChart = new string[numCols, numRows];

        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                seatingChart[x, y] = "";
            }
        }
        seatingChart[1, 0] = "MP";
        
        PrintWhereSeated();
    }

    public void PrintWhereSeated()
    {
        string toPrint = "~~~~ FRONT ~~~~\n";
        for (int y = 0; y < seatingChart.GetLength(1); y++)
        {
            for (int x = 0; x < seatingChart.GetLength(0); x++)
            {
                if (seatingChart[x, y] != "")
                {
                    toPrint += seatingChart[x, y];
                }
                else
                {
                    toPrint += " _ ";
                }
            }

            toPrint += "\n";
        }

        toPrint += "~~~~ BACK ~~~~";

        display.text = toPrint;
    }

}
