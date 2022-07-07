using Microsoft.EntityFrameworkCore;
using QA.EF;

namespace EntityFrameworkCore.Generator.ReferenceResult;

public class Test
{
	private readonly EF6Model _context;


	public Test(EF6Model context)
	{
		_context = context;
	}

	public async Task Run()
	{
		var items = await _context.FileFieldsItems.ToArrayAsync();

		CacheTagUtilities utils = null;
		var action = () => utils.Merge(CacheTags.ItemForInsert, CacheTags.ItemForUpdate);
	}
}