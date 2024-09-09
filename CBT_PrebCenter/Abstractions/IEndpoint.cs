namespace Application.Abstractions
{
    internal interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
