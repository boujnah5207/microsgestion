using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Blackspot.Microgestion.Backend.Extensions
{
	public static class SearchExtensions
	{
		private static int IsRelevant<T>(IEnumerable<string> keywords, T item) where T : ISearchable
		{
			var originalText = item.SearchString;
			foreach (var keyword in keywords)
			{
				Regex reg = new Regex(keyword, RegexOptions.IgnoreCase);
				if (!reg.IsMatch(originalText))
					return 0;
			}

			return 1;
		}

		public static IEnumerable<T> FindElementByRelevance<T> (this IEnumerable<T> elements, string input) 
			where T : ISearchable
		{
			var keywords = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			if (keywords.Length == 0)
				return new List<T>();

			return Search.FindItems(keywords, elements, IsRelevant);
		}

        public static IEnumerable<T> FindElementByRelevance<T>(this IEnumerable<T> elements, IEnumerable<string> keywords) 
			where T : ISearchable
		{
			return Search.FindItems(keywords, elements, IsRelevant);
		}
	}

	public class Search
	{
        public static IEnumerable<T> FindItems<T>(IEnumerable<string> keywords, IEnumerable<T> elements, Func<IEnumerable<string>, T, int> RelevanceFunction)
		{
			var query = from w in elements
						let relevance = RelevanceFunction(keywords, w)
						where relevance > 0
						orderby relevance
						descending
						select w;

			return query;
		}

		public static IEnumerable<T> FindItems<T, W>(IEnumerable<W> keywords, IEnumerable<T> elements, Func<IEnumerable<W>, T, int> RelevanceFunction)
		{
			var query = from w in elements
						let relevance = RelevanceFunction(keywords, w)
						where relevance > 0
						orderby relevance
						descending
						select w;

			return query;
		}
	}
}
