using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace UXDivers.Artina.Grial
{
	public class TranslateService
	{
		public TranslateService ()
		{
		}


		public async Task<string> TranslateAsync (string ContentText)
		{
			string ContentTranslate;

			string uri = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=fr&dt=t&q=" + ContentText;
			//string uri2 = "https://www.googleapis.com/language/translate/v2?q=bateau&target=en&format=text&fields=translations";

			var client = new HttpClient ();
			HttpResponseMessage response = await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				using (var ms = new MemoryStream ()) 
				{
					await response.Content.CopyToAsync (ms);
					ms.Position = 0;

					var fileTranslate = new StreamReader (ms);
					var fileReadConvert = fileTranslate.ReadToEnd ();
					string[] substrings = fileReadConvert.Split('"');
					foreach (string match in substrings)
					{
						Debug.WriteLine("'{0}'", match);
					}
					ContentTranslate = substrings [1];
					return ContentTranslate;

				}

			}
			return "false";
		}



		//public void htttprequest ()
		//{
		//	//langue message = auto;
		//	//langue a traduire = langue a traduire;
		//	//mesage a traduire = contenttexte;

		//	HttpRequestMessage request = new HttpRequestMessage ();


			                   
		//	request.Method = Post;
		//	request.RequestUri = "http";
		//	HttpResponseMessage reponse = new HttpResponseMessage ();


		//}




		////string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);

		//HttpRequestMessage Request = new HttpRequestMessage();
		////request.Encoding = System.Text.Encoding.UTF8;
		//Request.RequestUri = uri;

		//HttpResponseMessage Response = new HttpResponseMessage ();
		//Debug.WriteLine;

		////string reponse = string.Format ("[[["argent","お金",,,0]],,"ja",,,,1,,[["ja"],,[1],["ja"]]]");
		////Response = reponse.ToString ();
		//return Response;

		////string result = request.RequestUri(url);
		////result = result.Substring(result.IndexOf("id=result_box") + 22, result.IndexOf("id=result_box") + 500);
		////result = result.Substring(0, result.IndexOf("</div"));
		////return result;

	}
}

