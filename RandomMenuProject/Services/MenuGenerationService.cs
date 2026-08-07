using RandomMenuProject.Models;
using RandomMenuProject.Services;

namespace RandomMenuProject.Services;

public interface IMenuGenerationService
{
    Task<List<FoodItem>> GenerateDiverseMenuAsync(int count);
}

public class MenuGenerationService : IMenuGenerationService
{
    private readonly FoodService _foodService;
    private readonly Random _random = new Random();

    public MenuGenerationService(FoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<List<FoodItem>> GenerateDiverseMenuAsync(int count)
    {
        var allFoods = await _foodService.GetAllAsync();

        if (count <= 0) return new List<FoodItem>();
        if (count >= allFoods.Count) return allFoods;

        // 1. Calculate weights based on SelectionCount
        // We use 1 / (SelectionCount + 1) so that higher count = lower weight
        var weightedFoods = allFoods.Select(f => new
        {
            Food = f,
            Weight = 1.0 / (f.SelectionCount + 1.0)
        }).ToList();

        var selectedItems = new List<FoodItem>();
        var remainingPool = weightedFoods.ToList();

        for (int i = 0; i < count; i++)
        {
            if (!remainingPool.Any()) break;

            double totalWeight = remainingPool.Sum(x => x.Weight);
            double diceRoll = _random.NextDouble() * totalWeight;
            double cumulativeWeight = 0;

            foreach (var item in remainingPool)
            {
                cumulativeWeight += item.Weight;
                if (diceRoll <= cumulativeWeight)
                {
                    selectedItems.Add(item.Food);
                    remainingPool.Remove(item); // Prevent duplicates in the same generation
                    break;
                }
            }
        }

        // 2. Update the Database: Increment the count for the items we just picked
        foreach (var selected in selectedItems)
        {
            await _foodService.IncrementSelectionCountAsync(selected.Id);
        }

        return selectedItems;
    }
}