using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Models
{

	public class Pagination<T>
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "filtered")]
        public int Filtered { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "data")]
        public IEnumerable<T> Data { get; set; }

        public Pagination()
        {
            Total = 1;
            PageSize = 5;
            Data = null;
        }
    }
}
