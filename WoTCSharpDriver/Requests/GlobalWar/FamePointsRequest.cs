﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WoTCSharpDriver.Attributes;

namespace WoTCSharpDriver.Requests.GlobalWar
{
    public class FamePointsRequest : GlobalWarRequestBase
    {
        public override string MethodName
        {
            get
            {
                return "famepoints";
            }
        }

        [RequestParameter("map_id", true)]
        public int MapId { get; set; }

        [RequestParameter("account_id", true)]
        public string AccountId { get; set; }
    }
}