using CBTPreparation.Application.Features.Auth.CreateToken;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Auth.CreateToken
{
    public class CreateTokenMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateTokenCommandResponse, CreateTokenResponse>()
                .Map(x => x.BaseResponse, src => src.BaseResponse)
                .Map(x => x.Token, src => src.Token)
                .Map(x => x.RefreshToken, src => src.RefreshToken);
        }
    }
}

