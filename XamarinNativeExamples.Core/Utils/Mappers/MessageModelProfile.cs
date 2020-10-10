using AutoMapper;
using XamarinNativeExamples.Core.Models;
using XamarinNativeExamples.Core.Services.Messages.Responses;

namespace XamarinNativeExamples.Core.Utils.Mappers
{
    /// <summary>
    /// Profile to be used for mapping Request Message to Model object or vice versa
    public class MessageModelProfile : Profile
    {
        public MessageModelProfile()
        {
            CreateMap<NewsSentimentResponse, NewsSentimentModel>();
            CreateMap<Buzz, BuzzModel>();
            CreateMap<Sentiment, SentimentModel>();
        }
    }
}
