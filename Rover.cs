using System;
using System.Collections.ObjectModel;

public class Rover {

    
    public static void CalculateRoverPath(int[,] map) {
        var openList = new Collection<int[]>();
        var closedList = new Collection<int[]>();

        //Point info { {0}active i, {1}active j, {2}active height, {3}fuel from start point, {4}prev i, {5}prev j, {6}prev height }
        int[] startPoint = { 0, 0, map[0, 0], 0, 0, 0, map[0, 0] };
        int[] goalPoint = { map.GetUpperBound(0), map.GetUpperBound(1), map[map.GetUpperBound(0), map.GetUpperBound(1)], Int32.MaxValue };

    }
    public int CalcHeuristic(int[] currentPoint, int[] goalPoint)
    {
        int heuristic = Math.Abs(currentPoint[0] - goalPoint[0]) + Math.Abs(currentPoint[1] - goalPoint[1]);

        return heuristic;
    }

    public int CalcFuelConsumptionFromStart(int[] currentPoint, int[] goalPoint)
    {
        int fuelConsamption = currentPoint[3] + CalcHeuristic(currentPoint, goalPoint) + Math.Abs(currentPoint[2] - currentPoint[6]) + 1;
        return fuelConsamption; 
    }
}
