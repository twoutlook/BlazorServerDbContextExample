﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace Dreamaitek.Chenpingling
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Plan

    {
        [JsonProperty("razorpage")]
        public string Razorpage { get; set; }

        [JsonProperty("entitytype")]
        public string Entitytype { get; set; }

        [JsonProperty("filtercontains")]
        public string[] Filtercontains { get; set; }

        [JsonProperty("sortorder")]
        public string[] Sortorder { get; set; }
    }
}
