﻿using System;
using WarApi.CodeGenerator.Contracts;
using WarApi.CodeGenerator.Models.Api;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WarApi.CodeGenerator
{
    public class PageParser : IPageParser
    {
        private readonly IPageDownloader pageDownloader;

        public PageParser(IPageDownloader pageDownloader)
        {
            this.pageDownloader = pageDownloader;
        }

        public Method Parse(Uri url)
        {
            var methodJsonString = pageDownloader.Download(url);

            var jObject = JObject.Parse(methodJsonString);

            var description = GetDescription(jObject);
            var block = GetBlock(jObject);
            var name = GetName(jObject);
            var requestParameters = GetRequestParameters(jObject);
            var responseParameters = GetResponseParameters(jObject);

            return new Method
            {
                Name = name,
                Block = block,
                Description = description,
                RequestParameters = requestParameters,
                ResponseParameters = responseParameters
            };
        }

        private IEnumerable<RequestParameter> GetRequestParameters(JObject jObject)
        {
            var token = jObject.SelectToken("data.parameters").ToString();
            var parameters = JsonConvert
                .DeserializeObject<IEnumerable<RequestParameter>>(token);
            foreach (var parameter in parameters)
            {
                parameter.Description = HtmlCleaner.Clean(parameter.Description);
            }
            return parameters;
        }

        private IEnumerable<ResponseParameter> GetResponseParameters(JObject jObject)
        {
            var token = jObject.SelectToken("data.fields").ToString();
            var parameters = JsonConvert
                .DeserializeObject<IEnumerable<ResponseParameter>>(token)
                .Where(p => p.Type != "empty_line");
            foreach (var parameter in parameters)
            {
                parameter.Description = HtmlCleaner.Clean(parameter.Description);
            }
            return parameters;
        }

        private string GetName(JObject jObject)
        {
            return jObject.SelectToken("data.url").ToString().Split('/').Last();
        }

        private string GetBlock(JObject jObject)
        {
            return jObject.SelectToken("data.section").ToString();
        }

        private string GetDescription(JObject jObject)
        {
            return HtmlCleaner.Clean(jObject.SelectToken("data.description").ToString());
        }
    }
}
