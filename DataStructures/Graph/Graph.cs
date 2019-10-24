using System.Collections.Generic;

namespace DataStructures.Graph
{
    /// <summary>
    /// Граф.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Список вершин.
        /// </summary>
        private List<GraphVertex> vertices = new List<GraphVertex>();
        /// <summary>
        /// Список ребер.
        /// </summary>
        private List<GraphEdge> edges = new List<GraphEdge>();

        /// <summary>
        /// Количество вершин графа.
        /// </summary>
        public int VertexCount => vertices.Count;
        /// <summary>
        /// Количество ребер графа.
        /// </summary>
        public int EdgeCount => edges.Count;

        /// <summary>
        /// Добавить вершину.
        /// </summary>
        /// <param name="vertex">Вершина.</param>
        public void AddVertex(GraphVertex vertex)
        {
            vertices.Add(vertex);
        }
        /// <summary>
        /// Добавить ребро.
        /// </summary>
        /// <param name="from">Объект вершины из.</param>
        /// <param name="to">Объект вершины в.</param>
        /// <param name="weight">Вес.</param>
        public void AddEdge(GraphVertex from, GraphVertex to, int weight = 1)
        {
            var edge = new GraphEdge(from, to, weight);

            edges.Add(edge);
        }
        /// <summary>
        /// Получить двух-мерный массив матрица смешнности.
        /// </summary>
        /// <returns>Возвращает двух-мерный массив матрица смешанности.</returns>
        public int[,] GetMatrix()
        {
            var matrix = new int[vertices.Count, vertices.Count];

            foreach (var edge in edges)
            {
                var row = edge.From.Value - 1;
                var column = edge.To.Value - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }
        /// <summary>
        /// Получить список смежных вершин.
        /// </summary>
        /// <param name="vertex">Объект на вершину.</param>
        /// <returns>Возвращает список смежных вершин.</returns>
        public List<GraphVertex> GetVertexRelations(GraphVertex vertex)
        {
            var result = new List<GraphVertex>();

            foreach (var edge in edges)
            {
                if (edge.From.Equals(vertex))
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }
        /// <summary>
        /// Получить словарь всех смежных вершин.
        /// </summary>
        /// <param name="vertex">Объект на вершину.</param>
        /// <returns>Возвращает словарь всех смежных вершин.</returns>
        public Dictionary<GraphVertex, int> GetVertexAllRelations(GraphVertex vertex)
        {
            var result = new Dictionary<GraphVertex, int>();

            foreach (var edge in edges)
            {
                if (edge.From.Equals(vertex))
                {
                    result.Add(edge.To, edge.Weight);
                }
            }

            return result;
        }
        /// <summary>
        /// Проверяет на существование связи.
        /// </summary>
        /// <param name="start">Объект на начальную вергину.</param>
        /// <param name="finish">Объект на конечную вершину.</param>
        /// <returns>Возвращает true, если существует иначе, false.</returns>
        public bool IsWave(GraphVertex start, GraphVertex finish)
        {
            var vertices = new List<GraphVertex>
            {
                start
            };

            for (int index = 0; index < vertices.Count; index++)
            {
                var vertex = vertices[index];

                foreach (var current in GetVertexRelations(vertex))
                {
                    if (!vertices.Contains(current))
                    {
                        vertices.Add(current);
                    }
                }
            }

            return vertices.Contains(finish);
        }
    }
}