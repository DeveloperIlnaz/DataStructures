namespace DataStructures.Graph
{
    /// <summary>
    /// Ребро графа.
    /// </summary>
    public class GraphEdge
    {
        /// <summary>
        /// Вершина из.
        /// </summary>
        public GraphVertex From { get; set; }
        /// <summary>
        /// Вершина в.
        /// </summary>
        public GraphVertex To { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; set; }

        public GraphEdge(GraphVertex from, GraphVertex to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString() => $"({From}; {To})";
    }
}