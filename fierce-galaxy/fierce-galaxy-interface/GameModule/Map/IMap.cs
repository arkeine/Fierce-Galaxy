namespace FierceGalaxyInterface.GameModule
{
    public interface IMap : IReadOnlyMap
    {
        /// <summary>
        /// Add a fully created node to the map
        /// </summary>
        /// <returns>True if the node was added , false otherwise (if node alredy exist)</returns>
        bool AddNode(IReadOnlyNode node);

        /// <summary>
        /// Add a fully created node to the map as a spawn node
        /// </summary>
        /// <param name="node"></param>
        /// <returns>True if the node was added, false otherwise (if node alredy exist)</returns>
        bool AddSpawnNode(IReadOnlyNode node);

        /// <summary>
        /// Remove the given node from the map
        /// </summary>
        /// <returns>True if the node was removed, false otherwise (if the node don't exist)</returns>
        bool RemoveNode(IReadOnlyNode node);

        /// <summary>
        /// Add a link between 2 nodes.
        /// - The nodes must be already in the map
        /// - The link must not already exist
        /// </summary>
        /// <returns>True if the link was added, false otherwise</returns>
        bool AddLink(IReadOnlyNode node1, IReadOnlyNode node2);

        bool RemoveLink(IReadOnlyNode node1, IReadOnlyNode node2);
    }
}
