using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp.Model
{
    public class Handler : IGraphHandler
    {
        public int DistanceBetween(UserNode start, UserNode end)
        {
            Queue<UserNode> users = new Queue<UserNode>();
            HashSet<UserNode> discovered = new HashSet<UserNode> { start };
            List<int> distances = new List<int> { 0 };
            users.Enqueue(start);
            int counter = 0;
            int distance;
            while (users.Count > 0)
            {
                distance = distances[counter];
                var v = users.Dequeue();
                if (v.Equals(end))
                {
                    return distance;
                }
                counter++;
                distance++;
                foreach (var friend in v.Friends)
                {
                    if (!discovered.Contains(friend))
                    {
                        discovered.Add(friend);
                        users.Enqueue(friend);
                        distances.Add(distance);
                    }
                }
            }
            return 0;
        }

        public HashSet<UserNode> FriendsOfFriends(UserNode start, int distance)
        {
            Queue<UserNode> users = new Queue<UserNode>();
            HashSet<UserNode> discovered = new HashSet<UserNode> { start };
            HashSet<UserNode> results = new HashSet<UserNode>();
            List<int> distances = new List<int> { 0 };
            users.Enqueue(start);
            int counter = 0;
            int searchDistance;
            while (users.Count > 0)
            {
                searchDistance = distances[counter];
                var v = users.Dequeue();
                if (searchDistance > distance)
                {
                    results.Remove(start);
                    return results;
                }
                counter++;
                searchDistance++;
                foreach (var friend in v.Friends)
                {
                    if (!discovered.Contains(friend))
                    {
                        discovered.Add(friend);
                        users.Enqueue(friend);
                        distances.Add(searchDistance);
                    }
                    if (searchDistance <= distance)
                    {
                        results.Add(friend);
                    }
                }
            }
            results.Remove(start);
            return results;
        }

        public HashSet<UserNode> ShortestPathBetween(UserNode start, UserNode end)
        {
            throw new NotImplementedException();
        }
    }
}
