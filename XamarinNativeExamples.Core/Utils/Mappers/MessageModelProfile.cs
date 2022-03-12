using System;
using AutoMapper;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Services.RestServices.Responses;
using XamarinNativeExamples.Core.Services.WebSocketServices.Messages.Responses;

namespace XamarinNativeExamples.Core.Utils.Mappers
{
    /// <summary>
    /// Profile to be used for mapping Request Message to Model object or vice versa
    /// </summary>
    public class MessageModelProfile : Profile
    {
        public MessageModelProfile()
        {
            CreateMap<NewsSentimentResponse, NewsSentimentModel>();
            CreateMap<Buzz, BuzzModel>();
            CreateMap<Sentiment, SentimentModel>();

            CreateMap<DataResponse, PriceUpdateModel>()
                .ForMember(dest => dest.Time, op => op.MapFrom(src => DateTimeExtensions.UnixTimeToLocalDateTime(src.UnixTimeStamp)));
        }
    }
}
