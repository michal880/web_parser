using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using web_parser.Models;
using web_parser.ViewModels;

namespace web_parser.Mappings
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Response, ResponseViewModel>()
                .ForMember(dest => dest.TenMostOccurringMarkups, opt => opt.MapFrom(r => GetTenMostOccuringMarkups(r.Markups)));
        }

        private static List<string> GetTenMostOccuringMarkups(List<string> markups)
        {
            return markups.GroupBy(m => m).OrderByDescending(g => g.Count()).Select(m => m.Key).Take(10).ToList();
        }
    }
}