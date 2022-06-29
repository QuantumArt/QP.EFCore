using System.Linq;

namespace EntityFrameworkCore.Generator.Result
{
	public class Class1
	{
		// You can access Generated classes here
		public static void Main()
		{
            using var ctx = new QA.EFCore.EFCoreModel();
            var mProducts = ctx.MarketingProducts.Select(x => x.Title).ToList();

            QA.EFCore.CacheTagUtilities utils = null;
            var action = () => utils.Merge(QA.EFCore.CacheTags.MarketingProduct, QA.EFCore.CacheTags.Product);
		}
	}
}