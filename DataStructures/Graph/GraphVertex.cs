namespace DataStructures.Graph
{
    /// <summary>
    /// Вершина графа.
    /// </summary>
    public class GraphVertex
    {
        /// <summary>
        /// Значение.
        /// </summary>
        public int Value { get; set; }

        public GraphVertex(int value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
