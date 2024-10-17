using CBTPreparation.Application.Features.UpdateToken;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Auth.UpdateToken
{
    public class CreateRefreshTokenMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateRefreshTokenRequest, UpdateTokenCommand>()
                .Map(x => x.Token, src => src.Token)
                .Map(x => x.RefreshToken, src => src.RefreshToken);

            config.ForType<UpdateTokenCommandResponse, CreateRefreshTokenResponse>()
               .Map(x => x.Token, src => src.Token)
               .Map(x => x.RefreshToken, src => src.RefreshToken)
               .Map(x => x.BaseAipResponse, src => src.BaseResponse);
        }
    }
}

