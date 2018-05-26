using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile(new ResponseProfile());
            });
        }
    }
}