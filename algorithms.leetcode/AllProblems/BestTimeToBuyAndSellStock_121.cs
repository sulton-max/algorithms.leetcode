namespace BestTimeToBuyAndSellStock_121
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;

            (var minPrice, var maxPrice) = (0, 0);
            (var indexA, var max) = (0, default(int?));
            // Convert prices array to profits with index as date and order by profit
            var profits = prices
            .Select(x =>
            {
                (minPrice, maxPrice) = (minPrice > x ? x : minPrice, maxPrice < x ? x : maxPrice);
                return new[] { indexA++, x };
            })
            .OrderBy(x => x[1])
            .ToArray();

            for (indexA = 0; indexA < profits.Count(); indexA++)
            {
                // Check and skip duplicates
                if (indexA != profits.Length - 1)
                {
                    // Check if duplicate is needed
                    if (profits[indexA][1] == profits[indexA + 1][1])
                    {
                        if (!(indexA != profits.Length
                              && (profits[indexA][0] > 0 && profits[indexA][1] > prices[profits[indexA][0] - 1])
                              || (profits[indexA][0] < prices.Length - 1 &&
                                  profits[indexA][1] < prices[profits[indexA][0] + 1])))
                            continue;
                    }
                }

                // If no max is calculated yet
                var target = max.HasValue ? max.Value + profits[indexA][1] + 1 : default(int?);
                if (target.HasValue && (target < minPrice || target > maxPrice))
                    continue;

                for (var indexB = profits.Count() - 1; indexB > indexA; indexB--)
                {
                    // Check date and next max profit target
                    if (profits[indexA][0] >= profits[indexB][0])
                        continue;
                    else if (target.HasValue && target.Value > profits[indexB][1])
                        break;

                    if (!max.HasValue || profits[indexB][1] - profits[indexA][1] > max.Value)
                    {
                        max = profits[indexB][1] - profits[indexA][1];
                        break;
                    }
                }
            }

            return max.HasValue ? max.Value : 0;
        }
    }
}