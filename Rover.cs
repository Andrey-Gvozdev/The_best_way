using System;
using System.Collections.ObjectModel;

public class Rover {

    
    public static void CalculateRoverPath(int[,] map) {
        var openList = new Collection<Point>();
        var closedList = new Collection<Point>();
        var neighborList = new Collection<Point>();

        Point startPoint = new Point()
        {
            CoordPoint = new int[] { 0, 0 },
            Height = map[0, 0],
            FuelFromStart = 0,
            PrevPoint = null
        };

        Point goalPoint = new Point()
        {
            CoordPoint = new int[] { map.GetUpperBound(0), map.GetUpperBound(1) },
            Height = map[map.GetUpperBound(0), map.GetUpperBound(1)],
            FuelFromStart = Int32.MaxValue,
            PrevPoint = null
        };

        neighborList.Add(startPoint);

        while (true)
        {
            Point activePoint = TakeActivePoint(goalPoint, neighborList);
            
            if (CalcHeuristic(activePoint, goalPoint) == 1)
            {
                //goalPoint[4] = currentPoint[0];
                //goalPoint[5] = currentPoint[1];
                //goalPoint[6] = currentPoint[2];
                //goalPoint[3] = currentPoint[3] + Math.Abs(goalPoint[2] - goalPoint[6]) + 1;
                //output in .txt
                break;
            }

            closedList.Add(activePoint);

            //AddingNeighborPoints(currentPoint, map, openList, neighborList);

            foreach (var challengerPoint in neighborList)
            {
                foreach (var openListPoint in openList)
                {
                    if (challengerPoint.CoordPoint[0] == openListPoint.CoordPoint[0] && challengerPoint.CoordPoint[1] == openListPoint.CoordPoint[1])
                    {
                        if (challengerPoint.FuelFromStart < openListPoint.FuelFromStart)
                        {

                        }
                    }
                }
                //openList.Add();
            }
        }
    }
    public static int CalcHeuristic(Point currentPoint, Point goalPoint)
    {
        int heuristic = Math.Abs(currentPoint.CoordPoint[0] - goalPoint.CoordPoint[0]) + Math.Abs(currentPoint.CoordPoint[1] - goalPoint.CoordPoint[1]);

        return heuristic;
    }

    public static void AddingNeighborPoints(Point currentPoint, int[,] map, Collection<Point> neighborList)
    {
        neighborList.Clear();

        if (currentPoint.CoordPoint[0] - 1 >= 0)
        {
            Point upperPoint = new Point
            {
                CoordPoint = new int[] { currentPoint.CoordPoint[0] - 1, currentPoint.CoordPoint[1] },
                Height = map[currentPoint.CoordPoint[0] - 1, currentPoint.CoordPoint[1]],
                FuelFromStart = currentPoint.FuelFromStart + Math.Abs(currentPoint.Height - map[currentPoint.CoordPoint[0] - 1, currentPoint.CoordPoint[1]]) + 1,
                PrevPoint = currentPoint
            };
            neighborList.Add(upperPoint);
        }
        if (currentPoint.CoordPoint[1] - 1 >= 0)
        {
            Point leftPoint = new Point
            {
                CoordPoint = new int[] { currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] - 1 },
                Height = map[currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] - 1],
                FuelFromStart = currentPoint.FuelFromStart + Math.Abs(currentPoint.Height - map[currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] - 1]) + 1,
                PrevPoint = currentPoint
            };
            neighborList.Add(leftPoint);
        }
        if (currentPoint.CoordPoint[1] + 1 <= map.GetUpperBound(1))
        {
            Point rightPoint = new Point
            {
                CoordPoint = new int[] { currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] + 1 },
                Height = map[currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] + 1],
                FuelFromStart = currentPoint.FuelFromStart + Math.Abs(currentPoint.Height - map[currentPoint.CoordPoint[0], currentPoint.CoordPoint[1] + 1]) + 1,
                PrevPoint = currentPoint
            };
            neighborList.Add(rightPoint);
        }
        if (currentPoint.CoordPoint[0] + 1 <= map.GetUpperBound(0))
        {
            Point lowerPoint = new Point
            {
                CoordPoint = new int[] { currentPoint.CoordPoint[0] + 1, currentPoint.CoordPoint[1] },
                Height = map[currentPoint.CoordPoint[0] + 1, currentPoint.CoordPoint[1]],
                FuelFromStart = currentPoint.FuelFromStart + Math.Abs(currentPoint.Height - map[currentPoint.CoordPoint[0] + 1, currentPoint.CoordPoint[1]]) + 1,
                PrevPoint = currentPoint
            };
            neighborList.Add(lowerPoint);
        }
    }

    public static Point TakeActivePoint(Point goalPoint, Collection<Point> neighborList)
    {
        Point activePoint = neighborList[0];
        
        foreach (var point in neighborList)
        {
            if (CalcHeuristic(point, goalPoint) + point.FuelFromStart < CalcHeuristic(activePoint, goalPoint) + activePoint.FuelFromStart)
            {
                activePoint = point;
            }
        }

        return activePoint;
    }
}

public class Point
{
    public int[] CoordPoint { get; set; }
    public int Height { get; set; }
    public int FuelFromStart { get; set; }
    public Point PrevPoint { get; set; }
}