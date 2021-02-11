using System;
using System.Linq;

namespace EntityFrameworkCore.Generator.Result
{
	public class Class1
	{
		// You can access Generated classes here
		public static void Main()
		{
            using var ctx = new EFCoreModel();
            var mProducts = ctx.MarketingProducts.Select(x => x.Title).ToList();
        }
	}
}