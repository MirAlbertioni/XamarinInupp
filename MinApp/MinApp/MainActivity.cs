using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using System;

namespace MinApp
{
    [Activity(Label = "MinApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText inputLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("8c94596f-4844-4998-a5e7-615b1e0549bd",
                   typeof(Analytics), typeof(Crashes));

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            inputLocation = FindViewById<EditText>(Resource.Id.inputLocation);
            Button readJson = FindViewById<Button>(Resource.Id.readJson);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);

            readJson.Click += async delegate
            {
                textView.Text = "";
                using (var client = new HttpClient())
                {
                    var req = new HttpRequestMessage
                    {
                        RequestUri = new Uri("https://api.resrobot.se/location.name?key=ead40c96-d5e9-4db5-a6a8-2d75ae9c40ed&input="
                        + inputLocation.Text + "&format=json")
                    };
                    req.Headers.Add("Accept", "application/json");
                    var response = await client.SendAsync(req);
                    var data = await response.Content.ReadAsStringAsync();

                    var posts = JsonConvert.DeserializeObject<Rootobject>(data);
                    var x = posts.StopLocation.ToList();
                    string myText;
                    foreach (var text in x)
                    {
                        myText = text.name + "\n" + textView.Text;
                        textView.Text = myText;
                        inputLocation.Text = "";
                    }
                }
            };
        }
    }
}

