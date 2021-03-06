﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WarApi.Responses.Clan
{
    public class ClanListData
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("clan_id")]
        public int ClanId { get; set; }

        // todo: use class Color
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("members_count")]
        public int MembersCount { get; set; }

        [JsonProperty("motto")]
        public string Motto { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("emblems")]
        public ClanEmblems Emblems { get; set; }
    }

    [Obsolete("Method disabled", false)]
    public class ClanListResponse : ResponseBase<IList<ClanListData>>
    {
    }
}
