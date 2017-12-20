using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace AppInUpp
{
    public class Rootobject
    {
        public Stoplocation[] StopLocation { get; set; }
    }

    public class Stoplocation
    {
        public string id { get; set; }
        public string extId { get; set; }
        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public int weight { get; set; }
        public int products { get; set; }
    }
}

