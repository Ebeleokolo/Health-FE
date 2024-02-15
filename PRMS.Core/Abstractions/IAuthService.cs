﻿using PRMS.Core.Dtos;

namespace PRMS.Core.Abstractions;

public interface IAuthService
{
    public Task<Result> Register(RegisterUserDto registerUserDto);
    public Task<Result<LoginResponseDto>> Login(LoginUserDto loginUserDto);
}