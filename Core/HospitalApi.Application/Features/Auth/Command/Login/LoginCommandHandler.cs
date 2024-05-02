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
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {

        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginCommandHandler(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, ITokenService tokenService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {

            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcıyı e-posta adresine göre bul
            User user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                // Şifre doğruluğunu kontrol et
                bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);
                if (isPasswordCorrect)
                {
                    // JWT oluştur
                    IList<string> roles = await userManager.GetRolesAsync(user);
                    JwtSecurityToken token = await tokenService.CreateToken(user, roles);
                    string refreshToken = tokenService.GenerateRefreshToken();

                    // Yenileme token'ının geçerlilik süresini ayarla
                    _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                    // Kullanıcı bilgilerini güncelle
                    await userManager.UpdateAsync(user);
                    await userManager.UpdateSecurityStampAsync(user);

                    // JWT'yi kullanıcıya gönder
                    string _token = new JwtSecurityTokenHandler().WriteToken(token);
                    await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

                    // Yanıtı oluştur
                    return new LoginCommandResponse
                    {
                        Token = _token,
                        RefreshToken = refreshToken,
                        Expiration = token.ValidTo
                    };
                }
            }

            // Kullanıcı adı veya şifre yanlış, hata döndür
            throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış.");
        }
    }
}
