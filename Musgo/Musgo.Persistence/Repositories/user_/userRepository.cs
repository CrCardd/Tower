
﻿using Musgo.Application.Repository.userRepository;
using Musgo.Domain.Models;
using Musgo.Persistence.Context;

namespace Musgo.Persistence.Repositories.user_;

public class userRepository(MusgoContext context)
    : BaseRepository<user>(context), IuserRepository
{
    
}
