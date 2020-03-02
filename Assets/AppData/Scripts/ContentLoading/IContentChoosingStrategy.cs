using App.Data;

namespace App.ContentLoading
{
	public interface IContentChoosingStrategy
	{
		ChronologicalContentOptions GetContent();
	}
}
