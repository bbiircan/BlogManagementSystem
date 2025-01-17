﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Entities;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt;
public class JwtHelper:ITokenHelper
{
    public IConfiguration Configuration { get; }
    private TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        
    }
    public AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };

    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, IUser user, 
        SigningCredentials signingCredentials, List<IOperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer:tokenOptions.Issuer,
            audience:tokenOptions.Audience,
            expires:_accessTokenExpiration,
            notBefore:DateTime.Now,
            claims: SetClaims(user,operationClaims),
            signingCredentials:signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(IUser user, List<IOperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FullName}");
        claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());
        
        return claims;
    }
}