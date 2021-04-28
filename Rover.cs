using System;
using System.Collections.ObjectModel;

public class Rover {

    
    public static void CalculateRoverPath(int[,] map) {
        var openList = new Collection<int[]>();
        var closedList = new Collection<int[]>();

        //Point info { active i, active j, fuel from start point, prev i, prev j}
        int[] startPoint = { 0, 0, map[0, 0] };
        int[] goalPoint = { map.GetUpperBound(0), map.GetUpperBound(1), map[map.GetUpperBound(0), map.GetUpperBound(1)] };

    }

}
