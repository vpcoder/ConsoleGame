using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Data;

namespace Engine.AStarSharp
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(Vector2 o1, Vector2 o2)
        {
            return (o1.X == o2.X) && (o1.Y == o2.Y);
        }
        public static bool operator !=(Vector2 o1, Vector2 o2)
        {
            return !(o1 == o2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if ((object)this == obj)
                return true;
            if (!(obj is Vector2))
                return false;

            Vector2 other = (Vector2)obj;
            return other == this;
        }

        public override int GetHashCode()
        {
            return ($"{X}.{Y}").GetHashCode();
        }
    }

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

    public class AStar
    {
        public Node[,] Grid { get; set; }
        public int SizeY { get; set; }
        public int SizeX { get; set; }

        public AStar(Map map)
        {
            this.Grid = new Node[map.SizeX, map.SizeY];

            for (int y = 0; y < map.SizeY; y++)
                for (int x = 0; x < map.SizeX; x++)
                    Grid[x, y] = new Node(new Vector2(x, y), true, 1f);

            this.SizeX = map.SizeX;
            this.SizeY = map.SizeY;
            this.UpdatePathMatrix(map);
        }

        public void UpdatePathMatrix(Map map)
        {
            for(int y = 0; y < map.SizeY; y++)
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

        public List<Node> FindPath(Vector2 Start, Vector2 End)
        {
            Node start = new Node(new Vector2(Start.X, Start.Y), true);
            Node end = new Node(new Vector2(End.X, End.Y), true);

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
