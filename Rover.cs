using System;
using System.Collections.ObjectModel;

public class Rover {

    
    public static void CalculateRoverPath(int[,] map) {
        var openList = new Collection<int[]>();
        var closedList = new Collection<int[]>();

        //Point info { {0}active i, {1}active j, {2}active height, {3}fuel from start point, {4}prev i, {5}prev j, {6}prev height }
        int[] startPoint = { 0, 0, map[0, 0], 0, 0, 0, map[0, 0] };
        int[] goalPoint = { map.GetUpperBound(0), map.GetUpperBound(1), map[map.GetUpperBound(0), map.GetUpperBound(1)], Int16.MaxValue, map.GetUpperBound(0), map.GetUpperBound(1) };
        int[] currentPoint = goalPoint;
        openList.Add(startPoint);

        
    }
    public static int CalcHeuristic(int[] currentPoint, int[] goalPoint)
    {
        int heuristic = Math.Abs(currentPoint[0] - goalPoint[0]) + Math.Abs(currentPoint[1] - goalPoint[1]);

        return heuristic;
    }

    public static int CalcFuelConsumptionFromStart(int[] currentPoint)
    {
        int fuelConsamption = currentPoint[3] + Math.Abs(currentPoint[2] - currentPoint[6]) + 1;
        
        return fuelConsamption; 
    }

    public static void AddingNeighborPoints(int[] currentPoint, int[,] map, Collection<int[]> openList)
    {
        var tempPoints = new Collection<int[]>();

        int[] upperPoint = { currentPoint[0] - 1, currentPoint[1] };
        int[] leftPoint = { currentPoint[0], currentPoint[1] - 1 };
        int[] rightPoint = { currentPoint[0], currentPoint[1] + 1 };
        int[] lowerPoint = { currentPoint[0] + 1, currentPoint[1] };

        tempPoints.Add(upperPoint);
        tempPoints.Add(leftPoint);
        tempPoints.Add(rightPoint);
        tempPoints.Add(lowerPoint);
        
        foreach (var point in tempPoints)
        {
            if (point[0] < 0 || point[1] < 0 || point[0] > map.GetUpperBound(0) || point[1] > map.GetUpperBound(1))
            {
                tempPoints.Remove(point);
            }
            else
                openList.Add(point);
        }
    }

    public static int[] TakeActivePoint(int[] currentPoint, Collection<int[]> openList)
    {
        foreach (var point in openList)
        {
            if (CalcHeuristic(point, currentPoint) + CalcFuelConsumptionFromStart(point) < CalcHeuristic(point, currentPoint) + CalcFuelConsumptionFromStart(point))
            {
                currentPoint = point;
            }
        }
        return currentPoint;
    }
}
