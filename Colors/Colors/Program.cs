using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using PalletLib;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using RestSharp;

namespace Colors
{
    class Program
    {
        static void Main(string[] args)
        {

            DoWork();
            NotWorking();

            //var fileName = @"D:\test1.jpg";
            var fileName = @"D:\my_photo.jpg";
            //var fileName = @"D:\small.jpg";

            var pallet = ImageProcessor.GetPallet(fileName);

            var number = ImageProcessor.CountImageColors(fileName);

            Console.WriteLine($"Total number of colors: {number}");

            var abundantColors = pallet.GetMostCommonColors(10).ToList();

            foreach (ColorAbundance colorAbundance in abundantColors)
            {
                Console.WriteLine(colorAbundance.PalletColor + " -> " + colorAbundance.Abundance);
            }


            Console.ReadKey();
        }

        private static async void NotWorking()
        {
            var url = "https://api.clarifai.com/v2/models/aaa03c23b3724a16a56b629203edc62c/outputs?Authorization=183d315df7b4488a9c177c70f29f9dcd";

            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add(HttpRequestHeader.Authorization, "Key a91dbe59965a47f1a5ad0a269f460abb");
            request.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            var json = "{\"inputs\":[{\"data\":{\"image\":{\"url\":\"https://www.thoughtco.com/thmb/07W0mpQ_K2BG2GNdi1AiFFlUDeI=/768x0/filters:no_upscale():max_bytes(150000):strip_icc()/chemistry-glassware-56a12a083df78cf772680235.jpg\"}}}]}";


            var data = new StringContent(json, Encoding.UTF8, "application/json");


            using var client = new HttpClient();

            var resp = await client.PostAsync(url, data);

            string result = resp.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        private static void DoWork()
        {
            var client = new RestClient("https://api.clarifai.com/v2/models/aaa03c23b3724a16a56b629203edc62c/outputs?Authorization=183d315df7b4488a9c177c70f29f9dcd");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Key a91dbe59965a47f1a5ad0a269f460abb");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{  " + "\n" +
            @"   ""inputs"":[  " + "\n" +
            @"      {  " + "\n" +
            @"         ""data"":{  " + "\n" +
            @"            ""image"":{  " + "\n" +
            @"               ""url"":""https://www.thoughtco.com/thmb/07W0mpQ_K2BG2GNdi1AiFFlUDeI=/768x0/filters:no_upscale():max_bytes(150000):strip_icc()/chemistry-glassware-56a12a083df78cf772680235.jpg""" + "\n" +
            @"            }" + "\n" +
            @"         }" + "\n" +
            @"      }" + "\n" +
            @"   ]" + "\n" +
            @"}" + "\n" +
            @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
