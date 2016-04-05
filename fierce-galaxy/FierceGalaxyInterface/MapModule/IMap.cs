namespace FierceGalaxyInterface.MapModule
{
    /// <summary>
    /// The map manage the nodes and connexions between them in a coerente way
    /// </summary>
    public interface IMap : IReadOnlyMap
    {
        /// <summary>
        /// Add a node to the map
        /// - The node must not exist in the map
        /// </summary>
        /// <returns>True if the node was added , false otherwise</returns>
        bool AddNode(IReadOnlyNode node);
        
        /// <summary>
        /// Remove the given node from the map.
        /// - The node must be in the map
        /// </summary>
        /// <returns>True if the node was removed, false otherwise</returns>
        bool RemoveNode(IReadOnlyNode node);

        /// <summary>
        /// Set a as a spawn node
        /// - The node must be in the map
        /// </summary>
        /// <returns>True if the node was correctly set, false otherwises</returns>
        bool SetSpawnNode(IReadOnlyNode node, bool isSpawn);

        /// <summary>
        /// Add a link between 2 nodes.
        /// - The nodes must be already in the map
        /// - A link must not already exist between them
        /// </summary>
        /// <returns>True if the link was added, false otherwise</returns>
        bool AddLink(IReadOnlyNode node1, IReadOnlyNode node2);

        /// <summary>
        /// Remove a link between tow nodes
        /// - The link must exist between them
        /// </summary>
        /// <returns>True if the link was added, false otherwise</returns>
        bool RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2);
    }
}
