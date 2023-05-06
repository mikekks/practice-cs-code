using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
// NuGet 패키지로 Newtonsoft 다운받으셔야 합니다.
using Newtonsoft.Json.Linq;

namespace HttpClient_test
{

	static class HttpResponseMessageExtensions
	{
		internal static void WriteRequestToConsole(this HttpResponseMessage response)
		{
			if (response is null)
			{
				return;
			}

			var request = response.RequestMessage;
            Console.WriteLine($"--- HttpResponseMessageExtensions ---");
            Console.WriteLine($"{request?.Method} ");
			Console.WriteLine($"{request?.RequestUri} ");
			Console.WriteLine($"HTTP/{request?.Version}");
		}
	}

	class Program
	{

		private static HttpClient sharedClient = new()
		{
			BaseAddress = new Uri("https://api.openai.com/"),
		};


		static void Main(string[] args)
		{
			// 실행 코드
            PostAsync(sharedClient).GetAwaiter().GetResult();
		}

		static async Task PostAsync(HttpClient httpClient)
		{
			// 조합을 요청하고자 하는 텍스트를 prompt의 value에 넣어주시면 됩니다. 
            using StringContent jsonContent = new(
				JsonSerializer.Serialize(new
				{
                    model= "image-alpha-001",
					prompt= "a cup of coffee with a smiley face", 
					num_images= 1,
					size= "1024x1024",
					response_format= "url"
                }),
				Encoding.UTF8,
				"application/json");

			// 개인 API 키 입니다.
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "v1/images/generations",
				jsonContent);

			response.EnsureSuccessStatusCode()
				.WriteRequestToConsole();

            var responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());
            var url = responseJson["data"][0]["url"].ToString();

            Console.WriteLine($"--- PostAsync ---");
            Console.WriteLine($"{url}\n");
		}
	}
}
