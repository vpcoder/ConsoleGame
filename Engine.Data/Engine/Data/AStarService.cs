using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Data
{

    public class Node
    {
        public Node Parent;
        public Vector2 Position;
        public Vector2 Center
        {
            get
            {
                return new Vector2(Position.X, Position.Y);
            }
        }
        public float DistanceToTarget;
        public float Cost;
        public float Weight;
        public float F
        {
            get
            {
                if (DistanceToTarget != -1 && Cost != -1)
                    return DistanceToTarget + Cost;
                else
                    return -1;
            }
        }
        public bool Walkable;

        public Node(Vector2 pos, bool walkable, float weight = 1)
        {
            Parent = null;
            Position = pos;
            DistanceToTarget = -1;
            Cost = 1;
            Weight = weight;
            Walkable = walkable;
        }
    }

    public class AStarService
    {
        public Node[,] Grid { get; set; }
        public int SizeY { get; set; }
        public int SizeX { get; set; }

        public AStarService(Map map)
        {
            this.UpdatePathMatrix(map);
        }

        public void UpdatePathMatrix(Map map)
        {
            if (map.SizeX == 0 || map.SizeY == 0)
                return;

            this.Grid = new Node[map.SizeX, map.SizeY];

            for (int y = 0; y < map.SizeY; y++)
                for (int x = 0; x < map.SizeX; x++)
                    Grid[x, y] = new Node(new Vector2(x, y), true, 1f);

            this.SizeX = map.SizeX;
            this.SizeY = map.SizeY;

            for (int y = 0; y < map.SizeY; y++)
            {
                for(int x = 0; x < map.SizeX; x++)
                {
                    var walkable = map.IsWalkable(x, y);
                    var node = Grid[x, y];
                    node.Walkable = walkable;
                    node.Weight = walkable ? 1f : 2f;
                }
            }
        }

        public void Set(int x, int y, bool isWalkable)
        {
            var node = Grid[x, y];
            node.Walkable = isWalkable;
            node.Weight = isWalkable ? 1f : 2f;
        }

        public List<Node> FindPath(Vector2 startPoint, Vector2 endPoint)
        {
            if (startPoint == endPoint)
                return null;

            Node start = new Node(new Vector2(startPoint.X, startPoint.Y), true);
            Node end = new Node(new Vector2(endPoint.X, endPoint.Y), true);

            List<Node> Path = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();
            List<Node> adjacencies;
            Node current = start;

            OpenList.Add(start);

            while (OpenList.Count != 0 && !ClosedList.Exists(x => x.Position == end.Position))
            {
                current = OpenList[0];
                OpenList.Remove(current);
                ClosedList.Add(current);
                adjacencies = GetAdjacentNodes(current);


                foreach (Node n in adjacencies)
                {
                    if (!ClosedList.Contains(n) && n.Walkable)
                    {
                        if (!OpenList.Contains(n))
                        {
                            n.Parent = current;
                            n.DistanceToTarget = Math.Abs(n.Position.X - end.Position.X) + Math.Abs(n.Position.Y - end.Position.Y);
                            n.Cost = n.Weight + n.Parent.Cost;
                            OpenList.Add(n);
                            OpenList = OpenList.OrderBy(node => node.F).ToList<Node>();
                        }
                    }
                }
            }

            if (!ClosedList.Exists(x => x.Position == end.Position))
            {
                return null;
            }

            Node temp = ClosedList[ClosedList.IndexOf(current)];
            if (temp == null) return null;
            do
            {
                Path.Add(temp);
                temp = temp.Parent;
            } while (temp != start && temp != null);
            return Path;
        }

        public Node FindPathNextPoint(Vector2 startPoint, Vector2 endPoint)
        {
            var path = FindPath(startPoint, endPoint);

            if (path == null || path.Count == 0)
                return null;

            return path[path.Count -1];
        }

        private List<Node> GetAdjacentNodes(Node n)
        {
            List<Node> temp = new List<Node>(4);
            int y = n.Position.Y;
            int x = n.Position.X;
            if (y + 1 < SizeY)
            {
                temp.Add(Grid[x,y + 1]);
            }
            if (y - 1 >= 0)
            {
                temp.Add(Grid[x,y - 1]);
            }
            if (x - 1 >= 0)
            {
                temp.Add(Grid[x - 1,y]);
            }
            if (x + 1 < SizeX)
            {
                temp.Add(Grid[x + 1,y]);
            }
            return temp;
        }

    }

}
