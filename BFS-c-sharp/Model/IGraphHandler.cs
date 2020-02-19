using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp.Model
{
    interface IGraphHandler
    {
        int DistanceBetween(UserNode start, UserNode end);
        HashSet<UserNode> FriendsOfFriends(UserNode start, int distance);
        HashSet<UserNode> ShortestPathBetween(UserNode start, UserNode end);
    }
}
