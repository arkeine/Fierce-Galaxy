using FierceGalaxyInterface.GameModule.Board;

namespace FierceGalaxyInterface.GameModule
{
    public interface IPowerUpdate
    {
        IReadOnlyNode SourceNode
        {
            get;
        }

        IReadOnlyNode TargetNode
        {
            get;
        }

        IPower Power
        {
            get;
        }
    }
}