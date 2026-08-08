//// Models/FoodWeightService.cs
//using RandomMenuProject.Models;

//public interface IFoodWeightService
//{
//    // Returns a list of selected foods based on usage history
//    List<FoodItem> GetDiverseMenu(IEnumerable<FoodItem> allFoods, int count, Dictionary<int, int> usageHistory);

//    // Updates the history with the newly selected foods
//    void UpdateHistory(List<int> selectedIds, Dictionary<int, int> usageHistory);
//}

//public class FoodWeightService : IFood
//{
//    private readonly Random _random = new Random();

//    public List<Food> GetDiverseMenu(IEnumerable<Food> allFoods, int count, Dictionary<int, int> usageHistory)
//    {
//        var foodList = allFoods.ToList();
//        if (count <= 0) return new List<Food>();
//        if (count >= foodList.Count) return foodList;

//        // 1. Calculate Weights
//        // Weight = 1 / (TimesSeen + 1)
//        // If food was seen 0 times, weight is 1.0
//        // If food was seen 5 times, weight is 0.16 (much lower)
//        var weightedFoods = foodList.Select(f => new
//        {
//            Food = f,
//            Weight = 1.0 / (usageHistory.GetValueOrDefault(f.Id, 0) + 1.0)
//        }).ToList();

//        var selectedResults = new List<Food>();
//        var remainingFoods = weightedFoods.ToList();

//        for (int i = 0; i < count; i++)
//        {
//            if (!remainingFoods.Any()) break;

//            double totalWeight = remainingFoods.Sum(x => x.Weight);
//            double diceRoll = _random.NextDouble() * totalWeight;
//            double cumulativeWeight = 0;

//            foreach (var item in remainingFoods)
//            {
//                cumulativeWeight += item.Weight;
//                if (diceRoll <= cumulativeWeight)
//                {
//                    selectedResults.Add(item.Food);
//                    // Remove from remaining so we don't pick the same item in the same generation
//                    remainingFoods.Remove(item);
//                    break;
//                }
//            }
//        }

//        return selectedResults;
//    }

//    public void UpdateHistory(List<int> selectedIds, Dictionary<int, int> usageHistory)
//    {
//        foreach (var id in selectedIds)
//        {
//            if (usageHistory.ContainsKey(id))
//                usageHistory[id]++;
//            else
//                usageHistory[id] = 1;
//        }
//    }
//}