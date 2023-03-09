using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ilum.Api.Models;
using Ilum.Domain.Context;
using Ilum.Domain.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ConfigurationManager = Ilum.Api.Configurations.ConfigurationManager;

namespace Ilum.Api.Features.Commands;

public class AuthenticationCommand : IRequest<JWTTokenResponse>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class AuthenticationCommandHandler : BaseHandler, IRequestHandler<AuthenticationCommand, JWTTokenResponse>
{
    public AuthenticationCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<JWTTokenResponse> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        if (request.Email is not null && request.Password is not null && request.Email != string.Empty && request.Password != string.Empty)
        {
            User user = await _ilumContext.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();
            if (user is not null && BCrypt.Net.BCrypt.Verify(request.Password, user.LastPassword))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return new JWTTokenResponse { Token = tokenString };
            }
        }

        return null;
    }
}