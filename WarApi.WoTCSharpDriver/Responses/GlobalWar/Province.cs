﻿using Newtonsoft.Json;

namespace WarApi.Responses.GlobalWar
{
    public class Province
    {
        [JsonProperty("occupancy_time")]
        public int OccupancyTime { get; set; }

        [JsonProperty("province_i18n")]
        public string Name { get; set; }

        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }
    }
}
