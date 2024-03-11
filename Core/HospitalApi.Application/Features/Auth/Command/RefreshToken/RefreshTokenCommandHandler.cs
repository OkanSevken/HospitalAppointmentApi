using HospitalApi.Application.Interfaces.AutoMapper;
using HospitalApi.Application.Interfaces.Tokens;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RefreshTokenCommandHandler(UserManager<User> userManager, IMapper mapper, ITokenService tokenService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
           
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal =tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email=principal.FindFirstValue(ClaimTypes.Email);

            User? user =await userManager.FindByEmailAsync(email);
            IList<string> roles =await userManager.GetRolesAsync(user);

            if(user.RefreshTokenExpiryTime<=DateTime.Now)
            {
                throw new Exception("Oturum süresi dolmuştur.Lütfen tekrar giriş yapın.");
            }

            JwtSecurityToken newAccessToken=await tokenService.CreateToken(user,roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken=newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
