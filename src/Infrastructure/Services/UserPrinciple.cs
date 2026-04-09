using ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services;

public sealed class UserPrinciple : IUserPrinciple
{
    public bool IsTemporary => false;

    public Guid GetUserId()
    {
        var fakeUserId = "C6A2D64D-7B7A-44B2-AA41-B5E82BFB1F77";
        return Guid.Parse(fakeUserId);
    }
}
