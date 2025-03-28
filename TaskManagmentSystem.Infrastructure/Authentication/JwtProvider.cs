﻿using TaskManagmentSystem.Application.Interfaces.Auth;
using TaskManagmentSystem.Core.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using LearningPlatform.Application.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TaskManagmentSystem.Infrastructure.Authentication;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
	private readonly JwtOptions _options = options.Value;

	public string Generate(User user)
	{
		Claim[] claims =
		[
			new (CustomClaims.UserId, user.Id.ToString()),
		];

		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
			SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
			signingCredentials: signingCredentials);

		var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

		return tokenValue;
	}
}
