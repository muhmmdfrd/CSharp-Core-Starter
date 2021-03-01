using Newtonsoft.Json;
using System;

namespace Core.Manager.TestManager
{
	public class TestDTO
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("age")]
		public int Age { get; set; }

		[JsonProperty("joinDate")]
		public DateTime JoinDate { get; set; }
	}
}
