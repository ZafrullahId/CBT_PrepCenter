using CBTPreparation.Application.Features.Auth.GetAuth;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken
{
    public class GetTokenMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetTokenQueryResponse, GetTokenResponse>()
                .Map(x => x.BaseResponse, src => src.BaseResponse)
                .Map(x => x.Token, src => src.Token)
                .Map(x => x.RefreshToken, src => src.RefreshToken);
        }
    }
}

