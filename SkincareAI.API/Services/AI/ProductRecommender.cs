using SkincareAI.API.Models.Entities;
using SkincareAI.API.Models.Enums;

namespace SkincareAI.API.Services.AI
{
    public class ProductRecommender
    {
        public List<Product> RecommendProducts(List<Product> products, SkinType skinType, List<string> concerns)
        {
            var scoredProducts = products.Select(p => new
            {
                Product = p,
                Score = CalculateProductScore(p, skinType, concerns)
            })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Take(10)
            .Select(x => x.Product)
            .ToList();

            return scoredProducts;
        }

        private int CalculateProductScore(Product product, SkinType skinType, List<string> concerns)
        {
            int score = 0;

 
            if (product.SuitableForSkinTypes.Contains(skinType))
                score += 30;

    
            foreach (var concern in concerns)
            {
                if (product.Benefits.Any(b => b.Contains(concern, StringComparison.OrdinalIgnoreCase)))
                    score += 20;
            }

    
            score += (int)(product.Rating * 2);

      
            if (!product.SuitableForSkinTypes.Contains(skinType))
                score -= 50;

            return Math.Max(0, score);
        }
    }
}