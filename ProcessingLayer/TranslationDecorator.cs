using Newtonsoft.Json.Linq;

namespace ProcessingLayer
{
    public class TranslationDecorator : BaseDecorator
    {
        public TranslationDecorator(ITextComponent wrapee) : base(wrapee) { }

        public override void transform(string text)
        {
            var translatedText = GetTranslatedString(MakeRequest(text, "uk", "en"));
            base.transform(translatedText);
        }
        public override string read()
        {
            string text = base.read();
            string translatedText = GetTranslatedString(MakeRequest(text, "en", "uk"));
            return translatedText;
        }
        private Task<string> MakeRequest(string text,string targetLang,string sourceLang)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
                {
                    { "X-RapidAPI-Key", "019cb831c8mshb8164d67aedd359p1f7515jsna15372892922" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", text},
                    { "target", targetLang },
                    { "source", sourceLang },
                }),
            };
            return GetResponse(client, request);
        }

        private async Task<string> GetResponse(HttpClient client, HttpRequestMessage request)
        {
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();//200
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        private string GetTranslatedString(Task<string> str)
        {
            JObject obj = JObject.Parse(str.Result);

            string decodedString = obj["data"]["translations"][0]["translatedText"].ToString();

            return decodedString;
        }
    }
}
