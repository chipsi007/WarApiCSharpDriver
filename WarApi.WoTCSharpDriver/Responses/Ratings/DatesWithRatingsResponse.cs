﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WarApi.ConstantValues;

namespace WarApi.Responses.Ratings
{
    public class DatesWithRatingsResponse : ResponseBase<IDictionary<RatingType, DatesWithRatingsResponseData>>
    {
    }

    public class DatesWithRatingsResponseData
    {
        [JsonProperty("dates")]
        public IList<DateTime> Dates; 
    }
}
