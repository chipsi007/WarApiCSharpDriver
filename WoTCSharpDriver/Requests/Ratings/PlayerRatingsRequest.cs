﻿using System;
using Utilities.Attributes;

namespace WarApiCSharpDriver.Requests.Ratings
{
    public class PlayerRatingsRequest : RatingsRequestBase
    {
        public override string MethodName
        {
            get
            {
                return "accounts";
            }
        }

        [RequestParameter("account_id", true)]
        public string AccountId { get; set; }

        // todo: create constants for it
        [RequestParameter("type", true)]
        public string Type { get; set; }

        [RequestParameter("date", true)]
        public DateTime Date { get; set; }
    }
}
