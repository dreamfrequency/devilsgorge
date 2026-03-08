namespace BlazorStarter.Services;

public class GameItem
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string IconType { get; init; }
}

public class GameState
{
    private readonly List<GameItem> _inventory = [];
    private readonly HashSet<string> _collectedItemIds = [];

    public event Action? OnStateChanged;

    public IReadOnlyList<GameItem> Inventory => _inventory;

    public bool IsItemCollected(string itemId) => _collectedItemIds.Contains(itemId);

    public void CollectItem(GameItem item)
    {
        if (_collectedItemIds.Contains(item.Id))
            return;

        _collectedItemIds.Add(item.Id);
        _inventory.Add(item);
        OnStateChanged?.Invoke();
    }

    public bool HasItem(string itemId) => _collectedItemIds.Contains(itemId);
}
