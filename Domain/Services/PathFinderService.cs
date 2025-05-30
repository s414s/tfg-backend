using Domain.Entities;

namespace Domain.Services;

//public class PathFinderService
//{
//    private readonly Dictionary<long, List<Route>> _routeGraph;

//    public PathFinderService(IEnumerable<Route> routes)
//    {
//        _routeGraph = routes
//            .GroupBy(r => r.OriginId)
//            .ToDictionary(
//                g => g.Key,
//                g => g.ToList()
//            );
//    }

//    public class PathResult
//    {
//        public List<Route> Routes { get; set; } = [];
//        public decimal TotalDistance { get; set; }
//        public TimeSpan EstimatedDuration { get; set; }
//        public List<City> Cities { get; set; } = [];
//    }

//    private class NodeInfo
//    {
//        public decimal Distance { get; set; } = decimal.MaxValue;
//        public long? PreviousNodeId { get; set; }
//        public Route? RouteToNode { get; set; }
//        public bool Visited { get; set; }
//    }

//    public PathResult FindShortestPath(long originId, long destinationId)
//    {
//        var nodes = new Dictionary<long, NodeInfo>();
//        var cityIds = _routeGraph.Keys.Union(_routeGraph.Values.SelectMany(r => r.Select(x => x.DestinationId))).Distinct();

//        // Initialize all nodes
//        foreach (var cityId in cityIds)
//        {
//            nodes[cityId] = new NodeInfo();
//        }

//        // Set starting point
//        nodes[originId].Distance = 0;

//        while (true)
//        {
//            // Find the unvisited node with smallest distance
//            var current = nodes
//                .Where(n => !n.Value.Visited)
//                .OrderBy(n => n.Value.Distance)
//                .FirstOrDefault();

//            if (current.Key == 0 || current.Value.Distance == decimal.MaxValue)
//                break; // No path exists

//            if (current.Key == destinationId)
//                break; // Found destination

//            nodes[current.Key].Visited = true;

//            // If this node has no outgoing routes, skip it
//            if (!_routeGraph.ContainsKey(current.Key))
//                continue;

//            // Check all neighboring nodes
//            foreach (var route in _routeGraph[current.Key])
//            {
//                if (nodes[route.DestinationId].Visited)
//                    continue;

//                var newDistance = current.Value.Distance + route.Distance;
//                if (newDistance < nodes[route.DestinationId].Distance)
//                {
//                    nodes[route.DestinationId].Distance = newDistance;
//                    nodes[route.DestinationId].PreviousNodeId = current.Key;
//                    nodes[route.DestinationId].RouteToNode = route;
//                }
//            }
//        }

//        // Build the path result
//        var result = new PathResult();

//        // If no path was found, return empty result
//        if (nodes[destinationId].Distance == decimal.MaxValue)
//            return result;

//        var currentNodeId = destinationId;
//        while (currentNodeId != originId)
//        {
//            var nodeInfo = nodes[currentNodeId];
//            if (nodeInfo.RouteToNode == null || nodeInfo.PreviousNodeId == null)
//                break;

//            result.Routes.Insert(0, nodeInfo.RouteToNode);
//            currentNodeId = nodeInfo.PreviousNodeId.Value;
//        }

//        // Calculate totals
//        result.TotalDistance = result.Routes.Sum(r => r.Distance);
//        result.EstimatedDuration = TimeSpan.FromTicks(
//            result.Routes.Sum(r => r.GetDuration().Ticks)
//        );

//        // Build the list of cities in order
//        var currentCity = originId;
//        result.Cities.Add(result.Routes.First().Origin);
//        foreach (var route in result.Routes)
//        {
//            result.Cities.Add(route.Destination);
//        }

//        return result;
//    }
//}
