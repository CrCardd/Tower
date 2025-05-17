using Tower.LayersArchives;

namespace Tower.Layers;

public abstract class Layer
{
    protected IArchive? RootFolder { get; set; }
}