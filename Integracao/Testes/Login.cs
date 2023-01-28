using System;
using Newtonsoft.Json;

namespace Testes
{
	public class Login
	{
		public Login()
		{
		}

        [JsonProperty("token")]
		public string Token { get; set; }
	}
}

